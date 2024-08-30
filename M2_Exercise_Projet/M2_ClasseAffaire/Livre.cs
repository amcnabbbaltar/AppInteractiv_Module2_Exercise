using System.Text;
namespace M2_ClassesAffaire
{
    public class Livre : IComparable<Livre>
    {
        // Propriétés
        public string Titre { get; private set; }
        public string Auteur { get; private set; }
        public string Editeur { get; private set; }
        
        private int _nombreDePages;
        public int NombreDePages
        {
            get { return _nombreDePages; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Le nombre de pages doit être supérieur à 0.");
                }
                _nombreDePages = value;
            }
        }

        public int Annee { get; private set; }

        // Constructeur
        public Livre(string titre, string auteur, string editeur, int nombreDePages, int annee)
        {
            if (nombreDePages <= 0)
            {
                throw new ArgumentException("Le nombre de pages doit être supérieur à 0.");
            }

            Titre = titre;
            Auteur = auteur;
            Editeur = editeur;
            NombreDePages = nombreDePages;
            Annee = annee;
        }

        // Implémentation de la méthode CompareTo pour trier par titre
        public int CompareTo(Livre autreLivre)
        {
            if (autreLivre == null) return 1;
            return this.Titre.CompareTo(autreLivre.Titre);
        }

        // Méthode ToString()
        public override string ToString()
        {
            return $"Titre : {Titre}, Auteur : {Auteur}, Éditeur : {Editeur}, Nombre de pages : {NombreDePages}, Année : {Annee}";
        }
    }

}


