using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servi_urbe
{
    class FactionB : Factions
    {
        public FactionB()
        {
            Name = "Geselle";
            Bonus = 20;
        }
        public override void ActivateBonus()
        {
            Hospital.HospitalPrice = 60;
            Restaurant.RestaurantPrice = 40;
            Sport.SportPrice = 60;
            Job.Verdienst = 1 * Player.Fun / 10 * Player.Level + Player.Respect + this.Bonus;

        }
    }
}
