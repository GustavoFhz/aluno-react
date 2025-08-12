using backend_aluno.Dto;
using backend_aluno.Models;

namespace backend_aluno.Services.Interface
{
    public interface IAlunoInterface
    {
        Task<ResponseModel<AlunoModel>> RegistrarAluno(AlunoCriacaoDto alunoCriacaoDto);
        Task<ResponseModel<List<AlunoModel>>> ListarAlunos();
        Task<ResponseModel<AlunoModel>> BuscarAlunoPorId(int id);
        Task<ResponseModel<AlunoModel>> EditarAluno(AlunoEdicaoDto alunoEdicaoDto);
        Task<ResponseModel<AlunoModel>> DeletarAluno(int id);
    }
}
