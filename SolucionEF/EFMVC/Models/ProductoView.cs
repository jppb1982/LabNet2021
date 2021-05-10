using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFMVC.Models
{
    public class ProductoView
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Por favor ingrese un nombre")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Por favor ingrese entre 3 y 40 caeacteres.")]
        public String Nombre { get; set; }


        [StringLength(20, ErrorMessage = "Por favor ingrese no más de 20 caeacteres.")]
        public String CantidadPorUnidad { get; set; }


        [Display(Name = "Precio unitario")]
        [DataType(DataType.Currency)]
        public Decimal PrecioUnitario { get; set; }

    }
}