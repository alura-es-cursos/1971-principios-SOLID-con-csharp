using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.SubastaOnline.WebApp.Models
{
    public class Subasta
    {        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Título es obligatorio")] 
        [Display(Name = "Título", Prompt = "Digite el título de la subasta")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Início del proceso")]
        [DataType(DataType.DateTime, ErrorMessage = "Fecha inválida")]
        public DateTime? Inicio { get; set; }

        [Display(Name = "Finalización del proceso")]
        [DataType(DataType.DateTime, ErrorMessage = "Fecha inválida")]
        public DateTime? Termino { get; set; }

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public StatusSubasta Status { get; set; }
        public string PosterUrl => $"/images/poster-{Id}.jpg";
    }
}