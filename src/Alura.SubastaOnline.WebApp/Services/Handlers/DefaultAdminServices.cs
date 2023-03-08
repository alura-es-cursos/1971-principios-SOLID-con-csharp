using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Services.Handlers
{
    public class DefaultAdminServices : IAdminServices
    {
        ISubastasDao _dao;
        ICategoriaDao _categoriaDao;

        public DefaultAdminServices(ISubastasDao dao, ICategoriaDao categoriaDao)
        {
            _dao = dao;
            _categoriaDao = categoriaDao;
        }
        IEnumerable<Categoria> IAdminServices.ConsultaCategorias()
        {
            return _categoriaDao.BuscarTodos();
        }

        Subasta IAdminServices.ConsultaSubastaPorId(int id)
        {
            return _dao.BuscarPorId(id);
        }

        IEnumerable<Subasta> IAdminServices.ConsultaSubastas()
        {
            return _dao.BuscarTodos();
        }

        void IAdminServices.EliminaSubasta(Subasta subasta)
        {
            if (subasta != null && subasta.Status != StatusSubasta.Proceso)
            {
                _dao.Eliminar(subasta);
            }
        }

        void IAdminServices.FinalizaProcesoDeSubastaConId(int id)
        {
            var subasta = _dao.BuscarPorId(id);
            if (subasta != null && subasta.Status == StatusSubasta.Proceso)
            {
                subasta.Status = StatusSubasta.Finalizado;
                subasta.Termino = DateTime.Now;
                _dao.Actualizar(subasta);
            }
        }

        void IAdminServices.IniciaProcesoDeSubastaConId(int id)
        {
            var subasta = _dao.BuscarPorId(id);
            if (subasta != null && subasta.Status == StatusSubasta.Borrador)
            {
                _dao.Actualizar(subasta);
            }
        }

        void IAdminServices.InsertaSubasta(Subasta subasta)
        {
            _dao.Incluir(subasta);
        }

        void IAdminServices.ModificaSubasta(Subasta subasta)
        {
            _dao.Actualizar(subasta);
        }
    }
}
