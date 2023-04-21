using Livraria.Models;
using System.Collections.Generic;

namespace Livraria.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> Livros { get; }
        IEnumerable<Livro> LivrosFavoritos { get; }
        Livro GetLivroById(int livroId);
    }
}
