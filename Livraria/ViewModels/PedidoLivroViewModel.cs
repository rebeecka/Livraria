using Livraria.Models;

namespace Livraria.ViewModels
{
    public class PedidoLivroViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe>PedidoDetalhes { get; set; }
    }
}
