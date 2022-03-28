using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebHecsa.Models
{
    public class TblProductoPromocion
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProductoPromocion { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdProducto { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public decimal PromocionDesc { get; set; }

        [Display(Name = "Porcentaje")]
        [Required(ErrorMessage = "Campo Requerido")]
        public decimal PorcentajePrecioUno { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }

        public virtual CatProducto IdProductoNavigationIdCategoriaNavigation { get; set; }

    }
}
