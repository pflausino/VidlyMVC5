using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MoviesDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MoviesDTO, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}