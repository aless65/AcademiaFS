using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaFS.Proyecto.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    IdColaborador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Identidad = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    IdMunicipio = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuaModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores_IdColaborador", x => x.IdColaborador);
                });

            migrationBuilder.CreateTable(
                name: "EstadosCiviles",
                columns: table => new
                {
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuaModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCiviles_IdEstadoCivil", x => x.IdEstadoCivil);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolEstado = table.Column<bool>(type: "bit", nullable: true),
                    RolUsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    RolFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolUsuaModificacion = table.Column<int>(type: "int", nullable: true),
                    RolFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    IdMunicipio = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuaModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales_IdSucursal", x => x.IdSucursal);
                });

            migrationBuilder.CreateTable(
                name: "Transportistas",
                columns: table => new
                {
                    IdTransportista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Identidad = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    TarifaKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuaModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportistas_IdTransportista", x => x.IdTransportista);
                });

            migrationBuilder.CreateTable(
                name: "SucursalesXColaboradores",
                columns: table => new
                {
                    IdSucursalXColaborador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    DistanciaKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalesXColaboradores_IdSucursalXColaborador", x => x.IdSucursalXColaborador);
                    table.ForeignKey(
                        name: "FK_SucursalesXColaboradores_Colaboradores_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Colaboradores",
                        principalColumn: "IdColaborador");
                });

            migrationBuilder.CreateTable(
                name: "tbUsuarios",
                columns: table => new
                {
                    usua_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usua_Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    usua_Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usua_Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usua_EsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    role_Id = table.Column<int>(type: "int", nullable: true),
                    usua_Estado = table.Column<bool>(type: "bit", nullable: true),
                    usua_UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    usua_FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    usua_UsuaModificacion = table.Column<int>(name: "usua_UsuaModificacion ", type: "int", nullable: true),
                    usua_FechaModificacion = table.Column<DateTime>(name: "usua_FechaModificacion ", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acce_tbUsuarios_usua_Id", x => x.usua_Id);
                    table.ForeignKey(
                        name: "FK_acce_tbUsuarios_tbRoles_role_Id",
                        column: x => x.role_Id,
                        principalTable: "Rol",
                        principalColumn: "RolId");
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    IdViaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaYHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    TarifaActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    IdTransportista = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuaModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdTransportistaNavigationIdTransportista = table.Column<int>(type: "int", nullable: false),
                    SucursaleIdSucursal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes_IdViaje", x => x.IdViaje);
                    table.ForeignKey(
                        name: "FK_Viajes_Sucursales_SucursaleIdSucursal",
                        column: x => x.SucursaleIdSucursal,
                        principalTable: "Sucursales",
                        principalColumn: "IdSucursal");
                    table.ForeignKey(
                        name: "FK_Viajes_Transportistas_IdTransportistaNavigationIdTransportista",
                        column: x => x.IdTransportistaNavigationIdTransportista,
                        principalTable: "Transportistas",
                        principalColumn: "IdTransportista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViajeDetalles",
                columns: table => new
                {
                    IdViajeDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdViaje = table.Column<int>(type: "int", nullable: false),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    DistanciaActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UsuaCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuaModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdViajeNavigationIdViaje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajesDetalles_IdViajeDetalle", x => x.IdViajeDetalle);
                    table.ForeignKey(
                        name: "FK_ViajeDetalles_Colaboradores_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Colaboradores",
                        principalColumn: "IdColaborador");
                    table.ForeignKey(
                        name: "FK_ViajeDetalles_Viajes_IdViajeNavigationIdViaje",
                        column: x => x.IdViajeNavigationIdViaje,
                        principalTable: "Viajes",
                        principalColumn: "IdViaje",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UC_Colaboradores_Identidad",
                table: "Colaboradores",
                column: "Identidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UC_EstadosCiviles_Nombre",
                table: "EstadosCiviles",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UC_Sucursales_Nombre",
                table: "Sucursales",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SucursalesXColaboradores_IdColaborador",
                table: "SucursalesXColaboradores",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "UC_SucursalesXColaboradores_IdSucursal_IdColaborador",
                table: "SucursalesXColaboradores",
                columns: new[] { "IdSucursal", "IdColaborador" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbUsuarios_role_Id",
                table: "tbUsuarios",
                column: "role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbUsuarios_usua_Nombre",
                table: "tbUsuarios",
                column: "usua_Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UC_Transportistas_Identidad",
                table: "Transportistas",
                column: "Identidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDetalles_IdColaborador",
                table: "ViajeDetalles",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDetalles_IdViajeNavigationIdViaje",
                table: "ViajeDetalles",
                column: "IdViajeNavigationIdViaje");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_IdTransportistaNavigationIdTransportista",
                table: "Viajes",
                column: "IdTransportistaNavigationIdTransportista");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_SucursaleIdSucursal",
                table: "Viajes",
                column: "SucursaleIdSucursal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosCiviles");

            migrationBuilder.DropTable(
                name: "SucursalesXColaboradores");

            migrationBuilder.DropTable(
                name: "tbUsuarios");

            migrationBuilder.DropTable(
                name: "ViajeDetalles");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Transportistas");
        }
    }
}
