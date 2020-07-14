using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servi_urbe
{
    class FactionC : Factions
    {
        public FactionC()
        {
            Name = "Meister";
            Bonus = 50;
        }

        public override void ActivateBonus()
        {
            Hospital.HospitalPrice = 1000;
            Restaurant.RestaurantPrice = 320;
            Sport.SportHungerPrice = 9;
            Sport.SportPrice = 150;
            Sport.SportLifePrice = 7;
            Job.JobHungerPrice = 12;
            Job.JobLebensPrice = 9;
            Job.JobSpaßPrice = 25;
        }
    }
}
