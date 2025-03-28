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
    }
}