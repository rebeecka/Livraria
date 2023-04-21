
using Livraria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Livraria.context
{
    public class AppDb : IdentityDbContext<IdentityUser>
    {
        public AppDb(DbContextOptions<AppDb> options): base(options)
        {
            
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public  DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidosDetalhe { get; set; }
    }

}
