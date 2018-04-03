using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketLIbrary.Model
{
    public class Toss
    {
        public Team TeamWonToss { get; set; }
        public TossDecisionType TossDecisionType { get; set; }
    }
    public enum TossDecisionType
    {
        Batting,
        Bowling
    }
}
