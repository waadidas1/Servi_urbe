using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Servi_urbe
{
    class FactionA : Factions
    {
        public FactionA()
        {
            Name = "Azubi";
            Bonus = 10;

            
            

            
        }
       

        public override void ActivateBonus()
        {
            Hospital.HospitalPrice = 7;
            Sport.SportHungerPrice = 20;
            Job.JobLebensPrice = 8;

        }
        

    }
}
