using System.Text;
namespace M2_ClassesAffaire
{
    public class Livre
    {
        // Propriétés
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Editeur { get; set; }

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

        public int Annee { get; set; }

        // Constructeur
        public Livre(string titre, string auteur, string editeur, int nombreDePages, int annee)
        {
            Titre = titre;
            Auteur = auteur;
            Editeur = editeur;
            NombreDePages = nombreDePages; // Utilise le set, donc vérification automatique
            Annee = annee;
        }

        // Méthode ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Titre : {Titre}");
            sb.AppendLine($"Auteur : {Auteur}");
            sb.AppendLine($"Éditeur : {Editeur}");
            sb.AppendLine($"Nombre de pages : {NombreDePages}");
            sb.AppendLine($"Année : {Annee}");
            return sb.ToString();
        }
    }
}


