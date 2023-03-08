using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Subastas = new List<Subasta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public IList<Subasta> Subastas { get; set; }
    }

    public class CategoriaConInfoSubasta : Categoria
    {
        public int EnBorrador { get; set; }
        public int EnProceso { get; set; }
        public int Finalizados { get; set; }
    }
}