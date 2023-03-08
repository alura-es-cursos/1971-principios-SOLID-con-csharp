using Alura.SubastaOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.SubastaOnline.WebApp.Data.EFCore
{
    public class CategoriasDaoConEFCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriasDaoConEFCore()
        {
            _context = new AppDbContext();
        }

    
        Categoria IQuery<Categoria>.BuscarPorId(int id)
        {
            return _context.Categorias.Include(c => c.Subastas).First(c => c.Id == id);
        }

        IEnumerable<Categoria> IQuery<Categoria>.BuscarTodos()
        {
            return _context.Categorias.Include(c => c.Subastas);
        }
    }
}
