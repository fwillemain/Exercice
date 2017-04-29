using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuRoulette
{
    [Flags]
    public enum Combinaisons
    {
        Aucune = 0,
        Premiers24 = 1,
        Derniers24 = 2,
        Rouge = 4,
        Noir = 8,
        Impair = 16,
        Pair = 32
    }

    public class Jeu
    {
        #region Champs privés
        private int _nbJetonsInitial;
        private int _nbJetonsActuel;
        private Roulette _roulette;
        #endregion

        #region Constructeurs
        public Jeu()
        {
            _roulette = new Roulette();
        }
        #endregion

        #region Méthodes privées
        /// <summary>
        /// Fait saisir le nombre de jetons initial à l'utilisateur.
        /// </summary>
        private void SaisirNbJetonsInit()
        {
            Console.WriteLine("Combien de jetons avez-vous achetés?");
            while (!int.TryParse(Console.ReadLine(), out _nbJetonsInitial)) ;
            _nbJetonsActuel = _nbJetonsInitial;
        }

        /// <summary>
        /// Fait saisir le montant de la mise à l'utilisateur.
        /// </summary>
        /// <param name="mise"></param> 
        private void SaisirMise(out Mise mise)
        {
            int miseJetons = 0;
            double coefGain = 1;
            int? nbMisé = null;
            string choixCombi = string.Empty;
            Combinaisons combi = Combinaisons.Aucune;
            string[] opt = { "24p", "24d", "r", "n", "i", "p", "x" };

            Console.WriteLine("Mise {0} - Quelle combinaison choisissez-vous?", Mise.Compteur + 1);
            Console.WriteLine("24p / 24d: 24 premiers ou derniers numéros (gain = 50% de la mise)");
            Console.WriteLine("r / n: Couleur rouge ou noire (gain = 100% de la mise)");
            Console.WriteLine("i / p: Numéro impair ou pair (gain = 100% de la mise)");
            Console.WriteLine("x: Un numéro précis (gain = 3500% de la mise)");

            while (!opt.Contains(choixCombi))
                choixCombi = Console.ReadLine().ToLower();

            Console.WriteLine("Combien de jetons misez-vous (max {0})?", _nbJetonsActuel);
            while (miseJetons < 1 || miseJetons > _nbJetonsActuel)
                while (!int.TryParse(Console.ReadLine(), out miseJetons)) ;

            switch (choixCombi)
            {
                case "24p":
                    combi |= Combinaisons.Premiers24;
                    coefGain = 0.5;
                    break;
                case "24d":
                    combi |= Combinaisons.Derniers24;
                    coefGain = 0.5;
                    break;
                case "r":
                    combi |= Combinaisons.Rouge;
                    break;
                case "n":
                    combi |= Combinaisons.Noir;
                    break;
                case "i":
                    combi |= Combinaisons.Impair;
                    break;
                case "p":
                    combi |= Combinaisons.Pair;
                    break;
                case "x":
                    Console.WriteLine("Choisissez un nombre entre 1 et 36:");
                    int tmp = 0;
                    while (tmp < 1 || tmp > 36)
                        while (!int.TryParse(Console.ReadLine(), out tmp)) ;
                    nbMisé = tmp;
                    coefGain = 35;
                    break;
                default:
                    break;
            }

            mise = new Mise(nbMisé, combi, miseJetons);
            mise.CoefGain = coefGain;
        }

        /// <summary>
        /// Affiche le résultat de la mise par rapport au lancé.
        /// </summary>
        /// <param name="lancé"></param>
        /// <param name="mise"></param>
        private void AfficherRésultat(Lancé lancé, Mise mise)
        {
            Console.WriteLine(lancé.GetResultatTexte());

            if (lancé.CorrespondA(mise.Pari))
            {
                mise.Gagnante = true;
                _nbJetonsActuel += (int) (mise.Gain * mise.CoefGain);
            }
            else
            {
                mise.Gagnante = false;
                _nbJetonsActuel -= mise.Gain;
            }
            mise.NbJetons = _nbJetonsActuel;

            Console.WriteLine(mise.GetResultatTexte());
        }

        /// <summary>
        /// Demande à l'utilisateur si il souhaite continuer à jouer.
        /// </summary>
        /// <returns></returns>
        private bool SaisirContinuation()
        {
            Console.WriteLine("Souhaitez-vous continuer (O/N)?");
            string res;
            while (true)
            {
                res = Console.ReadLine().ToLower();
                switch (res)
                {
                    case "o":
                        Console.Clear();
                        return true;
                    case "n":
                        return false;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Affiche les statistiques de jeu de l'utilisateur.
        /// </summary>
        private void AfficherStats()
        {
            Console.WriteLine("{0} mise(s) réalisée(s) dont {1} gagnée(s) et {2} perdue(s).", Mise.Compteur, Mise.PartiesGagnées, Mise.Compteur - Mise.PartiesGagnées);
            Console.WriteLine("Nombre de jetons initial : {0}", _nbJetonsInitial);
            Console.WriteLine("Nombre de jetons final : {0} ({1}{2})", _nbJetonsActuel, _nbJetonsActuel > _nbJetonsInitial ? "+" : "", _nbJetonsActuel - _nbJetonsInitial);
            Console.WriteLine("Merci d'avoir joué.");
        }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Lance le jeu de la roulette.
        /// </summary>
        public void Jouer()
        {
            Mise mise;
            Lancé lancé;
            bool continuer;

            SaisirNbJetonsInit();

            do
            {
                continuer = false;
                SaisirMise(out mise);
                lancé = _roulette.LancéBille();
                AfficherRésultat(lancé, mise);
                if (_nbJetonsActuel > 0)
                    continuer = SaisirContinuation();
            } while (continuer);

            AfficherStats();
        }
        #endregion

    }

    public class Roulette
    {
        #region Champs privés
        private Random _rnd;
        // private Lancé _lancé;
        #endregion

        #region Constructeurs
        public Roulette()
        {
            _rnd = new Random();
        }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Lance la bille dans la roulette. Renvoi le lancé obtenu.
        /// </summary>
        /// <returns></returns>
        public Lancé LancéBille()
        {
            int res = _rnd.Next() % 36;
            if (res == 0)
                res = 36;

            Combinaisons combi = Combinaisons.Aucune;

            if (EstRouge(res))
                combi |= Combinaisons.Rouge;
            else
                combi |= Combinaisons.Noir;

            if (res % 2 == 0)
                combi |= Combinaisons.Pair;
            else
                combi |= Combinaisons.Impair;

            if (res < 25)
                combi |= Combinaisons.Premiers24;
            else
                combi |= Combinaisons.Derniers24;

            return new Lancé(res, combi);
        }

        /// <summary>
        /// Renvoi vrai si le nombre est rouge, faux sinon.
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        static public bool EstRouge(int nb)
        {
            int[] nbRouges = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            return nbRouges.Contains(nb);
        }
        #endregion
    }

    public class Lancé
    {
        #region Propriétés
        public int? Numéro { get; }
        public Combinaisons Combinaison { get; }
        #endregion

        #region Constructeurs
        public Lancé(int? nb, Combinaisons combi)
        {
            Numéro = nb;
            Combinaison = combi;
        }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Renvoi vrai si le lancé passé en paramètre correspond au lancé appelant la méthode.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool CorrespondA(Lancé l)
        {
            if (l.Combinaison == Combinaisons.Aucune)
                return Numéro == l.Numéro;
            else
                return (Combinaison & l.Combinaison) == l.Combinaison;
        }

        /// <summary>
        /// Renvoi un string contenant le résultat du lancé.
        /// </summary>
        /// <returns></returns>
        public string GetResultatTexte()
        {
            string aff = string.Format("{0} et {1}", Roulette.EstRouge((int)Numéro) ? "rouge" : "noir", Numéro % 2 == 0 ? "pair" : "impair");          
            return string.Format("La bille est tombée sur le N°{0}, qui est {1}.", Numéro, aff);
        }
        #endregion
    }

    public class Mise
    {
        #region Champs privés
        private bool _gagnante;
        #endregion

        #region Propriétés
        public Lancé Pari { get; }
        public int Gain { get; }
        public int NbJetons { get; set; }
        public bool Gagnante
        {
            get { return _gagnante; }
            set
            {
                _gagnante = value;
                if (_gagnante)
                    PartiesGagnées++;
            }
        }
        public double CoefGain { get; set; }
        public static int Compteur { get; private set; }
        public static int PartiesGagnées { get; private set; }
        #endregion

        #region Constructeurs
        public Mise()
        {
            Compteur++;
        }

        /// <summary>
        /// Créé une instance de Mise
        /// </summary>
        /// <param name="nb">Nombre sur lequel la mise a été effectué (peut être nul)</param>
        /// <param name="combi">Combinaison sur laquelle la mise a été effectuée</param>
        /// <param name="mise">Valeur de la mise</param>
        public Mise(int? nb, Combinaisons combi, int mise) : this()
        {
            Pari = new Lancé(nb, combi);
            Gain = mise;
        }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Renvoi le résultat de la mise.
        /// </summary>
        /// <returns></returns>
        public string GetResultatTexte()
        {
            string res;
            res = string.Format("Vous {0} {1} jetons. ", Gagnante ? "gagnez" : "perdez", Gagnante ? (int) (Gain * CoefGain) : Gain);
            if (NbJetons > 0)
                res += string.Format("Vous possédez désormais {0} jetons.", NbJetons);
            else
                res += "Il ne vous reste plus aucun jeton.";

            return res;
        }
        #endregion
    }
}
