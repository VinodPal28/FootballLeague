using FootballLeague.EntityFramework.DomainContext;
using FootballLeague.EntityFramework.Entities;
using FootballLeague.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.DomainContext
{
    public interface IFootballLeagueDomainContext : IDomainContext
    {
        IQueryable<Teams> Teams { get; set; }
        IQueryable<Matches> Matches { get; set; }
        IQueryable<log> log { get; set; }

        // ObjectResult<TeamsMatches> getRanking();
        int SaveChanges();
    }
}
