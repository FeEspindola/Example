using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person.Include(w => w.Phones));

        public async Task<Person> Get(int id)

            => await _context.Person.Include("Phones").FirstAsync(c => c.BusinessEntityID == id);

        public async Task<Person> Add(Person personPhone)
        {
            try
            {
                var teste = await _context.Person.AddAsync(personPhone);
                await _context.SaveChangesAsync();
                return await Task.FromResult(teste.Entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task Update(Person person)
        {
            try
            {

                _context.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
