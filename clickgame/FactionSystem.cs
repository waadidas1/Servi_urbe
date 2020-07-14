using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servi_urbe
{
    class FactionSystem
    {
        // wenns n bug gibt neue eigenschaft zu Player hinzufügen (is in group) vom typ bool
        public static void JoinFaction(Factions faction)
        {
            if(IsPlayerInFaction(faction) == 2)
            {
                Player.Factions.Add(faction);
                faction.ActivateBonus();
                
            }
            else if (IsPlayerInFaction(faction) == 1)
            {
                MessageBox.Show("Du bist bereits in dieser Fraktion");
            }else if (IsPlayerInFaction(faction) == 3)
            {
                MessageBox.Show("Du bist bereits in einer anderen Fraktion");

            }

        }

        public static void LeaveFaction(Factions faction)
        {
            if(IsPlayerInFaction(faction) == 1)
            {
                Player.Factions.Remove(faction);
                ResetStats();
                
            }
            else
            {
                MessageBox.Show("Du bist nicht in dieser Fraktion.");
            }
        }
        public static byte IsPlayerInFaction(Factions faction)
        {// eins ist ja
            // zwei ist nein
            // drei ist nein aber in einer anderen
            foreach(Factions factions in Player.Factions)
            {
                if (Player.Factions.Count > 0)
                {
                    if (factions == faction)
                    {
                        return 1;
                    }
                    return 3;
                }

            }
            return 2;
    
        }

        public static void ResetStats()
        {
            Job.JobLebensPrice = 10;
            Job.JobHungerPrice = 20;
            Job.JobSpaßPrice = 15;
            Hospital.HospitalPrice = 10;
            Restaurant.RestaurantPrice = 10;
            Sport.SportPrice = 10;
            Sport.SportHungerPrice = 10;
            Sport.SportLifePrice = 10;
        }
    }

}
