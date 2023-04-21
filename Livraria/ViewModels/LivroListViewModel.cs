using Livraria.Models;

namespace Livraria.ViewModels
    
{
    public class LivroListViewModel
    {
        public IEnumerable<Livro>Livros { get; set; }
        public string CategoriaAtual { get; set; }

       
    }
}
