using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Data
{
    public interface ISubastasDao
    {
        
        public Subasta BuscarSubastaPorId(int id);


        public IEnumerable<Subasta> BuscarTodasLasSubastas();

        public void IncluirSubasta(Subasta obj);

        public void ActualizarSubasta(Subasta obj);

        public void EliminarSubasta(Subasta obj);
    }
}
