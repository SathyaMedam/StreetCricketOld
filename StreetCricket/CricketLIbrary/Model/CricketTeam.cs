using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketLIbrary.Model
{
    public class CricketTeam:Team
    {
        public int TeamInningsNumber { get; set; }
        public List<CricketPlayer> Players { get; set; }
        public bool IsHomeTeam { get; set; }
        public CricketTeam(Team team)
        {
            this.Id = team.Id;
            this.Name = team.Name;
            this.Venue = team.Venue;
            if (team.Venue==Venue.Home)
            {
                IsHomeTeam = true;
            }
            Players = new List<CricketPlayer>();
        }
    }
}
