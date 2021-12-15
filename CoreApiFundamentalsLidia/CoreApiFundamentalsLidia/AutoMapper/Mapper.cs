using AutoMapper;
using CoreApiFundamentalsLidia.Data.Entities;
using CoreApiFundamentalsLidia.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiFundamentalsLidia.AutoMapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {          
            CreateMap<CampDTO, Camp>().ReverseMap();

            CreateMap<CreateCampDTO, Camp>().ReverseMap();
        }
    }
}
