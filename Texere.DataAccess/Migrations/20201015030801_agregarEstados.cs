using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Texere.DataAccess.Migrations
{
    public partial class agregarEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    AccesorioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescAccesorio = table.Column<string>(maxLength: 20, nullable: true),
                    TieneTalle = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.AccesorioId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DniCuit = table.Column<string>(maxLength: 15, nullable: true),
                    NombreApellido = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    Domicilio = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescMaterial = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModeloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescModelo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModeloId);
                });

            migrationBuilder.CreateTable(
                name: "Talles",
                columns: table => new
                {
                    TalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTalle = table.Column<string>(maxLength: 20, nullable: true),
                    Medida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talles", x => x.TalleId);
                });

            migrationBuilder.CreateTable(
                name: "PrecioAccesorio",
                columns: table => new
                {
                    PrecioAccesorioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVigencia = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    AccesorioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioAccesorio", x => x.PrecioAccesorioId);
                    table.ForeignKey(
                        name: "FK_PrecioAccesorio_Accesorios_AccesorioId",
                        column: x => x.AccesorioId,
                        principalTable: "Accesorios",
                        principalColumn: "AccesorioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColoresModelos",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false),
                    ModeloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColoresModelos", x => new { x.ColorId, x.ModeloId });
                    table.ForeignKey(
                        name: "FK_ColoresModelos_Colores_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colores",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColoresModelos_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "ModeloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instituciones",
                columns: table => new
                {
                    InstitucionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 60, nullable: true),
                    ModeloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituciones", x => x.InstitucionId);
                    table.ForeignKey(
                        name: "FK_Instituciones_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "ModeloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineasPedido",
                columns: table => new
                {
                    LineaPedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(maxLength: 50, nullable: true),
                    PedidoId = table.Column<int>(nullable: true),
                    TalleId = table.Column<int>(nullable: true),
                    AccesorioId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    ModeloId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasPedido", x => x.LineaPedidoId);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Accesorios_AccesorioId",
                        column: x => x.AccesorioId,
                        principalTable: "Accesorios",
                        principalColumn: "AccesorioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "ModeloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Talles_TalleId",
                        column: x => x.TalleId,
                        principalTable: "Talles",
                        principalColumn: "TalleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accesorios",
                columns: new[] { "AccesorioId", "DescAccesorio", "TieneTalle" },
                values: new object[,]
                {
                    { 1, "Cuello", true },
                    { 2, "Puño", false },
                    { 3, "Cintura", false }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "DniCuit", "Domicilio", "Email", "NombreApellido", "Telefono" },
                values: new object[,]
                {
                    { 1, "111111", "Mitre 587", "nortiz@gmail.com", "Nazareno Ortiz", "48756632" },
                    { 2, "222222", "Corrientes 2150", "aolivo@gmail.com", "Adrián Olivo", "43215874" },
                    { 3, "333333", "Pellegrini 1243", "mjuarez@gmail.com", "Melina Juarez", "43658740" }
                });

            migrationBuilder.InsertData(
                table: "Colores",
                columns: new[] { "ColorId", "Descripcion" },
                values: new object[,]
                {
                    { 12, "Gris Melange" },
                    { 11, "Naranja" },
                    { 10, "Amarillo" },
                    { 9, "Negro" },
                    { 8, "Verde Oliva" },
                    { 7, "Verde Inglés" },
                    { 13, "Gris Claro" },
                    { 5, "Azul Marino Claro" },
                    { 4, "Azul Marino" },
                    { 3, "Rojo Sangre" },
                    { 2, "Verde Benetton" },
                    { 1, "Blanco" },
                    { 6, "Blanco Óptico" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "En Curso" },
                    { 3, "Finalizado" },
                    { 4, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Instituciones",
                columns: new[] { "InstitucionId", "Descripcion", "ModeloId" },
                values: new object[,]
                {
                    { 45, "Colegio Nuestra Sra. De La Paz", null },
                    { 44, "Colegio Normal", null },
                    { 43, "Colegio Niño Jesús", null },
                    { 42, "Colegio Natividad", null },
                    { 41, "Colegio Misericordia", null },
                    { 40, "Colegio Mirasoles", null },
                    { 35, "Colegio Madre Cabrini", null },
                    { 38, "Colegio Maristas", null },
                    { 37, "Colegio María Madre", null },
                    { 36, "Colegio Manantiales", null },
                    { 34, "Colegio Luján", null },
                    { 46, "Colegio Padre Claret", null },
                    { 39, "Colegio Mater Dei", null },
                    { 47, "Colegio Pompeya", null },
                    { 59, "Colegio Santísimo Rosario", null },
                    { 49, "Colegio Sabin", null },
                    { 50, "Colegio Sagrada Familia", null },
                    { 51, "Colegio Sagrado Corazón", null },
                    { 52, "Colegio San Francisco De Asís", null },
                    { 53, "Colegio San Jorge", null },
                    { 54, "Colegio San Martín", null },
                    { 55, "Colegio San Pablo", null },
                    { 56, "Colegio San Patricio", null },
                    { 57, "Colegio San Ramón", null },
                    { 58, "Colegio Santa Teresita", null },
                    { 33, "Colegio Los Arroyos", null },
                    { 60, "Colegio Teodelina", null },
                    { 61, "Colegio Urquiza", null },
                    { 62, "Colegio Verbo Encarnado", null },
                    { 48, "Colegio Prefectura", null },
                    { 32, "Colegio Los Ángeles", null },
                    { 26, "Colegio Latino", null },
                    { 30, "Colegio Leloir", null },
                    { 1, "Colegio Adoratrices", null },
                    { 2, "Colegio Adventista", null },
                    { 3, "Colegio Alvear", null },
                    { 4, "Colegio Arrayanes", null },
                    { 5, "Colegio Asunción", null },
                    { 6, "Colegio Boneo", null },
                    { 7, "Colegio Brigadier López", null },
                    { 8, "Colegio Buen Samaritano", null },
                    { 31, "Colegio López", null },
                    { 10, "Colegio Comercio", null },
                    { 11, "Colegio Complejo Alberdi", null },
                    { 12, "Colegio Cooperación", null },
                    { 13, "Colegio Cristo Rey", null },
                    { 14, "Colegio Dante Alighieri", null },
                    { 9, "Colegio Cayetano Errico", null },
                    { 16, "Colegio Divino Maestro", null },
                    { 15, "Colegio Del Sur", null },
                    { 28, "Colegio La Merced", null },
                    { 27, "Colegio La Guardia", null },
                    { 25, "Colegio Instituto Sur", null },
                    { 24, "Colegio Guadalupe", null },
                    { 23, "Colegio Grognet", null },
                    { 29, "Colegio La Salle", null },
                    { 21, "Colegio Gianelli", null },
                    { 20, "Colegio Fuente De Vida", null },
                    { 19, "Colegio Español", null },
                    { 18, "Colegio El Huerto", null },
                    { 17, "Colegio Edmondo", null },
                    { 22, "Colegio Gomara", null }
                });

            migrationBuilder.InsertData(
                table: "Materiales",
                columns: new[] { "MaterialId", "DescMaterial" },
                values: new object[,]
                {
                    { 1, "Algodón" },
                    { 2, "Poliéster" },
                    { 3, "Acrílico" }
                });

            migrationBuilder.InsertData(
                table: "Talles",
                columns: new[] { "TalleId", "DescTalle", "Medida" },
                values: new object[,]
                {
                    { 8, "Talle L", 42 },
                    { 7, "Talle M", 40 },
                    { 6, "Talle S", 38 },
                    { 5, "Talle 16 (XS)", 36 },
                    { 1, "Talle 8", 28 },
                    { 3, "Talle 12", 32 },
                    { 2, "Talle 10", 30 },
                    { 9, "Talle XL", 44 },
                    { 4, "Talle 14", 34 },
                    { 10, "Talle XXL", 46 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColoresModelos_ModeloId",
                table: "ColoresModelos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Instituciones_ModeloId",
                table: "Instituciones",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_AccesorioId",
                table: "LineasPedido",
                column: "AccesorioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_EstadoId",
                table: "LineasPedido",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_MaterialId",
                table: "LineasPedido",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_ModeloId",
                table: "LineasPedido",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_PedidoId",
                table: "LineasPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_TalleId",
                table: "LineasPedido",
                column: "TalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EstadoId",
                table: "Pedidos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioAccesorio_AccesorioId",
                table: "PrecioAccesorio",
                column: "AccesorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColoresModelos");

            migrationBuilder.DropTable(
                name: "Instituciones");

            migrationBuilder.DropTable(
                name: "LineasPedido");

            migrationBuilder.DropTable(
                name: "PrecioAccesorio");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Talles");

            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
