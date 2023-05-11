using Livraria.context;
using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Areas.admin.Services
{
    public class RelatorioLivrosService
    {
        private readonly AppDb _context;
        public RelatorioLivrosService(AppDb context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Livro>> GetLivrosReport()
        {
            var livros = await _context.Livros.ToListAsync();
            if (livros is null)
                return default(IEnumerable<Livro>);
            return livros;

        }
        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _context.Categorias.ToListAsync();
            if (categorias is null)
                return default(IEnumerable<Categoria>);
            return categorias;

        }
    }
}
