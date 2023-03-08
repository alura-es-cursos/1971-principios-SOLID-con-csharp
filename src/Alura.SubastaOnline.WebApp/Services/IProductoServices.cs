using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Services
{
    public interface IProductoServices
    {
        IEnumerable<Subasta> BusquedaSubastasPorTermino(string termino);
        IEnumerable<CategoriaConInfoSubasta> ConsultaCategoriasTotalPorStatus();
        Categoria ConsultaCategoriaPorIdConSubastas(int id);



    }
}
