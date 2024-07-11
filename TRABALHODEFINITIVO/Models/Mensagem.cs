using System.ComponentModel.DataAnnotations;

namespace TRABALHODEFINITIVO.Models
{
    public class Mensagem
    {
        [Key]
        public int MensagemId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O campo Email não é um endereço de email válido.")]
        public string Email { get; set; }

        [Required]
        public string Assunto { get; set; }

        [Required]
        public string Conteudo { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;
    }
}
