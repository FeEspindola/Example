using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonAggregate.Person>> FindAllAsync();
        Task<Person> Get(int id);

        Task<Person> Add(Person personPhone);
        Task Update(Person personPhone);
    }
}
