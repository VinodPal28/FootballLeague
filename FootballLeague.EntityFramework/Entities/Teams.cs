using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.EntityFramework.Entities
{
    public class Teams
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Flag { get; set; }
        public int createBy { get; set; }
        public DateTime? createdDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}
