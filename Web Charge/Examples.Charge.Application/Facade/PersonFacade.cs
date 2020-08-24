using System;
using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;

        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<int> Add(PersonRequest request)
        {
           // if (!request.IsValid()) return request.ValidationResult;
            // Como a pessoa é a raiz da agregação , deixei de expor os phones de forma direta
            var person = new Person(request.Name);

          
                foreach (var phone in request.Phones)
                    person.AddPhone(phone.PhoneNumber, phone.PhoneNumberTypeID);

              var a =  await _personService.Add(person);


              return a.BusinessEntityID;

        }

        public async Task<PersonResponse> FindAllAsync()
        {
            try
            {
                var result = await _personService.FindAllAsync();
                var response = new PersonResponse();
                response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<PersonResponse> Get(int id)
        {
            var result = await _personService.Get(id);
            var response = new PersonResponse();
            response.PersonObjects.Add(_mapper.Map<PersonDto>(result));

            return response;
        }

        public async Task Update(PersonUpdateRequest request)
        {
            // if (!request.IsValid()) return request.ValidationResult;
            // Como a pessoa é a raiz da agregação , deixei de expor os phones de forma direta
            var person = new Person(request.BusinessEntityID,request.Name);


            foreach (var phone in request.Phones)
                person.UpdatePhone(phone.BusinessEntityID,phone.PhoneNumber, phone.PhoneNumberTypeID);


            await _personService.Update(person);

        }
    }
}
