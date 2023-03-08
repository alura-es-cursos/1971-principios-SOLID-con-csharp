using Alura.SubastaOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.SubastaOnline.WebApp.Data.EFCore
{
    public class SubastasDaoConEFCore : ISubastasDao
    {
        AppDbContext _context;

        public SubastasDaoConEFCore()
        {
            _context = new AppDbContext();
        }

        public Subasta BuscarSubastaPorId(int id)
        {
            return _context.Subastas.First(s => s.Id == id);
        }
        

        public IEnumerable<Subasta> BuscarTodasLasSubastas() =>
            _context.Subastas.Include(l => l.Categoria);

        public void IncluirSubasta(Subasta obj)
        {
            _context.Subastas.Add(obj);
            _context.SaveChanges();
        }

        public void ActualizarSubasta(Subasta obj)
        {
            _context.Subastas.Update(obj);
            _context.SaveChanges();
        }

        public void EliminarSubasta(Subasta obj)
        {
            _context.Subastas.Remove(obj);
            _context.SaveChanges();
        }

    }
}
