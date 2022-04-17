using CarrascoLanches.Models;

namespace CarrascoLanches.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get;}
    }
}
