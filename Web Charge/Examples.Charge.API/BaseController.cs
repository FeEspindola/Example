using Examples.Charge.Application.Common.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Charge.API
{
    public class BaseController : ControllerBase
    {
        protected new ActionResult Response(BaseResponse response)
        {
            if (response == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(new
                {
                    success = true,
                    data = response
                });
            }
        }

        protected new IActionResult Response(int? id = null, object response = null)
        {
            if (id == null)
            {
                return Ok(new
                {
                    success = true,
                    data = response
                });
            }

            return CreatedAtAction("Get", new { id },
                new
                {
                    success = true,
                    data = response ?? new object()
                });
        }
    }
}
