using FootballLeague.Data.DomainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeague.Resources.Resources;
using FootballLeague.EntityFramework.Entities;
using FootballLeague.Data.enums;

namespace FootballLeague.Data.Services.Implementations
{    
    public class TeamService : ITeamService
    {
        private readonly IFootballLeagueDomainContext _footballLeagueDomainContext;

        public TeamService(IFootballLeagueDomainContext footballLeagueDomainContext)
        {
            _footballLeagueDomainContext = footballLeagueDomainContext;
        }
       
        public List<TeamResource> getTeamsDetails()
        {
            var data = _footballLeagueDomainContext.Teams
                .Where(x => x.Flag == (int)Status.Active)
                .Select(x => new TeamResource
                {
                    Id = x.Id,
                    Name = x.Name
                }).OrderBy(x => x.Id).ToList();
          
            return data;
        }

        public bool isAddTeams(TeamResource modelDto)
        {
            var entity = new Teams
            {
                Name = modelDto.Name,             
                Flag = (int)Status.Active,              
            };
            _footballLeagueDomainContext.Add(entity);
            if (_footballLeagueDomainContext.SaveChanges() == 1) return true;
            return false;
        }

        public bool isUpdated(TeamResource modelDto)
        {            
            Teams entity = _footballLeagueDomainContext.Teams.Where(p => p.Id == modelDto.Id).FirstOrDefault();
            if (entity != null)
            {
                entity.Name = modelDto.Name;              
            }
            _footballLeagueDomainContext.Update(entity);
            if (_footballLeagueDomainContext.SaveChanges() == 1) return true;
            return false;
        }

        public bool isDeleted(TeamResource modelDto)
        {
            var data = _footballLeagueDomainContext.Teams.SingleOrDefault(x => x.Id == modelDto.Id);
            if (data == null) return false;
            _footballLeagueDomainContext.Delete(data);
            if (_footballLeagueDomainContext.SaveChanges() == 1) return true;
            return false;
        }


    }
}
