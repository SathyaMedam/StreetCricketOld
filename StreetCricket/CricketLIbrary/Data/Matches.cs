using System.Collections.Generic;
using System.Xml;
using CricketLIbrary.Model;
namespace CricketLIbrary.Data
{
    public class Matches
    {
        public List<Match> MatchList { get; set; }

        public Matches()
        {
            var player=new Player
            {
               Id=1,
                Name = "Sathya",
                TeamId = 1

            };
            var player1 = new Player
            {
                Id = 2,
                Name = "Baz",
                TeamId = 1

            };
            var player2 = new Player
            {
                Id = 3,
                Name = "Voke",
                TeamId = 1

            };
            var player5 = new Player
            {
                Id = 5,
                Name = "Jamie",
                TeamId = 2

            };
            var player3 = new Player
            {
                Id = 4,
                Name = "Simmo",
                TeamId = 2

            };
            var player4 = new Player
            {
                Id = 6,
                Name = "Rob",
                TeamId = 2

            };
            var homePlayer=new List<Player> {player,player1,player2};
            var awayPlayer = new List<Player> { player3, player4, player5 };
            var match1 = new Match
            {
               
                MatchId = 1,
                MatchStatus = MatchStatus.Scheduled,
                HomeTeam = new Team
                {
                    Id = 1, Name = "IND",
                    Venue = Venue.Home,
                    Players = homePlayer
                },
                AwayTeam = new Team
                {
                    Id = 2, Name = "AUS",
                    Venue = Venue.Away,
                    Players = awayPlayer
                },

            }; match1.MatchName = match1.HomeTeam.Name + " v " + match1.AwayTeam.Name;
            var match2 = new Match
            {
                MatchId = 2,
                MatchStatus = MatchStatus.Scheduled,
                HomeTeam = new Team { Id = 3, Name = "ENG", Venue = Venue.Home },
                AwayTeam = new Team { Id = 4, Name = "SA", Venue = Venue.Away },

            };
            match2.MatchName = match2.HomeTeam.Name + " v " + match2.AwayTeam.Name;
            var matches = new List<Match> { match1, match2 };
            MatchList = matches;
        }
    }
}
