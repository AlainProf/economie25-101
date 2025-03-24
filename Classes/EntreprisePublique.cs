using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.Classes
{
    internal class EntreprisePublique:Entreprise
    {
        public double ValUnitaire {  get; set; }    
        public long NbActions {  get; set; } 

        public EntreprisePublique(int id, string rs, string d, string af, double valU, long nbA ):
            base(id,rs,d,af)        {
            ValUnitaire = valU;
            NbActions = nbA;
        }

    }
}
