using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Resources.Resources
{
    public class TeamResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Flag { get; set; }
        public int createBy { get; set; }
        public DateTime? createdDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}
