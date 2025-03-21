using Economie25_101.Classes;
using Economie25_101.ClassesUtilitaires;

namespace Economie25_101
{
    
    internal class Program
    {
        static public List<Entreprise>? Producteurs { get; set; } = new List<Entreprise>();
        static void Main(string[] args)
        {
            U.Titre("Analyse de l'économie québécoise!");
            Menu mp = new("Menu principal");

            MenuItem item = new('C', "Charger entreprises", Chargement.ChargerEntreprises);
            mp.AjouterOption(item);
            item = new('A', "Afficher entreprises", AfficherEntreprises);
            mp.AjouterOption(item);
            item = new('P', "PNB du Québec ", CalculerPNB);
            mp.AjouterOption(item);

            mp.Afficher();
            mp.SaisirOption();

            /*Entreprise e1 = new Entreprise(1, "Gildan", "textiles");
            e1.Afficher();
            Entreprise e2 = new Entreprise(2, "Couche Tard", "commerce");
            e2.Afficher();*/
        }

        static void AfficherEntreprises()
        {
            U.Titre("Les entreprises du Québéc");
            if (Producteurs == null || Producteurs.Count == 0)
                U.WL("Aucune entreprise n'est chargée en mémoire");
            else
            {
                foreach (Entreprise e in Producteurs)
                {
                    e.Afficher();
                }

            }
            U.P();
        }
        static void CalculerPNB()
        {
            U.Titre("Le PNB du Québéc");
            U.P();
        }
    }
}
