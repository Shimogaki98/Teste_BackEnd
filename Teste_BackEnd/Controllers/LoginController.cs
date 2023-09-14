using Microsoft.AspNetCore.Mvc;
using Teste_BackEnd.Interfaces.Services;
using Teste_BackEnd.Services;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IContaService _contaService;

        public LoginController(IContaService contaService)
        {
            _contaService = contaService;
        }


        [HttpPost]
        public async Task<ActionResult> Login(string email, string senha)
        {
            var usuario = await _contaService.GetByUserAsync(email, senha);

            if (usuario == null)
                return BadRequest(new { Message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuario);

            return Ok(new
            {
                Conta = new
                {
                    Titular = usuario.Nome,
                    Email = usuario.Email
                },

                Token = token

            });
        }
    }
}
