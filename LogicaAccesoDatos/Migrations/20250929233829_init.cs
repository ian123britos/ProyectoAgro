using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "caracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    EsUsado = table.Column<bool>(type: "bit", nullable: false),
                    UnicoDuenio = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeCombustible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barrio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direcciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "maquinarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    CaracteristicaId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    OtrasCaracteristicas_CaracteristicasFaltantes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cilindro = table.Column<int>(type: "int", nullable: true),
                    CargadoraPala_MarcaMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCosechadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacidadDeCarga = table.Column<int>(type: "int", nullable: true),
                    EsRuedaDual = table.Column<bool>(type: "bit", nullable: true),
                    MarcaMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Potencia = table.Column<int>(type: "int", nullable: true),
                    DobleTraccion = table.Column<bool>(type: "bit", nullable: true),
                    TipoDeSembradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieneCabina = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maquinarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maquinarias_caracteristicas_CaracteristicaId",
                        column: x => x.CaracteristicaId,
                        principalTable: "caracteristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maquinarias_direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "direcciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Contrasenia_Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_EmailUsr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono_Tel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnaMaquinaId = table.Column<int>(type: "int", nullable: false),
                    TipoDePublicacion = table.Column<int>(type: "int", nullable: false),
                    ClienteVendeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FechaPublicacionVenta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioVenta = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_publicaciones_maquinarias_UnaMaquinaId",
                        column: x => x.UnaMaquinaId,
                        principalTable: "maquinarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_publicaciones_usuarios_ClienteVendeId",
                        column: x => x.ClienteVendeId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteCompraId = table.Column<int>(type: "int", nullable: false),
                    PublicacionCompradaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compras_publicaciones_PublicacionCompradaId",
                        column: x => x.PublicacionCompradaId,
                        principalTable: "publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compras_usuarios_ClienteCompraId",
                        column: x => x.ClienteCompraId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compras_ClienteCompraId",
                table: "compras",
                column: "ClienteCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_compras_PublicacionCompradaId",
                table: "compras",
                column: "PublicacionCompradaId");

            migrationBuilder.CreateIndex(
                name: "IX_maquinarias_CaracteristicaId",
                table: "maquinarias",
                column: "CaracteristicaId");

            migrationBuilder.CreateIndex(
                name: "IX_maquinarias_DireccionId",
                table: "maquinarias",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_ClienteVendeId",
                table: "publicaciones",
                column: "ClienteVendeId");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_UnaMaquinaId",
                table: "publicaciones",
                column: "UnaMaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RolId",
                table: "usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "publicaciones");

            migrationBuilder.DropTable(
                name: "maquinarias");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "caracteristicas");

            migrationBuilder.DropTable(
                name: "direcciones");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
