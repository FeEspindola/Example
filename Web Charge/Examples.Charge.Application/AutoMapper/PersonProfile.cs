using System.Collections.Generic;
using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().
                ReverseMap();


            CreateMap<Person, PersonResponse>()
                .ForMember(dest => dest.PersonObjects, source => source.MapFrom(w => w));
            CreateMap<PersonPhoneRequest, PersonPhone>();
         
            CreateMap<PersonPhone, PersonPhoneDto>();
            CreateMap<PersonRequest, Person>();
            CreateMap<PersonPhoneRequest, PersonPhone>();

            CreateMap<PersonUpdateRequest, Person>();
            CreateMap<PersonPhoneUpdateRequest, PersonPhone>();

        }
    }
}