using Economie25_101.Classes;
using Economie25_101.ClassesUtilitaires;

namespace Economie25_101
{
    
    internal class Program
    {
        static public List<Entreprise>? Producteurs { get; set; } = new List<Entreprise>();
        static public List<Employe>? Travailleurs { get; set; } = new();
        static public List<FeuilleTemps>? Horodateurs { get; set; } = new();       
        static void Main(string[] args)
        {
            Chargement.ChargerEntreprises();
            Chargement.ChargerEmployes();
            Chargement.ChargerFeuillesTemps();

            U.Titre("Analyse de l'économie québécoise!");
            Menu mp = new("Menu principal");

            //            mp.AjouterOption(new('C', "Charger entreprises", Chargement.ChargerEntreprises));
            //            mp.AjouterOption(new('E', "Charger Employés ", Chargement.ChargerEmployes));
            mp.AjouterOption(new('C', "Calculer la Paye pour une entreprise", CalculerLaPaye));
            mp.AjouterOption(new('S', "Vider liste entreprises en mémoire", Chargement.ViderListeEntreprises));
            mp.AjouterOption(new('A', "Afficher entreprises", AfficherEntreprises));
            mp.AjouterOption(new('U', "Afficher une entreprise", AfficherUneEntreprise));
            mp.AjouterOption(new('V', "Valeurs en bourse ", AfficherValeursBoursieres));
            mp.AjouterOption(new('T', "Valeurs en bourse triées", AfficherValeursBoursieresTriees));
            mp.AjouterOption(new('P', "PNB du Québec ", CalculerPNB));
            mp.AjouterOption(new('I', "inserer entreprise ", Formulaire.NouvelleEntreprise));
            mp.AjouterOption(new('M', "Modifier entreprise ", Formulaire.ModifierEntreprise));
            mp.AjouterOption(new('D', "Décharger liste en BD", GestionnaireBD.DechargerListeEntreprises));

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
                U.Titre($"{"Id".PadLeft(5)} {"Raison Sociale".PadRight(40)}{"Secteur".PadRight(20)}{"Fondé en".PadLeft(7)}{"Nb Emplo".PadLeft(7)}");
                foreach (Entreprise e in Producteurs)
                {
                    e.Afficher();
                }

            }
            U.P();
        }

        static void AfficherUneEntreprise()
        {
            U.Titre("Info pour une entreprise");
            string? idEntrepStr;
            int idEntrep;

            U.W("ID:");
            idEntrepStr = U.RL();

            if (idEntrepStr is not null)
            {
                idEntrep = int.Parse(idEntrepStr);
                if (Producteurs is not null)
                {
                    foreach (Entreprise? e in Producteurs)
                    {
                        if (e.Id == idEntrep)
                        {
                            e.Afficher(false);
                        }
                    }
                }
            }
            U.P() ;
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
        static void CalculerLaPaye()
        {
            U.Titre("Calcul de la paye");
            string? idEntrepStr;
            U.W("Id de l'entreprise:");
            idEntrepStr = U.RL();
            int idEntrep = 0;
            if (idEntrepStr is not null)
            {
                idEntrep = int.Parse(idEntrepStr);
            }

            U.W("numéro de période:");
            string? idPeriodeStr;
            idPeriodeStr = U.RL();
            int periode = 0;
            if (idPeriodeStr is not null)   
               periode = int.Parse(idPeriodeStr);

            if (Producteurs is not null)
            {
                foreach (Entreprise? e in Producteurs)
                {
                    if (e.Id == idEntrep)
                    {
                        foreach (Employe emp in e.Personnel)
                        {
                            if (Horodateurs is not null)
                            {
                                foreach (FeuilleTemps? ft in Horodateurs)
                                {
                                    if (ft.Periode == periode)
                                    {
                                        if (ft.getIdEmploye() == emp.Id)
                                        {
                                            if (emp is EmpHoraire)
                                            {
                                                EmpHoraire? empH = emp as EmpHoraire;
                                                if (empH != null)
                                                {
                                                    double paye = empH.TauxHoraire * ft.NbHeures;
                                                    U.WL($"{empH.Id.ToString().PadLeft(6)} {empH.Nom.PadLeft(40)} {paye.ToString("N2").PadLeft(12)}$");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
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
