using System;
using Alura.SubastaOnline.WebApp.Models;

namespace Alura.SubastaOnline.WebApp.Seeding
{
    public class SubastaRandomGenerator
    {
        Random random;
        Categoria[] categorias = new Categoria[6]
        {
            new Categoria() { Descripcion = "Diversión y Juegos", Imagen = "images/jogos.png" },
            new Categoria() { Descripcion = "Carros Antiguos", Imagen = "images/carros.png" },
            new Categoria() { Descripcion = "Obras de Arte", Imagen = "images/artes.png" },
            new Categoria() { Descripcion = "Inmuebles", Imagen = "images/imoveis.png" },
            new Categoria() { Descripcion = "Eletronicos", Imagen = "images/technology.png" },
            new Categoria() { Descripcion = "Coleccionables", Imagen = "images/colecionador.png" },
        };

        public SubastaRandomGenerator(Random random)
        {
            this.random = random;
        }

        private Categoria CategoriaCualquera()
        {
            var indiceAleatorio = random.Next(0,5);
            return categorias[indiceAleatorio];
        }

        private DateTime FechaAleatoria()
        {
            int diasAleatorios = random.Next(1,100);
            return DateTime.Now.AddDays(-diasAleatorios);
        }

        public Subasta NuevaSubasta
        {
            get
            {
                var subasta = new Subasta();
                // subasta.Id = random.Next(); será definido no loop de geração
                subasta.Categoria = CategoriaCualquera();
                subasta.Titulo = $"{subasta.Categoria.Descripcion} - Lote nº {random.Next(500)}";
                subasta.Descripcion = $"{subasta.Titulo}. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut consequat semper viverra nam libero justo laoreet. Ut placerat orci nulla pellentesque dignissim enim sit amet. Cras semper auctor neque vitae. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Penatibus et magnis dis parturient montes nascetur ridiculus. Bibendum enim facilisis gravida neque convallis. At risus viverra adipiscing at in tellus integer feugiat scelerisque. Turpis egestas pretium aenean pharetra magna ac. Suspendisse ultrices gravida dictum fusce ut. Mauris vitae ultricies leo integer. Senectus et netus et malesuada fames ac turpis egestas. Libero volutpat sed cras ornare. Tristique senectus et netus et malesuada fames ac." ;
                subasta.Status = this.StatusAleatoria();
                if (subasta.Status != StatusSubasta.Borrador)
                {
                    subasta.Inicio = this.FechaAleatoria();
                }
                if (subasta.Status == StatusSubasta.Finalizado)
                {
                    var dataAnterior = DateTime.Now.AddDays(-random.Next(10));
                    subasta.Termino = subasta.Inicio.Value.CompareTo(dataAnterior) > 0 ? dataAnterior : subasta.Inicio.Value;
                }
                subasta.IdCategoria = subasta.Categoria.Id;
                return subasta;
            }
        }

        private StatusSubasta StatusAleatoria()
        {
            int index = random.Next(0, 3);
            var values = Enum.GetValues(typeof(StatusSubasta));
            return (StatusSubasta)values.GetValue(index);
        }
    }
}