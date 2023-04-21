using Livraria.context;
using Livraria.Models;

namespace Livraria.Areas.Admin.Servicos
{
    public class GraficoVendasService
    {
        private readonly AppDb context;

        public GraficoVendasService(AppDb context)
        {
            this.context = context;
        }

        public List<LivroGrafico> GetVendasLivros(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var Livros = (from pd in context.PedidosDetalhe
                           join l in context.Livros on pd.LivroId equals l.LivroId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LivroId, l.Nome }
                           into g
                           select new
                           {
                               LivroNome = g.Key.Nome,
                               LivrosQuantidade = g.Sum(q => q.Quantidade),
                               LivrosValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });

            var lista = new List<LivroGrafico>();

            foreach (var item in Livros)
            {
                var Livro = new LivroGrafico();
                Livro.LivroNome = item.LivroNome;
                Livro.LivrosQuantidade = item.LivrosQuantidade;
                Livro.LivrosValorTotal = item.LivrosValorTotal;
                lista.Add(Livro);
            }
            return lista;
        }
    }
}
