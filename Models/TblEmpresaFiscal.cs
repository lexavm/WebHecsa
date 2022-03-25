using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblEmpresaFiscal
    {
        public TblEmpresaFiscal()
        {
            TblCotizacionGenerals = new HashSet<TblCotizacionGeneral>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdEmpresaFiscales { get; set; }
        public string NombreFiscal { get; set; }
        public string Rfc { get; set; }
        public string RegimenFiscal { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        public string IdColonia { get; set; }
        public string Colonia { get; set; }
        public string LocalidadMunicipio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public Guid IdEmpresa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
        public Guid? IdEmpresaNavigationIdEmpresa { get; set; }

        public virtual TblEmpresa IdEmpresaNavigationIdEmpresaNavigation { get; set; }
        public virtual ICollection<TblCotizacionGeneral> TblCotizacionGenerals { get; set; }
    }
}
