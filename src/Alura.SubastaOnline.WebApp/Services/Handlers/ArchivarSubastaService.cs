using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.SubastaOnline.WebApp.Services.Handlers
{
    public class ArchivarSubastaService : IAdminServices
    {
        IAdminServices _defaultService;

        public ArchivarSubastaService(ISubastasDao dao, ICategoriaDao categoriaDao)
        {
            _defaultService = new DefaultAdminServices(dao, categoriaDao);
        }
        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _defaultService.ConsultaCategorias();
        }

        public Subasta ConsultaSubastaPorId(int id)
        {
            return _defaultService.ConsultaSubastaPorId(id);
        }

        public IEnumerable<Subasta> ConsultaSubastas()
        {
            return _defaultService.ConsultaSubastas()
                    .Where(s => s.Status != StatusSubasta.Archivado);
        }

        public void EliminaSubasta(Subasta subasta)
        {
            if (subasta != null 
                            && subasta.Status != StatusSubasta.Proceso 
                            && subasta.Status != StatusSubasta.Archivado)
            {
                subasta.Status = StatusSubasta.Archivado;
                _defaultService.ModificaSubasta(subasta);
            }
        }

        public void FinalizaProcesoDeSubastaConId(int id)
        {
            _defaultService.FinalizaProcesoDeSubastaConId(id);
            return;
        }

        public void IniciaProcesoDeSubastaConId(int id)
        {
            _defaultService.IniciaProcesoDeSubastaConId(id);
            return;

        }

        public void InsertaSubasta(Subasta subasta)
        {
            _defaultService.InsertaSubasta(subasta);
            return;
        }

        public void ModificaSubasta(Subasta subasta)
        {
            _defaultService.ModificaSubasta(subasta);
            return;
        }
    }
}
