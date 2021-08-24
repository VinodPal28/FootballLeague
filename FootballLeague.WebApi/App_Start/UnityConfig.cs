using FootballLeague.Data.DomainContext;
using FootballLeague.Data.Services;
using FootballLeague.Data.Services.Implementations;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace FootballLeague.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //container.RegisterType<ITeamService, TeamService>();
            container.RegisterType<ITeamService,TeamService>();
            container.RegisterType<IMatchService, MatchService>();
            container.RegisterType<IFootballLeagueDomainContext, FootballLeagueDomainContext>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}