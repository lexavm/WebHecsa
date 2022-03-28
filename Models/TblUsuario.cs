using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreUsuario { get; set; }
        public Guid IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int IdArea { get; set; }
        public int IdGenero { get; set; }
        public int IdPerfil { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoAcceso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public int? IdAreaNavigationIdArea { get; set; }
        public int? IdGeneroNavigationIdGenero { get; set; }
        public int? IdPerfilNavigationIdPerfil { get; set; }
        public int? IdRolNavigationIdRol { get; set; }

        public virtual CatArea IdAreaNavigationIdAreaNavigation { get; set; }
        public virtual CatGenero IdGeneroNavigationIdGeneroNavigation { get; set; }
        public virtual CatPerfil IdPerfilNavigationIdPerfilNavigation { get; set; }
        public virtual CatRole IdRolNavigationIdRolNavigation { get; set; }
    }
}
