using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.Classes
{
    internal class Entreprise
    {
        public int Id { get; set; } 
        public string RaisonSociale {  get; set; }
        
        public string Domaine {  get; set; }
        
        public string AnneeFondation {  get; set; } 
        public List<Employe> Personnel { get; set;} 

        public Entreprise(int i =0, string rs = "inconnu", string d = "inconnu", string af="1608" )
        {
            Id = i;
            RaisonSociale = rs; 
            Domaine = d;  
            AnneeFondation = af;    
            
            Personnel = new List<Employe>();    
        }
        
        public void Afficher()
        {
            U.WL($"{RaisonSociale}, entreprise de {Domaine} qui emploie {Personnel.Count} travailleurs");
        }
    }
}
