using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

// Classe issue de cet article : http://www.c-sharpcorner.com/UploadFile/tirthacs/inotifydataerrorinfo-in-wpf/
namespace Divers
{
	/// <summary>
	/// Provides validation ability based on INotifyDataErrorInfo interface and DataAnnotationss
	/// </summary>
	public class ValidationBase : INotifyPropertyChanged, INotifyDataErrorInfo
	{
		#region INotifyPropertyChanged implementation

		/// <summary>
		/// Raised when a property on this object has a new value.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Warns the developer if this object does not have a public property with
		/// the specified name. This method does not exist in a Release build.
		/// </summary>
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			// verify that the property name matches a real,  
			// public, instance property on this object.
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				Debug.Fail("Invalid property name: " + propertyName);
			}
		}

		/// <summary>
		/// Raises this object's PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The name of the property that has a new value.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			VerifyPropertyName(propertyName);

			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region INotifyDataErrorInfo implementation
		private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
		private object _lock = new object();

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
		public bool HasErrors
		{
			get { return _errors.Any(propErrors => propErrors.Value != null && propErrors.Value.Count > 0); }
		}
		public bool IsValid
		{
			get { return HasErrors; }
		}

		public IEnumerable GetErrors(string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName))
				return _errors.SelectMany(err => err.Value.ToList());

			if (_errors.ContainsKey(propertyName) && (_errors[propertyName] != null) && _errors[propertyName].Count > 0)
				return _errors[propertyName].ToList();
			else
				return null;
		}

		public void OnErrorsChanged(string propertyName)
		{
			if (ErrorsChanged != null)
				ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
		}

		#endregion

		#region Validation methods
		// Validate a property
		public void ValidateProperty(object value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			lock (_lock)
			{
				var validationContext = new ValidationContext(this, null, null);
				validationContext.MemberName = propertyName;
				var validationResults = new List<ValidationResult>();
				Validator.TryValidateProperty(value, validationContext, validationResults);

				//clear previous _errors from tested property  
				if (_errors.ContainsKey(propertyName))
					_errors.Remove(propertyName);
				OnErrorsChanged(propertyName);
				HandleValidationResults(validationResults);
			}
		}

		// Validate all properties
		public void Validate()
		{
			lock (_lock)
			{
				var validationContext = new ValidationContext(this, null, null);
				var validationResults = new List<ValidationResult>();
				Validator.TryValidateObject(this, validationContext, validationResults, true);

				//clear all previous _errors  
				var propNames = _errors.Keys.ToList();
				_errors.Clear();
				propNames.ForEach(pn => OnErrorsChanged(pn));
				HandleValidationResults(validationResults);
			}
		}

		private void HandleValidationResults(List<ValidationResult> validationResults)
		{
			//Group validation results by property names  
			var resultsByPropNames = from res in validationResults
									 from mname in res.MemberNames
									 group res by mname into g
									 select g;
			//add _errors to dictionary and inform binding engine about _errors  
			foreach (var prop in resultsByPropNames)
			{
				var messages = prop.Select(r => r.ErrorMessage).ToList();
				_errors.Add(prop.Key, messages);
				OnErrorsChanged(prop.Key);
			}
		}
		#endregion
	}
}
