using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.Classes
{
    internal class FeuilleTemps
    {
        int _id;
        int _idEmploye;
        public int getIdEmploye()
        {
            return _idEmploye;  
        }

        public int NbHeures { get; set; }
        public int Periode { get; set; }

        public FeuilleTemps()
        {
            _id = 0;
            _idEmploye = 0;
            NbHeures = 0;
            Periode = -1;
        }
        public FeuilleTemps(int id, int idEmploye, int periode,int nbHeures)
        {
            _id = id;
            _idEmploye = idEmploye;
            NbHeures = nbHeures;
            Periode = periode;
        }
    }
}
