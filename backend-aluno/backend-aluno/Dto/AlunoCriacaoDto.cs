using System.ComponentModel.DataAnnotations;

namespace backend_aluno.Dto
{
    public class AlunoCriacaoDto
    {
        [Required, StringLength(80)]
        public string Nome { get; set; }
        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite a Confirmação de senha"),
        Compare("Senha", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmaSenha { get; set; }
    }
}
