using System.ComponentModel.DataAnnotations;

namespace TRABALHODEFINITIVO.Models
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        public string Nome { get; set; }

        public List<Filme> Filmes { get; set; } = new List<Filme>();
    }
}
