using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servi_urbe
{
    
    abstract class Factions
    {
        public string Name { get; set; }
        public int Bonus { get; set; }

        
        public abstract void ActivateBonus();
      
    }

}
