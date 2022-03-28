using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string CodigoInterno { get; set; }
        public string CodigoExterno { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string DescProducto { get; set; }
        public int CantidadMinima { get; set; }
        public int Cantidad { get; set; }
        public decimal ProductoPrecioUno { get; set; }
        public decimal PorcentajePrecioUno { get; set; }
        public decimal SubCosto { get; set; }
        public decimal Costo { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        public int? IdCategoriaNavigationIdCategoria { get; set; }

        public virtual CatCategoria IdCategoriaNavigationIdCategoriaNavigation { get; set; }
    }
}
