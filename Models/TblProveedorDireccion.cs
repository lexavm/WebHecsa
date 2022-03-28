using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblProveedorDireccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedorDirecciones { get; set; }
        [Display(Name = "Tipo Direccion")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTipoDireccion { get; set; }
        [Display(Name = "Calle")]
        [Required(ErrorMessage = "Campo Requerido")]

        public string Calle { get; set; }
        [Display(Name = "Codigo Postal")]

        public string CodigoPostal { get; set; }

        public string IdColonia { get; set; }
        [Display(Name = "Colonia")]

        public string Colonia { get; set; }
        [Display(Name = "Localidad / Municipio")]

        public string LocalidadMunicipio { get; set; }
        [Display(Name = "Ciudad")]

        public string Ciudad { get; set; }
        [Display(Name = "Estado")]

        public string Estado { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "Campo Requerido")]

        public string CorreoElectronico { get; set; }
        [Display(Name = "Telefono")]

        public string Telefono { get; set; }
        [Display(Name = "Proveedor")]
        public Guid IdProveedor { get; set; }
        [Column("Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        public Guid? IdProveedorNavigationIdProveedor { get; set; }

        public virtual TblProveedor IdProveedorNavigationIdProveedorNavigation { get; set; }
    }
}
