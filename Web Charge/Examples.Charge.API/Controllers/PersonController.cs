using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Examples.Charge.Application.Messages.Request;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonController : BaseController
    {
        private IPersonFacade _personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }

        #region Person

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get()
        => Response(await _personFacade.FindAllAsync());


        [HttpGet("{id}")]

        public async Task<ActionResult<PersonResponse>> Get(int id)
        {
            // tratar not found
            // maperar para mostrar o tipo do contato
            return Response(await _personFacade.Get(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] PersonRequest request)
        {
            // validação com mensagens de erro

            var retorno = _personFacade.Add(request);
            return Response(retorno.Id);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PersonUpdateRequest request)
        {
            await _personFacade.Update(request);
            return Response(0, null);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Response(0, null);
        }

        #endregion

        #region PersonPhone



        #endregion



    }
}