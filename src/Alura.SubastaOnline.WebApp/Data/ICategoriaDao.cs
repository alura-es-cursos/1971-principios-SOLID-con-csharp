using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Data
{
    public interface ICategoriaDao
    {
        public Categoria BuscarCategoriaPorId(int id);

        public IEnumerable<Categoria> BuscarTodasCategorias();
    }
}
