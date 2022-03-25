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
        public int IdPerfil { get; set; }
        public string NombreProveedorContacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string TelefonoMovil { get; set; }
        public Guid IdProveedor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public Guid? IdProveedorNavigationIdProveedor { get; set; }

        public virtual TblProveedor IdProveedorNavigationIdProveedorNavigation { get; set; }
    }
}
