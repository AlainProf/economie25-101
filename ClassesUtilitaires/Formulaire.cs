using Economie25_101.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.ClassesUtilitaires
{
    internal class Formulaire
    {
        static Entreprise eTmp = new Entreprise();
        public static void NouvelleEntreprise()
        {
            U.Titre("Ajouter une entreprise");

            U.W("Raison sociale:");
            string? rs = U.RL();
            if (rs == null)
            {
                rs = "";
            }

            U.W("Secteur:");
            string? dom = U.RL();
            if (dom == null)
            {
                dom = "";
            }

            U.W("Fondée en :");
            string? af = U.RL();
            if (af == null)
            {
                af = "";
            }

            U.W("S'agit-il d'une entreprise côtée en bourse? (O/N)");
            char rep = U.RC();

            while (rep != 'O' && rep != 'o' && rep != 'N' && rep != 'n' )
            {
                rep = U.RC();
            }
            U.WL();
            if (rep == 'o' || rep == 'O')
            {
                U.W("Valeur de l'action :");
                string? va = U.RL();

                double valAct = 0;
                if (va != null)
                {
                    valAct = double.Parse(va);
                }
               

                U.W("Nombre d'actions:");
                string? na = U.RL();
                int nbrAct = 0;
                if (na != null)
                {
                    nbrAct = int.Parse(na);
                }
                EntreprisePublique ep = new(rs, dom, valAct, nbrAct, af);
                if (Program.Producteurs is not null)
                {
                    Program.Producteurs.Add(ep);
                }
                U.P($"{ep.RaisonSociale} a bien été ajouté en mémoire");

            }
            else
            {
                Entreprise e = new(rs, dom, af);
                if (Program.Producteurs is not null)
                {
                    Program.Producteurs.Add(e);
                }
                U.P($"{e.RaisonSociale} a bien été ajouté en mémoire");
            }
        }

        public static void ModifierEntreprise()
        {
            U.Titre("Modification d'une entreprise");

            U.W("Id:");
            string? idEntrepAMod = U.RL();

            if (idEntrepAMod != null)
            {
                int idEAMod = int.Parse(idEntrepAMod);
                Entreprise? entrepAMod = TrouverEntreprise(idEAMod);

                if (entrepAMod != null)
                {
                    eTmp = entrepAMod;  
                    eTmp.Afficher(false);
                    FormulaireModificationEntreprise(eTmp);
                }



                U.P("Informations bien modifiées");
            }

            static Entreprise? TrouverEntreprise(int id)
            {
                if (Program.Producteurs != null && Program.Producteurs.Count > 0)
                {
                    foreach (Entreprise e in Program.Producteurs)
                    {
                        if (e.Id == id)
                        {
                            return e;
                        }
                    }
                }
                else
                {
                    U.P("Malheureusement la liste des entreprise est vide...");
                }
                return null;
            }

           
            static void FormulaireModificationEntreprise(Entreprise e)
            {
                //U.Titre($"Modification de {e.RaisonSociale}");

                Menu mFME = new("Quel champs voulez vous modifier:");

                mFME.AjouterOption(new('1', "raison sociale", ModifierRS));
                mFME.AjouterOption(new('2', "secteur", ModifierDom));
                mFME.AjouterOption(new('3', "année de fondation", ModifierAF));
                mFME.AjouterOption(new('q', "Modifications complétées", Quitter));

                mFME.Afficher(false);
                mFME.SaisirOption();

                ModifierEntreprise();

            }


            static void ModifierRS()
            {
                U.W("Raison sociale:");
                string? rs = U.RL();
                if (rs == null)
                {
                    rs = "";
                }
                else
                {
                    eTmp.RaisonSociale = rs;
                }
            }

            static void ModifierDom()
            {

                U.W("Secteur:");
                string? dom = U.RL();
                if (dom == null)
                {
                    dom = "";
                }
            }
            static void ModifierAF()
            {
                U.W("Fondée en :");
                string? af = U.RL();
                if (af == null)
                {
                    af = "";
                }
            }
            static void Quitter()
            {
                U.Sep("Sauvegarde des modif:");
                eTmp.Afficher(false);
                U.P();
            }

            /*  U.W("S'agit-il d'une entreprise côtée en bourse? (O/N)");
              char rep = U.RC();

              while (rep != 'O' && rep != 'o' && rep != 'N' && rep != 'n')
              {
                  rep = U.RC();
              }
              U.WL();
              if (rep == 'o' || rep == 'O')
              {
                  U.W("Valeur de l'action :");
                  string? va = U.RL();

                  double valAct = 0;
                  if (va != null)
                  {
                      valAct = double.Parse(va);
                  }


                  U.W("Nombre d'actions:");
                  string? na = U.RL();
                  int nbrAct = 0;
                  if (na != null)
                  {
                      nbrAct = int.Parse(na);
                  }
                  EntreprisePublique ep = new(rs, dom, valAct, nbrAct, af);
                  if (Program.Producteurs is not null)
                  {
                      Program.Producteurs.Add(ep);
                  }
                  U.P($"{ep.RaisonSociale} a bien été ajouté en mémoire");

              }
              else
              {
                  Entreprise e = new(rs, dom, af);
                  if (Program.Producteurs is not null)
                  {
                      Program.Producteurs.Add(e);
                  }
                  U.P($"{e.RaisonSociale} a bien été ajouté en mémoire");
              }*/

        }

    }
}
