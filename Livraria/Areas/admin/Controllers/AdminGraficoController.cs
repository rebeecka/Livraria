
using Livraria.Areas.admin.Services;
using Livraria.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendas;

        public AdminGraficoController(GraficoVendasService graficoVendas)
        {
            _graficoVendas = graficoVendas ?? throw
                new ArgumentNullException(nameof(graficoVendas));
        }

        public JsonResult VendasLivros(int dias)
        {
            var livrosVendasTotais = _graficoVendas.GetVendasLivros(dias);
            return Json(livrosVendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
