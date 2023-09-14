using Microsoft.AspNetCore.Mvc;
using Teste_BackEnd.Interfaces.Services;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var contas = await _contaService.Get();
                return Ok(contas);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<List<Conta>>> CadastrarConta(Conta conta)
        {
            try
            {
                var contas = await _contaService.CadastrarConta(conta);

                return Ok(contas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Login(string email, string senha)
        {
            var usuario = await _contaService.GetByUserAsync(email, senha);

            if (usuario == null)
                return BadRequest(new { Message = "Usuário ou senha inválidos" });


            return Ok();

        }

    }
}
