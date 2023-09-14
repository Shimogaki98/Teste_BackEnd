using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult CadastrarConta()
        {
            try
            {


                return Ok(Ok());
            }
            catch (Exception e)
            {
                return BadRequest();
            }


        }


    }
}
