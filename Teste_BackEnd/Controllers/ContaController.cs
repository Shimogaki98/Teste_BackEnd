using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("/obtersaldo")]
        [Authorize]
        public async Task<ActionResult> ObterSaldo()
        {
            try
            {
                var saldo = await _contaService.ObterSaldo(User.Identity.Name);

                return Ok(new { Message = $"Seu saldo é: R${saldo}" });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("transferir")]
        [Authorize]
        public async Task<ActionResult> Transferir(int dest, decimal valor)
        {
            try
            {
                await _contaService.Transferir(User.Identity.Name, dest, valor); // Método sera executado apenas se estiver autenticado, Identity nunca será null

                return Ok("Transação realizada com sucesso");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("extrato")]
        [Authorize]
        public async Task<ActionResult> Extrato()
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
