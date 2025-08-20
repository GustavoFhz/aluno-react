using backend_aluno.Dto;
using backend_aluno.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_aluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAlunoInterface _alunoInterface;
        public LoginController(IAlunoInterface alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegistrarAluno([FromBody] AlunoCriacaoDto alunoCriacaoDto)
        {
            var aluno = await _alunoInterface.RegistrarAluno(alunoCriacaoDto);
            return Ok(aluno);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AlunoLoginDto alunoLoginDto)
        {
            var aluno = await _alunoInterface.Login(alunoLoginDto);
            return Ok(aluno);
        }
    }
}
