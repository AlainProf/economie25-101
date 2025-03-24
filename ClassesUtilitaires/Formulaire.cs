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


            Entreprise e = new(rs, dom, af);
            if (Program.Producteurs is not null)
            {
                Program.Producteurs.Add(e);
            }


            U.P($"{e.RaisonSociale} a bien été ajouté en mémoire");
        }
    }
}
