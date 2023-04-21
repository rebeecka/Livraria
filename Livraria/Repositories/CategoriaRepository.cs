using Livraria.context;
using Livraria.Models;
using Livraria.Repositories.Interfaces;

namespace Livraria.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDb _context;

        public CategoriaRepository(AppDb context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
