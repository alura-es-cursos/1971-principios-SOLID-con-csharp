using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Services
{
    public interface IAdminServices
    {
        IEnumerable<Categoria> ConsultaCategorias();
        IEnumerable<Subasta> ConsultaSubastas();
        Subasta ConsultaSubastaPorId(int id);
        void InsertaSubasta(Subasta subasta);
        void ModificaSubasta(Subasta subasta);
        void EliminaSubasta(Subasta subasta);
        void IniciaProcesoDeSubastaConId(int id);
        void FinalizaProcesoDeSubastaConId(int id);
    }
}
