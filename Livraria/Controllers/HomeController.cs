using Livraria.Models;
using Livraria.Repositories.Interfaces;
using Livraria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Livraria.Controllers
{
    public class HomeController : Controller
    {
       private readonly ILivroRepository _livroRepository;

        public HomeController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LivrosFavoritos=_livroRepository.LivrosFavoritos
            };

            return View(homeViewModel);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}