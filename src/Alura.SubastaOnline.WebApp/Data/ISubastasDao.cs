using Alura.SubastaOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Data
{
    public interface ISubastasDao : ICommand<Subasta>, IQuery<Subasta>
    {
        
    }
}
