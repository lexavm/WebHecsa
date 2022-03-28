using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblProveedorContacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int IdProveedorContacto { get; set; }
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdPerfil { get; set; }

        [NotMapped]
        [Display(Name = "Perfil")]
        public string PerfilDesc { get; set; }
        [Display(Name = "Nombre Contacto")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreProveedorContacto { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "Campo Requerido")]

        public string CorreoElectronico { get; set; }
        [Display(Name = "Telefono")]

        public string Telefono { get; set; }
        [Display(Name = "Telefono Movil")]
        public string TelefonoMovil { get; set; }
        public Guid IdProveedor { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Proveedor")]
        public string NombreProveedor { get; set; }
        [Column("Fecha Registro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        public Guid? IdProveedorNavigationIdProveedor { get; set; }

        public virtual TblProveedor IdProveedorNavigationIdProveedorNavigation { get; set; }
    }
}
