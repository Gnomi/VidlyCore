using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidlyCore.Dtos;
using VidlyCore.Models;

namespace VidlyCore
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();

            //DTO to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
             
            CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            //            CreateMap<CustomerDto, Customer>();
            //            CreateMap<MovieDto, Movie>();
        }

    }
}
