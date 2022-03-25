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
        public int IdTipoDireccion { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        public string IdColonia { get; set; }
        public string Colonia { get; set; }
        public string LocalidadMunicipio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public Guid IdProveedor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public Guid? IdProveedorNavigationIdProveedor { get; set; }

        public virtual TblProveedor IdProveedorNavigationIdProveedorNavigation { get; set; }
    }
}
