using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.SubastaOnline.WebApp.Services.Handlers
{
    public class DefaultProductoServices : IProductoServices
    {
        ISubastasDao _dao;
        ICategoriaDao _categoriaDao;

        public DefaultProductoServices(ISubastasDao dao, ICategoriaDao categoriaDao)
        {
            _dao = dao;
            _categoriaDao = categoriaDao;
        }

        IEnumerable<Subasta> IProductoServices.BusquedaSubastasPorTermino(string termino)
        {
            var termoNormalized = termino.ToUpper();
            return _dao.BuscarTodos()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descripcion.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descripcion.ToUpper().Contains(termoNormalized));
            
        }

        Categoria IProductoServices.ConsultaCategoriaPorIdConSubastas(int id)
        {
            return _categoriaDao.BuscarPorId(id);
        }

        IEnumerable<CategoriaConInfoSubasta> IProductoServices.ConsultaCategoriasTotalPorStatus()
        {
            return _categoriaDao
                .BuscarTodos()
                .Select(c => new CategoriaConInfoSubasta
                {
                    Id = c.Id,
                    Descripcion = c.Descripcion,
                    Imagen = c.Imagen,
                    EnBorrador = c.Subastas.Where(l => l.Status == StatusSubasta.Borrador).Count(),
                    EnProceso = c.Subastas.Where(l => l.Status == StatusSubasta.Proceso).Count(),
                    Finalizados = c.Subastas.Where(l => l.Status == StatusSubasta.Finalizado).Count(),
                });

        }
    }
}
