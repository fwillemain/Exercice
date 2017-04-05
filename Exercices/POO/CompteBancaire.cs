using System;

namespace POO
{
	public class CompteBancaire : IAlertable
	{
		#region Champs privés
		private bool _aDécouvert;
		private DateTime _dateCréation;
		private DateTime _dateCloture;
		private decimal _soldeCourant;
		private decimal _découvertAutorisé;
		private long _numéro;
		private Carte _carte;
		#endregion

		/// <summary>
		/// Création d'un compte avec son numéro
		/// </summary>
		public CompteBancaire(long numéro)
		{
			_numéro = numéro;
		}

		/// <summary>
		/// Création d'un compte avec son numéro, sa date de création et son solde
		/// </summary>
		public CompteBancaire(long numéro, DateTime dateCréa, decimal solde) :
			this(numéro)
		{
			_dateCréation = dateCréa;
			_soldeCourant = solde;
		}

		#region Propriétés
		public bool ADécouvert
		{
			get { return _aDécouvert; }
		}

		public DateTime DateCloture
		{
			get { return _dateCloture; }
		}

		public DateTime DateCréation
		{
			get { return _dateCréation; }
		}

		public decimal SoldeCourant
		{
			get { return _soldeCourant; }
		}

		public decimal DécouvertAutorisé
		{
			get { return _découvertAutorisé; }
			set { _découvertAutorisé = value; }
		}
		#endregion

		#region Méthodes privées
		private int CalculerAncienneté()
		{
			return (DateTime.Today - _dateCréation).Days;
		}

		private decimal CalculerIntérêts()
		{
			throw new NotImplementedException();
		}


		private decimal CalculerSolde()
		{
			return _soldeCourant + CalculerIntérêts();
		}
		#endregion

		#region Méthodes publiques
		public void Cloturer()
		{
			_dateCloture = DateTime.Today;
			CalculerSolde();
		}

		public void Créditer(decimal montant)
		{
			_soldeCourant += montant;
			if (_soldeCourant > 0)
				_aDécouvert = false;
		}

		public void Débiter(decimal montant)
		{
			_soldeCourant -= montant;
			if (_soldeCourant < 0)
			{
				_aDécouvert = true;

				// Si le solde est au-dessus du découvert autorisé,
				// on applique des agios au taux de 14%, sinon on lève une exception
				if (_soldeCourant >= _découvertAutorisé)
					_soldeCourant += _soldeCourant * 0.14m; // agios
				else
					throw new ArgumentOutOfRangeException();
			}
		}

		// Agrégation
		public void AjouterCarte(Carte carte)
		{
			_carte = carte;
		}

		// Composition
		public void CréerCarte(long num, DateTime dateExpir)
		{
			// Appel du constructeur avec paramètre, et de l'initialiseur
			_carte = new Carte (101) { NumCarte = 161616516, DateExpiration = dateExpir };
		}

		#endregion
	}
}
