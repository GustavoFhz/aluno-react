using backend_aluno.Models;

namespace backend_aluno.Services.Senha
{
    public interface ISenhaInterface
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
        bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] SenhaSalt);
        string CriarToken(AlunoModel aluno);
    }
}
