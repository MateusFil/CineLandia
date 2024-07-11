using System.ComponentModel.DataAnnotations;

namespace TRABALHODEFINITIVO.Models
{
    public class FilmeAtores
    {
        [Key]
        public int FilmeAtoresId { get; set; }

        public int FilmeId { get; set; }
        public Filme? Filme { get; set; }

        public int AtorId { get; set; }
        public Artista? Ator { get; set; }

        public string Personagem { get; set; }
    }
}
