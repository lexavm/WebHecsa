using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHecsa.Migrations
{
    public partial class m01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatCodigosPostales",
                columns: table => new
                {
                    IdCodigosPostales = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dcodigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dasenta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DtipoAsenta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dmnpio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dciudad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dcp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cestado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coficina = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ccp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CtipoAsenta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cmnpio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdAsentaCpcons = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dzona = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CcveCiudad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCodigosPostales", x => x.IdCodigosPostales);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatDivisas",
                columns: table => new
                {
                    IdDivisa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DivisaDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDivisas", x => x.IdDivisa);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatEstatus",
                columns: table => new
                {
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstatusDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstatus", x => x.IdEstatusRegistro);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatEstatusCotizacion",
                columns: table => new
                {
                    IdEstatusCotizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstatusDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstatusCotizacion", x => x.IdEstatusCotizacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatGeneros",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GeneroDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatGeneros", x => x.IdGenero);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatPerfiles",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerfilDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPerfiles", x => x.IdPerfil);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatRoles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RolDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRoles", x => x.IdRol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatTipoDirecciones",
                columns: table => new
                {
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoDireccionDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoDirecciones", x => x.IdTipoDireccion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatTipoEnvios",
                columns: table => new
                {
                    IdTiposEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TiposEnvioDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoEnvios", x => x.IdTiposEnvio);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatTiposEstatus",
                columns: table => new
                {
                    IdTipoEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoEstatusDesc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTiposEstatus", x => x.IdTipoEstatus);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblEmpresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NombreEmpresa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rfc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GiroComercial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdColonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Colonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalidadMunicipio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEstatusRegistroNavigationIdEstatusRegistro = table.Column<int>(type: "int", nullable: true),
                    IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatus = table.Column<int>(name: "IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatus~", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpresas", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_TblEmpresas_CatEstatus_IdEstatusRegistroNavigationIdEstatusR~",
                        column: x => x.IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatus,
                        principalTable: "CatEstatus",
                        principalColumn: "IdEstatusRegistro");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatAreas",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AreaDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpresa = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatAreas", x => x.IdArea);
                    table.ForeignKey(
                        name: "FK_CatAreas_TblEmpresas_IdEmpresaNavigationIdEmpresaNavigationI~",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblClientes",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NombreCliente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rfc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GiroComercial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpresa = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_TblClientes_TblEmpresas_IdEmpresaNavigationIdEmpresaNavigati~",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblEmpresaFiscales",
                columns: table => new
                {
                    IdEmpresaFiscales = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NombreFiscal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rfc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegimenFiscal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdColonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Colonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalidadMunicipio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpresa = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpresaFiscales", x => x.IdEmpresaFiscales);
                    table.ForeignKey(
                        name: "FK_TblEmpresaFiscales_TblEmpresas_IdEmpresaNavigationIdEmpresaN~",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblProveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NombreProveedor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rfc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GiroComercial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpresa = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdEmpresaNavigationIdEmpresaNavigationIdEmpresa = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedores", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_TblProveedores_TblEmpresas_IdEmpresaNavigationIdEmpresaNavig~",
                        column: x => x.IdEmpresaNavigationIdEmpresaNavigationIdEmpresa,
                        principalTable: "TblEmpresas",
                        principalColumn: "IdEmpresa");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblUsuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombres = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPaterno = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoMaterno = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreUsuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpresa = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NombreEmpresa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CorreoAcceso = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatGeneros_IdGeneroNavigationIdGeneroNavigationI~",
                        column: x => x.IdGeneroNavigationIdGeneroNavigationIdGenero,
                        principalTable: "CatGeneros",
                        principalColumn: "IdGenero");
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatPerfiles_IdPerfilNavigationIdPerfilNavigation~",
                        column: x => x.IdPerfilNavigationIdPerfilNavigationIdPerfil,
                        principalTable: "CatPerfiles",
                        principalColumn: "IdPerfil");
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatRoles_IdRolNavigationIdRolNavigationIdRol",
                        column: x => x.IdRolNavigationIdRolNavigationIdRol,
                        principalTable: "CatRoles",
                        principalColumn: "IdRol");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblClienteContactos",
                columns: table => new
                {
                    IdClienteContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    NombreClienteContacto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonoMovil = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdClienteNavigationIdCliente = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdClienteNavigationIdClienteNavigationIdCliente = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClienteContactos", x => x.IdClienteContacto);
                    table.ForeignKey(
                        name: "FK_TblClienteContactos_TblClientes_IdClienteNavigationIdCliente~",
                        column: x => x.IdClienteNavigationIdClienteNavigationIdCliente,
                        principalTable: "TblClientes",
                        principalColumn: "IdCliente");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblClienteDirecciones",
                columns: table => new
                {
                    IdClienteDirecciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdColonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Colonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalidadMunicipio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdClienteNavigationIdCliente = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdTipoDireccionNavigationIdTipoDireccion = table.Column<int>(type: "int", nullable: true),
                    IdClienteNavigationIdClienteNavigationIdCliente = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDirecci = table.Column<int>(name: "IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDirecci~", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClienteDirecciones", x => x.IdClienteDirecciones);
                    table.ForeignKey(
                        name: "FK_TblClienteDirecciones_CatTipoDirecciones_IdTipoDireccionNavi~",
                        column: x => x.IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDirecci,
                        principalTable: "CatTipoDirecciones",
                        principalColumn: "IdTipoDireccion");
                    table.ForeignKey(
                        name: "FK_TblClienteDirecciones_TblClientes_IdClienteNavigationIdClien~",
                        column: x => x.IdClienteNavigationIdClienteNavigationIdCliente,
                        principalTable: "TblClientes",
                        principalColumn: "IdCliente");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblCotizacionGenerales",
                columns: table => new
                {
                    IdCotizacionGeneral = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroCotizacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpresaFiscales = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdCliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdClienteContacto = table.Column<int>(type: "int", nullable: false),
                    IdTiposEnvio = table.Column<int>(type: "int", nullable: false),
                    IdDivisa = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdEstatusCotizacion = table.Column<int>(type: "int", nullable: false),
                    IdDivisaNavigationIdDivisa = table.Column<int>(type: "int", nullable: true),
                    IdEmpresaFiscalesNavigationIdEmpresaFiscales = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdTiposEnvioNavigationIdTiposEnvio = table.Column<int>(type: "int", nullable: true),
                    IdDivisaNavigationIdDivisaNavigationIdDivisa = table.Column<int>(type: "int", nullable: true),
                    IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresa = table.Column<Guid>(name: "IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresa~", type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio = table.Column<int>(type: "int", nullable: true),
                    CatEstatusCotizacionIdEstatusCotizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCotizacionGenerales", x => x.IdCotizacionGeneral);
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_CatDivisas_IdDivisaNavigationIdDivisa~",
                        column: x => x.IdDivisaNavigationIdDivisaNavigationIdDivisa,
                        principalTable: "CatDivisas",
                        principalColumn: "IdDivisa");
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_CatEstatusCotizacion_CatEstatusCotiza~",
                        column: x => x.CatEstatusCotizacionIdEstatusCotizacion,
                        principalTable: "CatEstatusCotizacion",
                        principalColumn: "IdEstatusCotizacion");
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_CatTipoEnvios_IdTiposEnvioNavigationI~",
                        column: x => x.IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio,
                        principalTable: "CatTipoEnvios",
                        principalColumn: "IdTiposEnvio");
                    table.ForeignKey(
                        name: "FK_TblCotizacionGenerales_TblEmpresaFiscales_IdEmpresaFiscalesN~",
                        column: x => x.IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresa,
                        principalTable: "TblEmpresaFiscales",
                        principalColumn: "IdEmpresaFiscales");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatMarcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MarcaDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdProveedor = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProveedorNavigationIdProveedor = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdProveedorNavigationIdProveedorNavigationIdProveedor = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatMarcas", x => x.IdMarca);
                    table.ForeignKey(
                        name: "FK_CatMarcas_TblProveedores_IdProveedorNavigationIdProveedorNav~",
                        column: x => x.IdProveedorNavigationIdProveedorNavigationIdProveedor,
                        principalTable: "TblProveedores",
                        principalColumn: "IdProveedor");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblProveedorContactos",
                columns: table => new
                {
                    IdProveedorContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    NombreProveedorContacto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonoMovil = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdProveedor = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProveedorNavigationIdProveedor = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdProveedorNavigationIdProveedorNavigationIdProveedor = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorContactos", x => x.IdProveedorContacto);
                    table.ForeignKey(
                        name: "FK_TblProveedorContactos_TblProveedores_IdProveedorNavigationId~",
                        column: x => x.IdProveedorNavigationIdProveedorNavigationIdProveedor,
                        principalTable: "TblProveedores",
                        principalColumn: "IdProveedor");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblProveedorDirecciones",
                columns: table => new
                {
                    IdProveedorDirecciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdColonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Colonia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalidadMunicipio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdProveedor = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProveedorNavigationIdProveedor = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdProveedorNavigationIdProveedorNavigationIdProveedor = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorDirecciones", x => x.IdProveedorDirecciones);
                    table.ForeignKey(
                        name: "FK_TblProveedorDirecciones_TblProveedores_IdProveedorNavigation~",
                        column: x => x.IdProveedorNavigationIdProveedorNavigationIdProveedor,
                        principalTable: "TblProveedores",
                        principalColumn: "IdProveedor");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatCategorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoriaDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdMarcaNavigationIdMarca = table.Column<int>(type: "int", nullable: true),
                    IdMarcaNavigationIdMarcaNavigationIdMarca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCategorias", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_CatCategorias_CatMarcas_IdMarcaNavigationIdMarcaNavigationId~",
                        column: x => x.IdMarcaNavigationIdMarcaNavigationIdMarca,
                        principalTable: "CatMarcas",
                        principalColumn: "IdMarca");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatProductos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoInterno = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoExterno = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    DescProducto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadMinima = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoPrecioUno = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PorcentajePrecioUno = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SubCosto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaNavigationIdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdCategoriaNavigationIdCategoriaNavigationIdCategoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatProductos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_CatProductos_CatCategorias_IdCategoriaNavigationIdCategoriaN~",
                        column: x => x.IdCategoriaNavigationIdCategoriaNavigationIdCategoria,
                        principalTable: "CatCategorias",
                        principalColumn: "IdCategoria");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblProductoPromociones",
                columns: table => new
                {
                    IdProductoPromocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    PromocionDesc = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PorcentajePrecioUno = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false),
                    IdProductoNavigationIdCategoriaNavigationIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProductoPromociones", x => x.IdProductoPromocion);
                    table.ForeignKey(
                        name: "FK_TblProductoPromociones_CatProductos_IdProductoNavigationIdCa~",
                        column: x => x.IdProductoNavigationIdCategoriaNavigationIdProducto,
                        principalTable: "CatProductos",
                        principalColumn: "IdProducto");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CatAreas_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                table: "CatAreas",
                column: "IdEmpresaNavigationIdEmpresaNavigationIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_CatCategorias_IdMarcaNavigationIdMarcaNavigationIdMarca",
                table: "CatCategorias",
                column: "IdMarcaNavigationIdMarcaNavigationIdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_CatMarcas_IdProveedorNavigationIdProveedorNavigationIdProvee~",
                table: "CatMarcas",
                column: "IdProveedorNavigationIdProveedorNavigationIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_CatProductos_IdCategoriaNavigationIdCategoriaNavigationIdCat~",
                table: "CatProductos",
                column: "IdCategoriaNavigationIdCategoriaNavigationIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_TblClienteContactos_IdClienteNavigationIdClienteNavigationId~",
                table: "TblClienteContactos",
                column: "IdClienteNavigationIdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TblClienteDirecciones_IdClienteNavigationIdClienteNavigation~",
                table: "TblClienteDirecciones",
                column: "IdClienteNavigationIdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TblClienteDirecciones_IdTipoDireccionNavigationIdTipoDirecci~",
                table: "TblClienteDirecciones",
                column: "IdTipoDireccionNavigationIdTipoDireccionNavigationIdTipoDirecci~");

            migrationBuilder.CreateIndex(
                name: "IX_TblClientes_IdEmpresaNavigationIdEmpresaNavigationIdEmpresa",
                table: "TblClientes",
                column: "IdEmpresaNavigationIdEmpresaNavigationIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_CatEstatusCotizacionIdEstatusCotizaci~",
                table: "TblCotizacionGenerales",
                column: "CatEstatusCotizacionIdEstatusCotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_IdDivisaNavigationIdDivisaNavigationI~",
                table: "TblCotizacionGenerales",
                column: "IdDivisaNavigationIdDivisaNavigationIdDivisa");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_IdEmpresaFiscalesNavigationIdEmpresaF~",
                table: "TblCotizacionGenerales",
                column: "IdEmpresaFiscalesNavigationIdEmpresaFiscalesNavigationIdEmpresa~");

            migrationBuilder.CreateIndex(
                name: "IX_TblCotizacionGenerales_IdTiposEnvioNavigationIdTiposEnvioNav~",
                table: "TblCotizacionGenerales",
                column: "IdTiposEnvioNavigationIdTiposEnvioNavigationIdTiposEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmpresaFiscales_IdEmpresaNavigationIdEmpresaNavigationIdE~",
                table: "TblEmpresaFiscales",
                column: "IdEmpresaNavigationIdEmpresaNavigationIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmpresas_IdEstatusRegistroNavigationIdEstatusRegistroNavi~",
                table: "TblEmpresas",
                column: "IdEstatusRegistroNavigationIdEstatusRegistroNavigationIdEstatus~");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductoPromociones_IdProductoNavigationIdCategoriaNaviga~",
                table: "TblProductoPromociones",
                column: "IdProductoNavigationIdCategoriaNavigationIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TblProveedorContactos_IdProveedorNavigationIdProveedorNaviga~",
                table: "TblProveedorContactos",
                column: "IdProveedorNavigationIdProveedorNavigationIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_TblProveedorDirecciones_IdProveedorNavigationIdProveedorNavi~",
                table: "TblProveedorDirecciones",
                column: "IdProveedorNavigationIdProveedorNavigationIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_TblProveedores_IdEmpresaNavigationIdEmpresaNavigationIdEmpre~",
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
