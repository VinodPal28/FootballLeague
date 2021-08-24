using FootballLeague.EntityFramework.DomainContext;
using FootballLeague.EntityFramework.Entities;
using FootballLeague.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootballLeague.Data.DomainContext
{
    public class FootballLeagueDomainContext : DomainContextBase, IFootballLeagueDomainContext
    {
        #region properties

        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<log> log { get; set; }
        public virtual DbSet<TeamsMatches> TeamsMatches { get; set; }

        #endregion

        #region Constructor
        static FootballLeagueDomainContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<FootballLeagueDomainContext>());
        }

        public FootballLeagueDomainContext() : base("FootballLeague")
        {

        }

        #endregion

        #region implementation of IFootballLeagueDomainContext

        IQueryable<Teams> IFootballLeagueDomainContext.Teams
        {
            get { return Teams.AsQueryable(); }
            set { }

        }

        IQueryable<Matches> IFootballLeagueDomainContext.Matches
        {
            get { return Matches.AsQueryable(); }
            set { }

        }
        IQueryable<log> IFootballLeagueDomainContext.log
        {
            get { return log.AsQueryable(); }
            set { }

        }

        #endregion

        #region overrides of DbCOntext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<TeamsMatches>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);

            
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        #endregion
    }
}
