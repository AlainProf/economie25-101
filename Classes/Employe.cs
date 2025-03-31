using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.Classes
{
    internal class Employe:Humain
    {
        public int Id {  get; set; }    
        public int IdEntreprise {  get; set; }  

        public Employe() {
            Nom = "inconnu";
            Naissance = DateTime.MinValue;
            Sexe = "f";
            Id = 0;
            IdEntreprise = 0;   
        }    
        public Employe(int id, int idEntrep, string n, string g, DateTime nais):
            base(n,nais, g)
        {
            Id = id;    
            IdEntreprise = idEntrep;    
        }
    }
}
