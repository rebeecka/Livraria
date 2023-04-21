using Livraria.context;
using Livraria.Models;
using Livraria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Repositories
{
    public class LivroRepository: ILivroRepository
    {
        private readonly AppDb _context;
        public LivroRepository(AppDb contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Livro> Livros => _context.Livros.Include(c=>c.Categoria);

        public IEnumerable<Livro> LivrosFavoritos => _context.Livros.Where(l=>l.LivroFavorito).Include(c=>c.Categoria);


        public Livro GetLivroById(int livroId)
        {
            return _context.Livros.FirstOrDefault(l=>l.LivroId == livroId);
        }
    }
}
