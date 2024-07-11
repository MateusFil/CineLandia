using System.ComponentModel.DataAnnotations;

namespace TRABALHODEFINITIVO.Models
{
    public class Artista
    {
        [Key]
        public int AtorId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string PaisNascimento { get; set; }

        public string Foto { get; set; }

        public List<FilmeAtores> FilmeAtores { get; set; } = new List<FilmeAtores>();
    }
}
