using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHecsa.Migrations
{
    public partial class m01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatCodigosPostales",
                columns: table => new
                {
                    IdCodigosPostales = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dcodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dasenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtipoAsenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dmnpio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dcp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cestado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ccp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CtipoAsenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cmnpio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAsentaCpcons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dzona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CcveCiudad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCodigosPostales", x => x.IdCodigosPostales);
                });

            migrationBuilder.CreateTable(
                name: "CatDivisas",
                columns: table => new
                {
                    IdDivisa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDivisas", x => x.IdDivisa);
                });

            migrationBuilder.CreateTable(
                name: "CatEstatus",
                columns: table => new
                {
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstatus", x => x.IdEstatusRegistro);
                });

            migrationBuilder.CreateTable(
                name: "CatEstatusCotizacion",
                columns: table => new
                {
                    IdEstatusCotizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstatusCotizacion", x => x.IdEstatusCotizacion);
                });

            migrationBuilder.CreateTable(
                name: "CatGeneros",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneroDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatGeneros", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "CatPerfiles",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPerfiles", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "CatRoles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRoles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoDirecciones",
                columns: table => new
                {
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDireccionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoDirecciones", x => x.IdTipoDireccion);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoEnvios",
                columns: table => new
                {
                    IdTiposEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TiposEnvioDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoEnvios", x => x.IdTiposEnvio);
                });

            migrationBuilder.CreateTable(
                name: "CatTiposEstatus",
                columns: table => new
                {
                    IdTipoEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEstatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTiposEstatus", x => x.IdTipoEstatus);
                });

            migrationBuilder.CreateTable(
                name: "TblEmpresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiroComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEstatusRegistroNavigationIdEstatusRegistro = table.Column<int>(type: "int", nullable: true),
                    IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatusRegistro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpresas", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_TblEmpresas_CatEstatus_IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatusRegistro",
                        column: x => x.IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatusRegistro,
                        principalTable: "CatEstatus",
                        principalColumn: "IdEstatusRegistro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatAreas",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatAreas", x => x.IdArea);
                    table.ForeignKey(
                        name: "FK_CatAreas_TblEmpresas_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblClientes",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiroComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_TblClientes_TblEmpresas_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblEmpresaFiscales",
                columns: table => new
                {
                    IdEmpresaFiscales = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegimenFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpresaFiscales", x => x.IdEmpresaFiscales);
                    table.ForeignKey(
                        name: "FK_TblEmpresaFiscales_TblEmpresas_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiroComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedores", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_TblProveedores_TblEmpresas_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblUsuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorreoAcceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdAreaNavigationIdArea = table.Column<int>(type: "int", nullable: true),
                    IdGeneroNavigationIdGenero = table.Column<int>(type: "int", nullable: true),
                    IdPerfilNavigationIdPerfil = table.Column<int>(type: "int", nullable: true),
                    IdRolNavigationIdRol = table.Column<int>(type: "int", nullable: true),
                    IdAreaNavigationIdAreaNavigationIdArea = table.Column<int>(type: "int", nullable: true),
                    IdGeneroNavigationIdGeneroNavigationIdGenero = table.Column<int>(type: "int", nullable: true),
                    IdPerfilNavigationIdPerfilNavigationIdPerfil = table.Column<int>(type: "int", nullable: true),
                    IdRolNavigationIdRolNavigationIdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatAreas_IdAreaNavigationIdAreaNavigationIdArea",
                        column: x => x.IdAreaNavigationIdAreaNavigationIdArea,
                        principalTable: "CatAreas",
                        principalColumn: "IdArea",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatGeneros_IdGeneroNavigationIdGeneroNavigationIdGenero",
                        column: x => x.IdGeneroNavigationIdGeneroNavigationIdGenero,
                        principalTable: "CatGeneros",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatPerfiles_IdPerfilNavigationIdPerfilNavigationIdPerfil",
                        column: x => x.IdPerfilNavigationIdPerfilNavigationIdPerfil,
                        principalTable: "CatPerfiles",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatRoles_IdRolNavigationIdRolNavigationIdRol",
                        column: x => x.IdRolNavigationIdRolNavigationIdRol,
                        principalTable: "CatRoles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblClienteContactos",
                columns: table => new
                {
                    IdClienteContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    NombreClienteContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdClienteNavigationIdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdClienteNavigationIdClienteNavigationIdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClienteContactos", x => x.IdClienteContacto);
                    table.ForeignKey(
                        name: "FK_TblClienteContactos_TblClientes_IdClienteNavigationIdClienteNavigationIdCliente",
                        column: x => x.IdClienteNavigationIdClienteNavigationIdCliente,
                        principalTable: "TblClientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblClienteDirecciones",
                columns: table => new
                {
                    IdClienteDirecciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdClienteNavigationIdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdTipoDireccionNavigationIdTipoDireccion = table.Column<int>(type: "int", nullable: true),
                    IdClienteNavigationIdClienteNavigationIdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDireccion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClienteDirecciones", x => x.IdClienteDirecciones);
                    table.ForeignKey(
                        name: "FK_TblClienteDirecciones_CatTipoDirecciones_IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDireccion",
                        column: x => x.IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDireccion,
                        principalTable: "CatTipoDirecciones",
                        principalColumn: "IdTipoDireccion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblClienteDirecciones_TblClientes_IdClienteNavigationIdClienteNavigationIdCliente",
                        column: x => x.IdClienteNavigationIdClienteNavigationIdCliente,
                        principalTable: "TblClientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblCotizacionGenerales",
                columns: table => new
                {
                    IdCotizacionGeneral = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCotizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresaFiscales = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClienteContacto = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTiposEnvio = table.Column<int>(type: "int", nullable: false),
                    IdDivisa = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEstatusCotizacion = table.Column<int>(type: "int", nullable: false),
                    IdDivisaNavigationIdDivisa = table.Column<int>(type: "int", nullable: true),
                    IdEmpresaFiscalesNavigationIdEmpresaFiscales = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdTiposEnvioNavigationIdTiposEnvio = table.Column<int>(type: "int", nullable: true),
                    IdDivisaNavigationIdDivisaNavigationIdDivisa = table.Column<int>(type: "int", nullable: true),
                    IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresaFiscales = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio = table.Column<int>(type: "int", nullable: true),
                    CatEstatusCotizacionIdEstatusCotizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCotizacionGenerales", x => x.IdCotizacionGeneral);
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_CatDivisas_IdDivisaNavigationIdDivisaNavigationIdDivisa",
                        column: x => x.IdDivisaNavigationIdDivisaNavigationIdDivisa,
                        principalTable: "CatDivisas",
                        principalColumn: "IdDivisa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_CatEstatusCotizacion_CatEstatusCotizacionIdEstatusCotizacion",
                        column: x => x.CatEstatusCotizacionIdEstatusCotizacion,
                        principalTable: "CatEstatusCotizacion",
                        principalColumn: "IdEstatusCotizacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_CatTipoEnvios_IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio",
                        column: x => x.IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio,
                        principalTable: "CatTipoEnvios",
                        principalColumn: "IdTiposEnvio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_TblEmpresaFiscales_IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresaFiscales",
                        column: x => x.IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresaFiscales,
                        principalTable: "TblEmpresaFiscales",
                        principalColumn: "IdEmpresaFiscales",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatMarcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProveedorNavigationIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdProveedorNavigationIdProveedorNavigationIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatMarcas", x => x.IdMarca);
                    table.ForeignKey(
                        name: "FK_CatMarcas_TblProveedores_IdProveedorNavigationIdProveedorNavigationIdProveedor",
                        column: x => x.IdProveedorNavigationIdProveedorNavigationIdProveedor,
                        principalTable: "TblProveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedorContactos",
                columns: table => new
                {
                    IdProveedorContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    NombreProveedorContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProveedorNavigationIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdProveedorNavigationIdProveedorNavigationIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorContactos", x => x.IdProveedorContacto);
                    table.ForeignKey(
                        name: "FK_TblProveedorContactos_TblProveedores_IdProveedorNavigationIdProveedorNavigationIdProveedor",
                        column: x => x.IdProveedorNavigationIdProveedorNavigationIdProveedor,
                        principalTable: "TblProveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedorDirecciones",
                columns: table => new
                {
                    IdProveedorDirecciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProveedorNavigationIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdProveedorNavigationIdProveedorNavigationIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorDirecciones", x => x.IdProveedorDirecciones);
                    table.ForeignKey(
                        name: "FK_TblProveedorDirecciones_TblProveedores_IdProveedorNavigationIdProveedorNavigationIdProveedor",
                        column: x => x.IdProveedorNavigationIdProveedorNavigationIdProveedor,
                        principalTable: "TblProveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatCategorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdMarcaNavigationIdMarca = table.Column<int>(type: "int", nullable: true),
                    IdMarcaNavigationIdMarcaNavigationIdMarca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCategorias", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_CatCategorias_CatMarcas_IdMarcaNavigationIdMarcaNavigationIdMarca",
                        column: x => x.IdMarcaNavigationIdMarcaNavigationIdMarca,
                        principalTable: "CatMarcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatProductos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoExterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    DescProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadMinima = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoPrecioUno = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajePrecioUno = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaNavigationIdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdCategoriaNavigationIdCategoriaNavigationIdCategoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatProductos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_CatProductos_CatCategorias_IdCategoriaNavigationIdCategoriaNavigationIdCategoria",
                        column: x => x.IdCategoriaNavigationIdCategoriaNavigationIdCategoria,
                        principalTable: "CatCategorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblProductoPromociones",
                columns: table => new
                {
                    IdProductoPromocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    PromocionDesc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajePrecioUno = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProductoNavigationIdCategoriaNavigationIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProductoPromociones", x => x.IdProductoPromocion);
                    table.ForeignKey(
                        name: "FK_TblProductoPromociones_CatProductos_IdProductoNavigationIdCategoriaNavigationIdProducto",
                        column: x => x.IdProductoNavigationIdCategoriaNavigationIdProducto,
                        principalTable: "CatProductos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatAreas_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                table: "CatAreas",
                column: "IdEmpresaNavigationIdEmpresaNavigationIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_CatCategorias_IdMarcaNavigationIdMarcaNavigationIdMarca",
                table: "CatCategorias",
                column: "IdMarcaNavigationIdMarcaNavigationIdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_CatMarcas_IdProveedorNavigationIdProveedorNavigationIdProveedor",
                table: "CatMarcas",
                column: "IdProveedorNavigationIdProveedorNavigationIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_CatProductos_IdCategoriaNavigationIdCategoriaNavigationIdCategoria",
                table: "CatProductos",
                column: "IdCategoriaNavigationIdCategoriaNavigationIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_TblClienteContactos_IdClienteNavigationIdClienteNavigationIdCliente",
                table: "TblClienteContactos",
                column: "IdClienteNavigationIdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TblClienteDirecciones_IdClienteNavigationIdClienteNavigationIdCliente",
                table: "TblClienteDirecciones",
                column: "IdClienteNavigationIdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TblClienteDirecciones_IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDireccion",
                table: "TblClienteDirecciones",
                column: "IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_TblClientes_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                table: "TblClientes",
                column: "IdEmpresaNavigationIdEmpresaNavigationIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_CatEstatusCotizacionIdEstatusCotizacion",
                table: "TblCotizacionGenerales",
                column: "CatEstatusCotizacionIdEstatusCotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_IdDivisaNavigationIdDivisaNavigationIdDivisa",
                table: "TblCotizacionGenerales",
                column: "IdDivisaNavigationIdDivisaNavigationIdDivisa");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresaFiscales",
                table: "TblCotizacionGenerales",
                column: "IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresaFiscales");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio",
                table: "TblCotizacionGenerales",
                column: "IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmpresaFiscales_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                table: "TblEmpresaFiscales",
                column: "IdEmpresaNavigationIdEmpresaNavigationIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmpresas_IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatusRegistro",
                table: "TblEmpresas",
                column: "IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatusRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductoPromociones_IdProductoNavigationIdCategoriaNavigationIdProducto",
                table: "TblProductoPromociones",
                column: "IdProductoNavigationIdCategoriaNavigationIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TblProveedorContactos_IdProveedorNavigationIdProveedorNavigationIdProveedor",
                table: "TblProveedorContactos",
                column: "IdProveedorNavigationIdProveedorNavigationIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_TblProveedorDirecciones_IdProveedorNavigationIdProveedorNavigationIdProveedor",
                table: "TblProveedorDirecciones",
                column: "IdProveedorNavigationIdProveedorNavigationIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_TblProveedores_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                table: "TblProveedores",
                column: "IdEmpresaNavigationIdEmpresaNavigationIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TblUsuarios_IdAreaNavigationIdAreaNavigationIdArea",
                table: "TblUsuarios",
                column: "IdAreaNavigationIdAreaNavigationIdArea");

            migrationBuilder.CreateIndex(
                name: "IX_TblUsuarios_IdGeneroNavigationIdGeneroNavigationIdGenero",
                table: "TblUsuarios",
                column: "IdGeneroNavigationIdGeneroNavigationIdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_TblUsuarios_IdPerfilNavigationIdPerfilNavigationIdPerfil",
                table: "TblUsuarios",
                column: "IdPerfilNavigationIdPerfilNavigationIdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_TblUsuarios_IdRolNavigationIdRolNavigationIdRol",
                table: "TblUsuarios",
                column: "IdRolNavigationIdRolNavigationIdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatCodigosPostales");

            migrationBuilder.DropTable(
                name: "CatTiposEstatus");

            migrationBuilder.DropTable(
                name: "TblClienteContactos");

            migrationBuilder.DropTable(
                name: "TblClienteDirecciones");

            migrationBuilder.DropTable(
                name: "TblCotizacionGenerales");

            migrationBuilder.DropTable(
                name: "TblProductoPromociones");

            migrationBuilder.DropTable(
                name: "TblProveedorContactos");

            migrationBuilder.DropTable(
                name: "TblProveedorDirecciones");

            migrationBuilder.DropTable(
                name: "TblUsuarios");

            migrationBuilder.DropTable(
                name: "CatTipoDirecciones");

            migrationBuilder.DropTable(
                name: "TblClientes");

            migrationBuilder.DropTable(
                name: "CatDivisas");

            migrationBuilder.DropTable(
                name: "CatEstatusCotizacion");

            migrationBuilder.DropTable(
                name: "CatTipoEnvios");

            migrationBuilder.DropTable(
                name: "TblEmpresaFiscales");

            migrationBuilder.DropTable(
                name: "CatProductos");

            migrationBuilder.DropTable(
                name: "CatAreas");

            migrationBuilder.DropTable(
                name: "CatGeneros");

            migrationBuilder.DropTable(
                name: "CatPerfiles");

            migrationBuilder.DropTable(
                name: "CatRoles");

            migrationBuilder.DropTable(
                name: "CatCategorias");

            migrationBuilder.DropTable(
                name: "CatMarcas");

            migrationBuilder.DropTable(
                name: "TblProveedores");

            migrationBuilder.DropTable(
                name: "TblEmpresas");

            migrationBuilder.DropTable(
                name: "CatEstatus");
        }
    }
}
