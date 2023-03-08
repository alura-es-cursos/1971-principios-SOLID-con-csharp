using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.SubastaOnline.WebApp.Models
{
    public class Subasta
    {        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "T�tulo es obligatorio")] 
        [Display(Name = "T�tulo", Prompt = "Digite el t�tulo de la subasta")]
        public string Titulo { get; set; }

        [Display(Name = "Descripci�n")]
        public string Descripcion { get; set; }

        [Display(Name = "In�cio del proceso")]
        [DataType(DataType.DateTime, ErrorMessage = "Fecha inv�lida")]
        public DateTime? Inicio { get; set; }

        [Display(Name = "Finalizaci�n del proceso")]
        [DataType(DataType.DateTime, ErrorMessage = "Fecha inv�lida")]
        public DateTime? Termino { get; set; }

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public StatusSubasta Status { get; set; }
        public string PosterUrl => $"/images/poster-{Id}.jpg";
    }
}