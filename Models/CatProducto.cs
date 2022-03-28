using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatProducto
    {
        public CatProducto()
        {
            TblProductoPromociones = new HashSet<TblProductoPromocion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        [Display(Name = "Codigo Interno")]
        public string CodigoInterno { get; set; }
        [Display(Name = "Codigo Externo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string CodigoExterno { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdMarca { get; set; }
        [Display(Name = "Marca")]
        [NotMapped]
        public string MarcaDesc { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdCategoria { get; set; }
        [Display(Name = "Categoria")]
        [NotMapped]
        public string CategoriaDesc { get; set; }
        [Display(Name = "Descripcion Producto")]
        public string DescProducto { get; set; }
        [Display(Name = "Minima")]
        public int CantidadMinima { get; set; }
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Display(Name = "Precio")]
        public decimal ProductoPrecioUno { get; set; }
        [Display(Name = "Porcentaje")]
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
        public virtual ICollection<TblProductoPromocion> TblProductoPromociones { get; set; }
    }
}
