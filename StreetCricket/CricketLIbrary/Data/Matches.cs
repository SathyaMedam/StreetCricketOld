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
            var player = new Player
            {
                Id = 1,
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

            var player3 = new Player
            {
                Id = 4,
                Name = "Simmo",
                TeamId = 1

            };

            var player4 = new Player
            {
                Id = 5,
                Name = "Rob",
                TeamId = 1

            };
            var player5 = new Player
            {
                Id = 6,
                Name = "Jamie",
                TeamId = 1

            }; var player6 = new Player
            {
                Id = 7,
                Name = "Kel",
                TeamId = 1

            };
            var player7 = new Player
            {
                Id = 8,
                Name = "Commins",
                TeamId = 1

            };
            var player8 = new Player
            {
                Id = 9,
                Name = "Np",
                TeamId = 1

            };
            var player9 = new Player
            {
                Id = 10,
                Name = "Chris",
                TeamId = 1

            };
            var player10 = new Player
            {
                Id = 11,
                Name = "LLoyd",
                TeamId = 1

            };
            var player11 = new Player
            {
                Id = 12,
                Name = "Tobie",
                TeamId = 1

            };
            var player12 = new Player
            {
                Id = 13,
                Name = "Ross",
                TeamId = 1

            };
            var player13 = new Player
            {
                Id = 14,
                Name = "Spencer",
                TeamId = 1

            };

            var aPlayer = new Player
            {
                Id = 1,
                Name = "Away Sathya",
                TeamId = 2

            };
            var aPlayer1 = new Player
            {
                Id = 2,
                Name = "Away Baz",
                TeamId = 2

            };
            var aPlayer2 = new Player
            {
                Id = 3,
                Name = "Away Voke",
                TeamId = 2

            };

            var aPlayer3 = new Player
            {
                Id = 4,
                Name = "Away Simmo",
                TeamId = 2

            };

            var aPlayer4 = new Player
            {
                Id = 5,
                Name = "Away Rob",
                TeamId = 2

            };
            var aPlayer5 = new Player
            {
                Id = 6,
                Name = "Away Jamie",
                TeamId = 2

            }; var aPlayer6 = new Player
            {
                Id = 7,
                Name = "Away Kel",
                TeamId = 2

            };
            var aPlayer7 = new Player
            {
                Id = 8,
                Name = "Away Commins",
                TeamId = 2

            };
            var aPlayer8 = new Player
            {
                Id = 9,
                Name = "Away Np",
                TeamId = 2

            };
            var aPlayer9 = new Player
            {
                Id = 10,
                Name = "Away Chris",
                TeamId = 2

            };
            var aPlayer10 = new Player
            {
                Id = 11,
                Name = "Away LLoyd",
                TeamId = 2

            };
            var aPlayer11 = new Player
            {
                Id = 12,
                Name = "Away Tobie",
                TeamId = 2

            };
            var aPlayer12 = new Player
            {
                Id = 13,
                Name = "Away Ross",
                TeamId = 2

            };
            var aPlayer13 = new Player
            {
                Id = 14,
                Name = "Away Spencer",
                TeamId = 2

            };

            var homePlayer = new List<Player> { player, player1, player2, player3, player4, player5};
                //, player6, player7, player8, player9, player10, player11, player12, player13 };
            var awayPlayer = new List<Player> { aPlayer, aPlayer1, aPlayer2, aPlayer3, aPlayer4, aPlayer5};
            //, aPlayer6, aPlayer7, aPlayer8, aPlayer9, aPlayer1, aPlayer11, aPlayer12, aPlayer13 };
            var match1 = new Match
            {

                MatchId = 1,
                MatchStatus = MatchStatus.Scheduled,
                HomeTeam = new Team
                {
                    Id = 1,
                    Name = "IND",
                    Venue = Venue.Home,
                    
                },
                AwayTeam = new Team
                {
                    Id = 2,
                    Name = "AUS",
                    Venue = Venue.Away,
                },

            };
            match1.HomePlayers = homePlayer;
            match1.AwayPlayers = awayPlayer;
            match1.MatchName = match1.HomeTeam.Name + " v " + match1.AwayTeam.Name;
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
