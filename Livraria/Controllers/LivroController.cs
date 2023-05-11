using Livraria.Models;
using Livraria.Repositories.Interfaces;
using Livraria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Livro> livros;

            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                livros = _livroRepository.Livros.OrderBy(l => l.LivroId);
                categoriaAtual = "Todos os livros";
            }
            else
            {

                livros = _livroRepository.Livros
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);
                     categoriaAtual = categoria;
            }
            var livrosListViewModel = new LivroListViewModel
            {
                Livros = livros,
                CategoriaAtual = categoriaAtual
            };
            return View(livrosListViewModel);
        }
        public IActionResult Details(int livroId)
        {
            var livro= _livroRepository.Livros.FirstOrDefault(l => l.LivroId == livroId);
            return View(livro);
        }
        public ViewResult Search(string searchString)
        {
            IEnumerable<Livro> livros;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                livros = _livroRepository.Livros.OrderBy(p => p.LivroId);
                categoriaAtual = "Todos os livros";
            }
            else
            {
                livros = _livroRepository.Livros
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));
                if (livros.Any())
                    categoriaAtual = "Livros";
                else
                    categoriaAtual = "Nenhum livro foi encontrado";
            }
            return View("~/Views/Livro/List.cshtml", new LivroListViewModel
            {
                Livros = livros,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
