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

        static int _idMax = 0;  

        public Entreprise(int i=0, string rs= "", string d="", string af="")
        {
            Id = i;
            if (Id > _idMax)
            {
                _idMax = Id;
            }
            RaisonSociale = rs;
            Domaine = d;
            AnneeFondation = af;

            Personnel = new List<Employe>();
        }
        public Entreprise(string rs, string d, string af)
        {
            _idMax++;
            Id = _idMax;
            RaisonSociale = rs;
            Domaine = d;
            AnneeFondation = af;

            Personnel = new List<Employe>();
        }

        public void Afficher(bool tabulaire = true )
        {
            if (tabulaire)
            {
                U.WL($"{Id.ToString().PadLeft(5)} {RaisonSociale.PadRight(40)}{Domaine.PadRight(20)}{AnneeFondation.PadLeft(5)}");
            }
            else
            {
                U.WL($"Raison sociale   :\t{RaisonSociale}");
                U.WL($"Secteur          :\t{Domaine}");
                U.WL($"Fondée en        :\t{AnneeFondation}");
                U.WL($"Nombre d'employés: \t{Personnel.Count}");

                U.W("Voulez la liste des employés?(o/n)");
                char rep = U.RC();
                if (rep == 'o')
                {
                    foreach(Employe e in Personnel)
                    {
                        e.Afficher();   
                    }
                }
            }
        }

        public void VentilerPersonnel()
        {
            if (Program.Travailleurs is not null)
            {
                foreach (Employe employe in Program.Travailleurs)
                {
                    if (employe.IdEntreprise == Id)
                        Personnel.Add(employe);
                }
            }
        }
    }
}
