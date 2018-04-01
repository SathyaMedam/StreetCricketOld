using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketLIbrary.Model
{
    public class CricketMatchProperties
    {
        public FormatType FormatType { get; set; }
        public int NumberOfOvers { get; set; }
        public int NumberOfInnings { get; set; }
        public int WideValue { get; set; }
        public int NoBallValue { get; set; }
        public int NumberOfPlayersPerTeam { get; set; }
    }
}
