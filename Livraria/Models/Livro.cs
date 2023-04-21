using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [StringLength(80,MinimumLength =3, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
        [Required(ErrorMessage = "O nome do produto deve ser informado")]
        [Display(Name = "Nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O autor do livro deve ser informado")]
        [Display(Name = "Nome do(a) autor(a)")]
        [MinLength(3,ErrorMessage ="O nome deve ter no mínimo {1} caractere")]
        [MaxLength(200,ErrorMessage ="O nome pode exceder {1} caractere")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "A descrição longa do produto deve ser informada")]
        [Display(Name = "Descrição do livro")]
        [MinLength(20, ErrorMessage = "A descrição longa deve ter no mínimo {1} caractere")]
        [MaxLength(5000, ErrorMessage = "A descrição longa pode exceder {1} caractere")]
        public string LongaDescricao { get; set; }

        [Required(ErrorMessage ="Informe o preço do produto")]
        [Display(Name ="Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name ="Caminho da imagem")]
        [StringLength(200,ErrorMessage ="O {0} deve ter no máximo {1} caractere")]
        public string ImagemUrl { get; set; }

        [Display(Name ="Caminho da imagem em miniatura")]
        [StringLength(200,ErrorMessage ="O {0} deve ter no máximo {1} caractere")]
        public string ImagemMiniUrl { get; set; }

        [Display(Name ="Produto favorito?")]
        public bool LivroFavorito { get; set; }

        [Display(Name ="Disponível?")]
        public bool Disponivel { get; set; }

        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
