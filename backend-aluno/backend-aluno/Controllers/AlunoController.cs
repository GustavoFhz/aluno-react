using backend_aluno.Dto;
using backend_aluno.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend_aluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoInterface _alunoInterface;
        public AlunoController(IAlunoInterface alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }

       
        [HttpGet]
        public async Task<IActionResult> ListarAlunos()
        {
            var alunos = await _alunoInterface.ListarAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAlunoPorId(int id)
        {
            var aluno = await _alunoInterface.BuscarAlunoPorId(id);
            return Ok(aluno);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> EditarAluno(int id, [FromBody] AlunoEdicaoDto alunoEdicaoDto)
        {
            alunoEdicaoDto.Id = id;
            var aluno = await _alunoInterface.EditarAluno(alunoEdicaoDto);
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAluno(int id)
        {
            var aluno = await _alunoInterface.DeletarAluno(id);
            return Ok(aluno);
        }
    }
}
