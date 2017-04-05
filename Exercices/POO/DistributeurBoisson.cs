using System;

namespace POO
{
    public enum Boissons { CaféNoir, CaféCrème, Thé, PotageTomate }

	public class DistributeurBoisson
	{
		#region Champs privés
		private const decimal PRIX_CAFENOIR = 0.54m;
		private const decimal PRIX_CAFECREME = 0.60m;
		private const decimal PRIX_THE = 0.48m;
		private const decimal PRIX_POTAGE = 0.65m;

		private Boissons _boissonSélectionnée;
		private decimal _prixBoissonSélectionnée;
		private decimal _paiement;
		private int _quantitéSucre;
		private string _préparation;
		#endregion

		#region Propriétés
		public decimal Paiement
		{
			get { return _paiement; }
			set {	_paiement = value; }
		}

		public Boissons BoissonSélectionnée
		{
			get { return _boissonSélectionnée; }
			set
			{
				_boissonSélectionnée = value;

				// On détermine le prix de la boisson sélectionnée
				// NB/ Le code ci-dessous pourrait être simplifié en utilisant un dictionnaire
				if (_boissonSélectionnée == Boissons.CaféNoir)
					_prixBoissonSélectionnée = PRIX_CAFENOIR;
				else if (_boissonSélectionnée == Boissons.CaféCrème)
					_prixBoissonSélectionnée = PRIX_CAFECREME;
				else if (_boissonSélectionnée == Boissons.Thé)
					_prixBoissonSélectionnée = PRIX_THE;
				else
					_prixBoissonSélectionnée = PRIX_POTAGE;

				// Si la somme payée est inférieure au prix de la boisson sélectionnée
				// on lève une exception
				if (_paiement < _prixBoissonSélectionnée)
					throw new InvalidOperationException("paiement insuffisant");
			}
		}

		public int QuantitéSucre
		{
			get { return _quantitéSucre; }
			set { _quantitéSucre = value; }
		}
		#endregion

		#region Méthodes privées
		/// <summary>
		/// Prépare la boisson demandée
		/// </summary>
		/// <param name="boisson"></param>
		/// <returns></returns>
		private void PréparerBoisson(Boissons boisson)
		{
			string poudre;
			if (boisson == Boissons.CaféCrème || boisson == Boissons.CaféNoir)
				poudre = "café";
			else if (boisson == Boissons.Thé)
				poudre = "thé";
			else
				poudre = "concentré de tomate";

			string additif = string.Empty;
			if (boisson == Boissons.CaféCrème)
				additif = "crème";

			string sucre = string.Empty;
			if (_quantitéSucre > 0)
				sucre = _quantitéSucre.ToString() + "g de sucre";

			// On mémorise la boisson dans un champ privé
			_préparation = poudre + " - " + additif + " - eau - " + sucre;
		}
		#endregion

		#region Méthodes publiques
		/// <summary>
		/// Sert la boisson demandée dans un gobelet
		/// </summary>
		/// <returns></returns>
		public string ServirBoisson()
		{
			// Appel de la méthode privée pour préparer la boisson demandée
			PréparerBoisson(_boissonSélectionnée);

			// On peut imagineer ici des opérations internes pour
			// amener un gobelet et le remplir...
			
			return "Je vous sert la préparation suivante :\n" + _préparation;
		}

		/// <summary>
		/// Rend la monnaie
		/// </summary>
		/// <returns>Somme rendue</returns>
		public string RendreMonnaie()
		{
			decimal rendu = _paiement - _prixBoissonSélectionnée;
			if (rendu < 0) rendu = 0;
			return "Je vous rends " + rendu.ToString() + " euros";
			// La méthode ToString permet de transformer n'importe quelle type en chaîne
		}
		#endregion
	}
}
