using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatMarca
    {
        public CatMarca()
        {
            CatCategoria = new HashSet<CatCategoria>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMarca { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string MarcaDesc { get; set; }
        public Guid IdProveedor { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        public Guid? IdProveedorNavigationIdProveedor { get; set; }

        public virtual TblProveedor IdProveedorNavigationIdProveedorNavigation { get; set; }
        public virtual ICollection<CatCategoria> CatCategoria { get; set; }
    }
}
