using AutoMapper;
using backend_aluno.Data;
using backend_aluno.Dto;
using backend_aluno.Models;
using backend_aluno.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend_aluno.Services
{
    public class AlunoService : IAlunoInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AlunoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel<AlunoModel>> EditarAluno(AlunoEdicaoDto alunoEdicaoDto)
        {
            ResponseModel<AlunoModel> response = new ResponseModel<AlunoModel>();

            try
            {
                var alunoBanco = _context.Alunos.Find(alunoEdicaoDto.Id);

                if(alunoBanco == null)
                {
                    response.Status = false;
                    response.Mensagem = "Aluno não encontrado";
                    return response;
                }

                alunoBanco.Nome = alunoEdicaoDto.Nome;
                alunoBanco.Email = alunoEdicaoDto.Email;
                alunoBanco.Idade = alunoEdicaoDto.Idade;

                _context.Alunos.Update(alunoBanco);
                await _context.SaveChangesAsync();

                response.Dados = alunoBanco;
                response.Mensagem = "Aluno atualizado com sucesso";
                return response;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = "Erro ao atualizar aluno: " + ex.Message;
                return response;
            }

        }

        public async Task<ResponseModel<AlunoModel>> BuscarAlunoPorId(int id)
        {
            ResponseModel<AlunoModel> response = new ResponseModel<AlunoModel>();

            try
            {
                var aluno = await _context.Alunos.FindAsync(id);

                if(aluno == null)
                {
                    response.Status = false;
                    response.Mensagem = "Aluno não localizado";
                    return response;
                }

                response.Dados = aluno;
                response.Mensagem = "Aluno localizado com sucesso";
                return response;

            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = "Erro ao localizar aluno: " + ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<AlunoModel>> DeletarAluno(int id)
        {
            ResponseModel<AlunoModel> response = new ResponseModel<AlunoModel>();

            try
            {
                var aluno = await _context.Alunos.FindAsync(id);

                if(aluno == null)
                {
                    response.Status = false;
                    response.Mensagem = "Aluno não localizado para deletar";
                    return response;
                }
                response.Dados = aluno;
                response.Mensagem = "Aluno removido com sucesso";

                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();

                return response;
            }

            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = "Erro ao deletar aluno: " + ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<AlunoModel>>> ListarAlunos()
        {
            ResponseModel<List<AlunoModel>> response = new ResponseModel<List<AlunoModel>>();

            try
            {
                var alunos = await _context.Alunos.ToListAsync();

                response.Dados = alunos;
                response.Mensagem = "Alunos listados com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = "Erro ao listar aluno: " + ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<AlunoModel>> RegistrarAluno(AlunoCriacaoDto alunoCriacaoDto)
        {
            ResponseModel<AlunoModel> response = new ResponseModel<AlunoModel>();

            try
            {
                if (AlunoExiste(alunoCriacaoDto))
                {
                    response.Status = false;
                    response.Mensagem = "Aluno já cadastrado";
                    return response;
                }

                AlunoModel aluno = _mapper.Map<AlunoModel>(alunoCriacaoDto);

                _context.Add(aluno);
                await _context.SaveChangesAsync();

                response.Dados = aluno;
                response.Mensagem = "Aluno cadastrado com sucesso";
                return response;

            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = "Erro ao registrar aluno: " + ex.Message;
                return response;
            }
        }

        public bool AlunoExiste(AlunoCriacaoDto alunoCriacaoDto)
        {
            return _context.Alunos.Any(item => item.Nome == alunoCriacaoDto.Nome);
        }
    }
}
