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


            //The exception is thrown when AutoMapper attempts to set the Id of movie:
            //customer.Id = customerDto.Id;
            //Id is the key property for the Movie class, and a key property should not be changed.
            //That’s why we get this exception.To resolve this, you need to tell AutoMapper to ignore
            //Id during mapping of a MovieDto to Movie.

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
