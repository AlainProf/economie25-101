using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.Classes
{
    internal class EmpHoraire : Employe
    {
        public double TauxHoraire { get; set; } 

        public EmpHoraire()
        {
            TauxHoraire = 15.75;
        }
        //[0] idEmp; [1] idEntrep ; [2] Nom [3] Genre; [4] naissance [5] 55,77
        public EmpHoraire(int id, int idEntrep, string n, string g, DateTime nais, double th ):
            base(id, idEntrep, n, g, nais)
        {
            TauxHoraire = th;
        }

        public override void Afficher()
        {
            U.WL($"{Nom} {TauxHoraire}");
        }
    }
}
