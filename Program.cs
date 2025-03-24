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

            mp.AjouterOption(new('C', "Charger entreprises", Chargement.ChargerEntreprises));
            mp.AjouterOption(new('A', "Afficher entreprises", AfficherEntreprises));
            mp.AjouterOption(new('V', "Valeurs en bourse ", AfficherValeursBoursieres));
            mp.AjouterOption(new('T', "Valeurs en bourse triées", AfficherValeursBoursieresTriees));
            mp.AjouterOption(new('P', "PNB du Québec ", CalculerPNB));
            mp.AjouterOption(new('I', "inserer entreprise ", Formulaire.NouvelleEntreprise));
            mp.AjouterOption(new('D', "Décharger liste en BD", GestionnaireBD.DechargerListeEntreprises));

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
                U.Titre($"{"Id".PadLeft(5)} {"Raison Sociale".PadRight(40)}{"Secteur".PadRight(20)}{"Fondé en".PadLeft(5)}");
                foreach (Entreprise e in Producteurs)
                {
                    e.Afficher();
                }

            }
            U.P();
        }

        
        static void AfficherValeursBoursieresTriees()
        {
            U.Titre("Valeurs boursières triées");
            if (Producteurs == null || Producteurs.Count == 0)
                U.WL("Aucune entreprise n'est chargée en mémoire");
            else
            {
                List<EntreprisePublique> lep = new();
                
                
                U.Titre($"{"Nom de l'entrep publique".PadRight(40)}{"Valeur en million $".PadRight(20)}");
                foreach (Entreprise e in Producteurs)
                {
                    if (e is EntreprisePublique)
                    {
                        EntreprisePublique? ep = e as EntreprisePublique;
                        if (ep != null) 
                           lep.Add(ep);
                    }
                }
                lep.Sort(CompareValeur);
                foreach(EntreprisePublique ep in lep)
                {
                    double capBourse = ep.ValUnitaire * (double)ep.NbActions;
                    U.WL($"{ep.RaisonSociale.PadRight(40)} {(capBourse/1000000).ToString("N2").PadLeft(20)}");
                }
            }
            U.P();
        }

        static int CompareValeur(EntreprisePublique eA, EntreprisePublique eB)
        {
            if ((eA.ValUnitaire * eA.NbActions) > (eB.ValUnitaire * eB.NbActions))
            {
                return -1;
            }
            if ((eA.ValUnitaire * eA.NbActions) < (eB.ValUnitaire * eB.NbActions))
            {
                return 1;
            }
            return 0;
        }

       static void AfficherValeursBoursieres()
        {
            U.Titre("Valeurs boursières des entreprises publiques");
            if (Producteurs == null || Producteurs.Count == 0)
                U.WL("Aucune entreprise n'est chargée en mémoire");
            else
            {
                U.Titre($"{"Nom de l'entrep publique".PadRight(40)}{"Valeur en bourse".PadRight(20)}");
                foreach (Entreprise e in Producteurs)
                {
                    if (e is EntreprisePublique)
                    {
                        EntreprisePublique? ep = e as EntreprisePublique;
                        if (ep != null)
                        {
                            double capBourse = ep.ValUnitaire * (double)ep.NbActions;
                            U.WL($"{ep.RaisonSociale.PadRight(40)} {capBourse.ToString("N2").PadLeft(20)}");
                        }
                    }
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
