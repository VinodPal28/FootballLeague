using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Resources.Resources
{
    public class MatchesResource
    {
        public int Id { get; set; }
        public int MatchNo { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
    }
}
