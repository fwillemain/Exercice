﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCafé
{
    class Program
    {
        static void Main(string[] args)
        {
            MachineCafé mc = new MachineCafé();

            while (!mc.SélectionsValidées)
            {
                try
                {
                    if (!mc.BoissonChoisie)
                        mc.ChoisirBoisson();

                    if (!mc.QuantitéSucreChoisie)
                        mc.ChoisirQuantitéSucre();

                    if (!mc.PaiementChoisi)
                        mc.ChoisirPaiement();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Votre boisson est prête!");
            Console.ReadKey();
        }

        public class MachineCafé
        {
            public enum Boisson { Café, Chocolat, Soupe }
            public enum Paiement { Espèces, Badge }

            #region Champs privés
            Boisson _boissonChoisie;            // la boisson choisie
            bool _boissonChoisieBool;           // booléen indiquant si une boisson a été choisie par l'utilisateur

            Paiement _paiementChoisi;           // le paiement choisi
            bool _paiementChoisiBool;           // booléen indiquant si un paiement a été choisi par l'utilisateur

            int _quantitéSucre;                 // la quantité de sucre choisi
            bool _quantitéSucreBool;            // booléen indiquant si la quantité de sucre a été choisi par l'utilisateur

            bool _sélectionsValidées;           // booléen indiquant si les sélections précédentes ont été validées par l'utilisateur
            #endregion

            #region Propriétés
            /// <summary>
            /// Retourne true si l'utilisateur a choisi une boisson
            /// </summary>
            public bool BoissonChoisie
            {
                get { return _boissonChoisieBool; }
            }

            /// <summary>
            /// Retourne true si l'utilisateur a choisi un mode de paiement
            /// </summary>
            public bool PaiementChoisi
            {
                get { return _paiementChoisiBool; }
            }

            /// <summary>
            /// Retourne true si l'utilisateur a choisi une quantité de sucre (ou si il a choisi une soupe)
            /// </summary>
            public bool QuantitéSucreChoisie
            {
                get { return _quantitéSucreBool; }
            }

            /// <summary>
            /// Retourne true si l'utilisateur à valider définitivement ses sélections
            /// </summary>
            public bool SélectionsValidées
            {
                get { return _sélectionsValidées; }
            }
            #endregion

            #region Constructeurs
            /// <summary>
            /// Initialise la machine à café avec la boisson Café, le paiement Espèces et la quantité de sucre à 3 grammes par défaut
            /// </summary>
            public MachineCafé()
            {
                Console.WriteLine("Initialisation de la machine à café.");
                _boissonChoisie = Boisson.Café;
                _paiementChoisi = Paiement.Espèces;
                _quantitéSucre = 3;
                _boissonChoisieBool = false;
                _paiementChoisiBool = false;
                _quantitéSucreBool = false;
            }
            #endregion

            #region Méthodes privées
            /// <summary>
            /// Affichage la boisson sélectionnée entre Café, Chocolat et Soupe
            /// </summary>
            private void AfficherBoissonSelectionnée()
            {
                switch (_boissonChoisie)
                {
                    case Boisson.Café:
                        Console.WriteLine("Café sélectionné");
                        break;
                    case Boisson.Chocolat:
                        Console.WriteLine("Chocolat sélectionné");
                        break;
                    case Boisson.Soupe:
                        Console.WriteLine("Soupe sélectionnée");
                        break;
                }
            }

            /// <summary>
            /// Affiche le paiement sélectionné entre Espèces et Badge
            /// </summary>
            private void AfficherPaiementSelectionné()
            {
                switch (_paiementChoisi)
                {
                    case Paiement.Espèces:
                        Console.WriteLine("Paiement en espèces sélectionné");
                        break;
                    case Paiement.Badge:
                        Console.WriteLine("Paiement par badge sélectionné");
                        break;
                }
            }

            /// <summary>
            /// Affiche la quantité de sucre choisie
            /// </summary>
            private void AfficherQuantitéSucre()
            {
                Console.WriteLine("{0} grammes de sucre à ajouter", _quantitéSucre);
            }

            /// <summary>
            /// Affiche les sélections de l'utilisateur et lui demande de les valider ou d'annuler
            /// </summary>
            private void ValiderSélection()
            {
                //TODO : gérer les sélections non efféctuées

                // Affichage des séléctions
                AfficherBoissonSelectionnée();
                if (_boissonChoisie != Boisson.Soupe)
                    AfficherQuantitéSucre();
                AfficherPaiementSelectionné();

                // Tant que l'utilisateur ne choisi pas "oui" ou "non"
                while (!_sélectionsValidées)
                {
                    try
                    {
                        Console.Write("Voulez-vous valider vos choix ? \"oui\" ou \"non\"? ");
                        string choix = Console.ReadLine().ToLower();
                        if (choix.Equals("oui"))
                            _sélectionsValidées = true;
                        else if (choix.Equals("non"))
                        {
                            _sélectionsValidées = false;
                            _boissonChoisieBool = false;
                            _paiementChoisiBool = false;
                            _quantitéSucreBool = false;
                            break;
                        }
                        else
                            throw new FormatException("\"oui\" ou \"non\" sont attendus!");
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            #endregion

            #region Méthodes publiques
            /// <summary>
            /// Demande à l'utilisateur de choisir une boisson entre Café, Chocolat et Soupe
            /// </summary>
            public void ChoisirBoisson()
            {
                Console.Write("Choisissez votre boisson : (1) Café, (2) Chocolat, (3) Soupe. ");
                try
                {
                    _boissonChoisie = (Boisson)(int.Parse(Console.ReadLine()) - 1);
                    _boissonChoisieBool = true;

                    // Si l'utilisateur choisi une soupe, il n'y aura pas de quantité de sucre à choisir
                    if (_boissonChoisie == Boisson.Soupe)
                        _quantitéSucreBool = true;

                    if (_paiementChoisiBool && _quantitéSucreBool)
                        ValiderSélection();
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException("Cette boisson n'existe pas!");
                }
            }

            /// <summary>
            /// Demande à l'utilisateur de choisir la quantité de sucre à ajouter si une boisson a été sélectionnée et qu'il ne s'agit pas d'une soupe
            /// </summary>
            public void ChoisirQuantitéSucre()
            {
                // Si une boisson a été choisie et que la quantité de sucre ne l'a pas été, rentrer dans le if
                // Si la boisson est une soupe, la quantité de sucre est déjà validée et on ne rentrera pas dans le if
                if (_boissonChoisieBool && !_quantitéSucreBool)
                {
                    while (!_quantitéSucreBool)
                    {
                        Console.WriteLine("{0} grammes de sucre à ajouter (min = 0 gramme, max = 5 grammes. Choisissez \"moins\", \"plus\" ou \"valider\".", _quantitéSucre);
                        string choix = Console.ReadLine().ToLower();
                        if (choix.Equals("moins"))
                        {
                            if (_quantitéSucre > 0)
                                _quantitéSucre--;
                        }
                        else if (choix.Equals("plus"))
                        {
                            if (_quantitéSucre < 5)
                                _quantitéSucre++;
                        }
                        else if (choix.Equals("valider"))
                            _quantitéSucreBool = true;
                        else
                            throw new FormatException("\"moins\", \"plus\" ou \"valider\" sont attendus!");
                    }
                }

                if (_boissonChoisieBool && _paiementChoisiBool)
                    ValiderSélection();
            }

            /// <summary>
            /// Demande à l'utilisateur de choisir un mode de paiement entre Espèces et Badge
            /// </summary>
            public void ChoisirPaiement()
            {
                Console.Write("Choisissez votre mode de paiement : (1) Espèces, (2) Badge. ");
                try
                {
                    _paiementChoisi = (Paiement)(int.Parse(Console.ReadLine()) - 1);
                    _paiementChoisiBool = true;
                    if (_boissonChoisieBool && _quantitéSucreBool)
                        ValiderSélection();
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException("Cette méthode de paiement n'existe pas!");
                }
            }
            #endregion

        }
    }
}
