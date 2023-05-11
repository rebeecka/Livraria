
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Livraria.Areas.admin.FastReportUtils;
using Livraria.Areas.admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Areas.admin.Controllers
{
    [Area("Admin")]
    public class AdminLivrosReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly RelatorioLivrosService _relatorioLivrosService;

        public AdminLivrosReportController(IWebHostEnvironment webHostEnv,
            RelatorioLivrosService relatorioLivrosService)
        {
            _webHostEnv = webHostEnv;
            _relatorioLivrosService = relatorioLivrosService;
        }
        public async Task<ActionResult> LivrosCategoriaReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MySqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                               "LivrosCategoria.frx"));

            var Livros = HelperFastReport.GetTable(await _relatorioLivrosService.GetLivrosReport(), "LivrosReport");
            var categorias = HelperFastReport.GetTable(await _relatorioLivrosService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(Livros, "LivroReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");
            return View(webReport);
        }

        [Route("LivrosCategoriaPDF")]
        public async Task<ActionResult> LivrosCategoriaPDF()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MySqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                               "LivrosCategoria.frx"));

            var Livros = HelperFastReport.GetTable(await _relatorioLivrosService.GetLivrosReport(), "LivrosReport");
            var categorias = HelperFastReport.GetTable(await _relatorioLivrosService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(Livros, "LivroReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();

            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

          
            return new FileStreamResult(stream, "application/pdf");
        }
    }

}
