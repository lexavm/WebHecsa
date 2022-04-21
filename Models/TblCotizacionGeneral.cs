using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class TblCotizacionGeneral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCotizacionGeneral { get; set; }
        [Display(Name = "Numero Cotización")]

        public string NumeroCotizacion { get; set; }

        [Display(Name = "Fiscales")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdEmpresaFiscales { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Fiscal")]

        public string NombreFiscal { get; set; }
        [NotMapped]
        [Display(Name = "RFC Fiscal")]
        public string RfcFiscales { get; set; }
        [NotMapped]
        [Display(Name = "Régimen Fiscal")]
        public string RegimenFiscal { get; set; }
        [NotMapped]
        [Display(Name = "Calle Fiscal")]

        public string CalleFiscales { get; set; }
        [NotMapped]
        [Display(Name = "Código Postal Fiscal")]

        public string CodigoPostalFiscales { get; set; }
        [NotMapped]
        [Display(Name = "Colonia Fiscal")]
        public string IdColonia { get; set; }
        [NotMapped]
        [Display(Name = "Colonia Fiscal")]

        public string ColoniaFiscales { get; set; }
        [NotMapped]
        [Display(Name = "Localidad / Municipio Fiscal")]

        public string LocalidadMunicipioFiscales { get; set; }
        [NotMapped]

        [Display(Name = "Ciudad Fiscal")]

        public string CiudadFiscales { get; set; }
        [NotMapped]

        [Display(Name = "Estado Fiscal")]

        public string EstadoFiscales { get; set; }
        [NotMapped]

        [Display(Name = "Correo Electrónico Fiscal")]

        public string CorreoElectronicoFiscal { get; set; }
        [NotMapped]

        [Display(Name = "Teléfono Fiscal")]

        public string TelefonoFiscal { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdCliente { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Cliente")]
        public string NombreCliente { get; set; }
        [NotMapped]
        [Display(Name = "RFC Cliente")]

        public string RfcCliente { get; set; }
        [NotMapped]
        [Display(Name = "Giro Comercial Cliente")]

        public string GiroComercialCliente { get; set; }

        [Display(Name = "Contacto Cliente")]
        public int IdClienteContacto { get; set; }
        [NotMapped]
        [Display(Name = "Calle Cliente")]

        public string CalleCliente { get; set; }
        [NotMapped]
        [Display(Name = "Código Postal Cliente")]

        public string CodigoPostalCliente { get; set; }
        [NotMapped]
        [Display(Name = "Colonia Cliente")]
        public string IdColoniaCliente { get; set; }
        [NotMapped]
        [Display(Name = "Colonia Cliente")]

        public string ColoniaCliente { get; set; }
        [NotMapped]
        [Display(Name = "Localidad / Municipio Cliente")]

        public string LocalidadMunicipioCliente { get; set; }
        [NotMapped]

        [Display(Name = "Ciudad Cliente")]

        public string CiudadCliente { get; set; }
        [NotMapped]

        [Display(Name = "Estado Cliente")]

        public string EstadoCliente { get; set; }

        [NotMapped]
        [Display(Name = "Correo Electrónico Cliente")]

        public string CorreoElectronicoCliente { get; set; }
        [NotMapped]
        [Display(Name = "Teléfono Contacto")]

        public string TelefonoCliente { get; set; }
        [NotMapped]
        [Display(Name = "Perfil")]
        public int IdPerfil { get; set; }
        [NotMapped]
        [Display(Name = "Perfil")]
        public string PerfilDesc { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Contacto")]

        public string NombreClienteContacto { get; set; }
        [NotMapped]
        [Display(Name = "Correo Electrónico Contacto")]

        public string CorreoElectronicoClienteContacto { get; set; }
        [NotMapped]
        [Display(Name = "Teléfono Contacto")]

        public string TelefonoClienteContacto { get; set; }
        [NotMapped]
        [Display(Name = "Teléfono Móvil Contacto")]
        public string TelefonoMovilClienteContact { get; set; }

        [Display(Name = "Tipo Envío")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTiposEnvio { get; set; }
        [Display(Name = "Divisa")]

        public int IdDivisa { get; set; }
        [NotMapped]
        [Display(Name = "Divisa")]

        public string DivisaDesc { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]

        [NotMapped]
        public int IdProducto { get; set; }
        [NotMapped]
        [Display(Name = "Codigo Interno")]
        public string CodigoInterno { get; set; }
        [NotMapped]
        [Display(Name = "Codigo Externo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string CodigoExterno { get; set; }
        [NotMapped]
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdMarca { get; set; }
        
        [Display(Name = "Marca")]
        [NotMapped]
        public string MarcaDesc { get; set; }
        [NotMapped]
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdCategoria { get; set; }
        
        [Display(Name = "Categoria")]
        [NotMapped]
        public string CategoriaDesc { get; set; }
        [NotMapped]
        [Display(Name = "Descripcion Producto")]
        public string DescProducto { get; set; }
        [NotMapped]
        [Display(Name = "Minima")]
        public int CantidadMinima { get; set; }
        [NotMapped]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [NotMapped]
        [Display(Name = "Precio")]
        public decimal ProductoPrecioUno { get; set; }
        [NotMapped]
        [Display(Name = "Porcentaje")]
        public decimal PorcentajePrecioUno { get; set; }
        [NotMapped]
        public decimal SubCosto { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }
        [Display(Name = "Estatus Cotización")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusCotizacion { get; set; }
        [NotMapped]
        [Display(Name = "Estatus Cotización")]

        public string EstatusCotizacionDesc { get; set; }
        public int? IdDivisaNavigationIdDivisa { get; set; }
        public Guid? IdEmpresaFiscalesNavigationIdEmpresaFiscales { get; set; }
        public int? IdTiposEnvioNavigationIdTiposEnvio { get; set; }

        public virtual CatDivisa IdDivisaNavigationIdDivisaNavigation { get; set; }
        public virtual TblEmpresaFiscal IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigation { get; set; }
        public virtual CatTipoEnvio IdTiposEnvioNavigationIdTiposEnvioNavigation { get; set; }
    }
}
