using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblEmpresa
    {
        public TblEmpresa()
        {
            CatAreas = new HashSet<CatArea>();
            TblClientes = new HashSet<TblCliente>();
            TblEmpresaFiscales = new HashSet<TblEmpresaFiscal>();
            TblProveedors = new HashSet<TblProveedor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdEmpresa { get; set; }
        [Display(Name = "Nombre Empresa")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreEmpresa { get; set; }
        [Display(Name = "RFC")]

        public string Rfc { get; set; }
        [Display(Name = "Giro Comercial")]

        public string GiroComercial { get; set; }
        [Display(Name = "Calle")]

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
        [Column("Fecha Registro")]
        [DataType(DataType.Date)]

        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        public int? IdEstatusRegistroNavigationIdEstatusRegistro { get; set; }

        public virtual CatEstatus IdEstatusRegistroNavigationIdEstatusRegistroNavigation { get; set; }
        public virtual ICollection<CatArea> CatAreas { get; set; }
        public virtual ICollection<TblCliente> TblClientes { get; set; }
        public virtual ICollection<TblEmpresaFiscal> TblEmpresaFiscales { get; set; }
        public virtual ICollection<TblProveedor> TblProveedors { get; set; }
    }
}
