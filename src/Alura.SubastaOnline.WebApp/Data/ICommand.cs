using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Data
{
    public interface ICommand<T>
    {
        public void Incluir(T obj);

        public void Actualizar(T obj);

        public void Eliminar(T obj);
    }
}
