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
    }
}
