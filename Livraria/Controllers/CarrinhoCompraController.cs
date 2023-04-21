using Livraria.Models;
using Livraria.Repositories.Interfaces;
using Livraria.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILivroRepository livroRepository, CarrinhoCompra carrinhoCompra)
        {
            _livroRepository = livroRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens =_carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel 
            { 
                CarrinhoCompra =_carrinhoCompra,
                CarrinhoCompraTotal=_carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }
        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int livroId)
        {
            var livroSelecionado=_livroRepository.Livros.FirstOrDefault(p=>p.LivroId == livroId);  
            if (livroSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(livroSelecionado);
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int livroId)
        {
            var livroSelecionado = _livroRepository.Livros.FirstOrDefault(p => p.LivroId == livroId);
            if (livroSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(livroSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
