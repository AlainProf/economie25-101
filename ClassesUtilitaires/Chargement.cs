using Economie25_101;
using Economie25_101.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Economie25_101.ClassesUtilitaires
{
    internal class Chargement
    {
        public static void ChargerEntreprises()
        {
            U.Titre("Chargement des entreprises en mémoires");
            if (Program.Producteurs == null)
            {
                return;
            }
            if (File.Exists(U.FICHIER_ENTREPRISE))
            {
                StreamReader? reader = new StreamReader(U.FICHIER_ENTREPRISE);
                string? ligneCourante;
                int iter = 0;
                while (reader.Peek() > -1)
                {
                    iter++;
                    ligneCourante = reader.ReadLine();
                    if (ligneCourante == null)
                        continue;
                    if (ParsingEntreprise(ligneCourante, out Entreprise e, out string msgErr))
                    {
                        Program.Producteurs.Add(e);
                    }
                    else
                    {
                        Console.WriteLine($"Erreur à la ligne {iter}: {msgErr} ");
                    }
                }
                reader.Close();
                Console.WriteLine($"Chargement de {Program.Producteurs.Count} entreprises");
            }
            else
            {
                Console.WriteLine($"Erreur: le fichier {U.FICHIER_ENTREPRISE} n'existe pas");
            }
            U.P();
        }

        private static bool ParsingEntreprise(string infoBrute, out Entreprise e, out string msgErr)
        {
            e = new Entreprise();
            msgErr = "";

            if (infoBrute == null)
                return false;

            int iter = 0;
            int nbChamps = CompterChamps(infoBrute);
            // Entreprises générale ont 4 champs
            if (nbChamps == 4)
            {
                iter++;
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderEntreprise(tabInfo, out string errValidation))
                {
                    e = new Entreprise(int.Parse(tabInfo[0]),
                                      tabInfo[1],
                                      tabInfo[2],
                                      tabInfo[3]);
                    return true;
                }
                else
                {
                    msgErr = $"Information corrompue: {errValidation}";
                }
                msgErr = "Nombre de champs incorrect";
            }

            // Entrerpiaes publiques ont 6 champs
            if (nbChamps == 6)
            {
                iter++;
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderEntreprise(tabInfo, out string errValidation))
                {
                    e = new EntreprisePublique(
                                      int.Parse(tabInfo[0]),
                                      tabInfo[1],
                                      tabInfo[2],
                                      tabInfo[5],
                                      double.Parse(tabInfo[3]),
                                      long.Parse(tabInfo[4]));
                    return true;
                }
                else
                {
                    msgErr = $"Information corrompue: {errValidation}";
                }
                msgErr = "Nombre de champs incorrect";
            }
            return false;
        }




        public static void ChargerEmployes()
        {
            U.Titre("Chargement des travailleurs en mémoires");
            if (Program.Travailleurs == null)
            {
                return;
            }
            if (File.Exists(U.FICHIER_EMPLOYES))
            {
                StreamReader? reader = new StreamReader(U.FICHIER_EMPLOYES);
                string? ligneCourante;
                int iter = 0;
                while (reader.Peek() > -1)
                {
                    iter++;
                    ligneCourante = reader.ReadLine();
                    if (ligneCourante == null)
                        continue;
                    if (ParsingEmploye(ligneCourante, out Employe e, out string msgErr))
                    {
                        Program.Travailleurs.Add(e);
                    }
                    else
                    {
                        Console.WriteLine($"Erreur à la ligne {iter}: {msgErr} ");
                    }
                }
                reader.Close();
                U.P($"Chargement de {Program.Travailleurs.Count} travailleurs");

                U.W("Voulez vous vnetiler les employés dans leurs entreprises respectives? (o/n)");
                char rep = U.RC();
                if (rep == 'o')
                {
                    VentilationDesEmployes();
                }
            }
            else
            {
                Console.WriteLine($"Erreur: le fichier {U.FICHIER_EMPLOYES} n'existe pas");
            }
        }

        private static bool ParsingEmploye(string infoBrute, out Employe e, out string msgErr)
        {
            e = new Employe();
            msgErr = "";

            if (infoBrute == null)
                return false;

            int iter = 0;
            int nbChamps = CompterChamps(infoBrute);
       

            if (nbChamps == 6)
            {
                iter++;
                string[] tabInfo = infoBrute.Split(';');
                if (ValiderEmploye(tabInfo, out string errValidation))
                {
                    //[0] idEmp; [1] idEntrep ; [2] Nom [3] Genre; [4] naissance [5] 55,77

                    DateTime nais;
                    if (DateTime.TryParseExact(tabInfo[4], "yyyy-MM-dd", null,
                                               System.Globalization.DateTimeStyles.None, out nais))
                    {
                        e = new EmpHoraire(int.Parse(tabInfo[0]),
                                           int.Parse(tabInfo[1]),
                                           tabInfo[2],
                                           tabInfo[3],
                                           nais,
                                           double.Parse(tabInfo[5]));
                        return true;
                    }
                    return false;
                }
                else
                {
                    msgErr = $"Information corrompue: {errValidation}";
                }
                msgErr = "Nombre de champs incorrect";
            }
            return false;
        }









        //------------------------------------------
        //
        //------------------------------------------
        private static int CompterChamps(string info)
        {
            if (info.Length == 0)
                return 0;

            int nbChamps = 1;
            foreach (char ch in info)
            {
                if (ch == ';')
                    nbChamps++;
            }
            return nbChamps;
        }

        private static bool ValiderEntreprise(string[] tabInfo, out string errValidation)
        {
            errValidation = "";
            return true;
        }
        private static bool ValiderEmploye(string[] tabInfo, out string errValidation)
        {
            errValidation = "";
            return true;
        }

        public static void ViderListeEntreprises()
        {
            U.Titre("Vidage de la liste mémoire des entreprises...");
            if (Program.Producteurs is not null && Program.Producteurs.Count > 0)
            {
                Program.Producteurs.Clear();
                U.P("La liste est maintenant vide");
            }
            else
            {
                U.P("La liste était déjà vide...");
            }
        }

        static void VentilationDesEmployes()
        {
            if (Program.Producteurs is not null)
            {
                foreach (Entreprise e in Program.Producteurs)
                {
                    e.VentilerPersonnel();
                }
            }
        }
    }
}