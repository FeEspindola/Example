using System.Threading.Tasks;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using FluentValidation.Results;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonResponse> Get(int id);

        Task<int> Add(PersonRequest request);
        Task Update(PersonUpdateRequest request);

    }
}