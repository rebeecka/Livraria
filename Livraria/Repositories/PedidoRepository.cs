using Livraria.context;
using Livraria.Models;
using Livraria.Repositories.Interfaces;

namespace Livraria.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDb _appDb;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDb appDb, CarrinhoCompra carrinhoCompra)
        {
            _appDb = appDb;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDb.Pedidos.Add(pedido);
            _appDb.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;
            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe() 
                { 
                    Quantidade =carrinhoItem.Quantidade,
                    LivroId=carrinhoItem.Livro.LivroId,
                    PedidoId=pedido.PedidoId,
                    Preco=carrinhoItem.Livro.Preco
                };
                _appDb.PedidosDetalhe.Add(pedidoDetail);
            }
            _appDb.SaveChanges();
        }
    }
}
