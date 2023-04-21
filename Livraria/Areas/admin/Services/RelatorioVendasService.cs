using Livraria.context;
using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Areas.admin.Services
{
    public class RelatorioVendasService
    {
        private readonly AppDb context;
       

        public RelatorioVendasService(AppDb _context)
        {
            context = _context;
        }
        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                         .Include(l => l.PedidoItens)
                         .ThenInclude(l => l.Livro)
                         .OrderByDescending(x => x.PedidoEnviado)
                         .ToListAsync();
        }
    }
}
