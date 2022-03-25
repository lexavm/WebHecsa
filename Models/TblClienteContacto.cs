using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblClienteContacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClienteContacto { get; set; }
        public int IdPerfil { get; set; }
        public string NombreClienteContacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string TelefonoMovil { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public Guid? IdClienteNavigationIdCliente { get; set; }

        public virtual TblCliente IdClienteNavigationIdClienteNavigation { get; set; }
    }
}
