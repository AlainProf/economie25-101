using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.ClassesUtilitaires
{
    internal class MenuItem
    {
        public char Cle {  get; set; }
        public string Item {  get; set; }   
        public Action Execution { get; set; }
        public MenuItem(char c, string i, Action exec) 
        {
            Cle = c;
            Item= i;
            Execution = exec;   
        }   
    }
}
