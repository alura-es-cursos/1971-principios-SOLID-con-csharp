using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Data
{
    public interface IQuery<T>
    {
        IEnumerable<T> BuscarTodos();

        T BuscarPorId(int id);
    }
}
