using System.ComponentModel.DataAnnotations;

namespace TRABALHODEFINITIVO.Models
{
    public class Filme
    {
        [Key]

        public int FilmeId { get; set; }

        [Required]
        [MinLength(3)]
        public string Titulo { get; set; }

        public int Ano { get; set; }

        public string Tipo { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataAdquirida { get; set; }

        public decimal ValorCusto { get; set; }

        public string Situacao { get; set; }

        public string Diretor { get; set; }

        public string FotoCapa { get; set; }

        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }

        public List<FilmeAtores> FilmeAtores { get; set; } = new List<FilmeAtores>();
    }
}
