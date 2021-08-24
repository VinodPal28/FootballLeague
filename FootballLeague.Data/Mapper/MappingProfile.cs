using AutoMapper;
using FootballLeague.EntityFramework.Entities;
using FootballLeague.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<List<Teams>, List<TeamResource>>();
          
        }
    }
}
