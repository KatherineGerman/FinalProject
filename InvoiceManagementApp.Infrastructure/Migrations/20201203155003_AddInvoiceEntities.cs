using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceManagementApp.Infrastructure.Migrations
{
    public partial class AddInvoiceEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createBy = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FacturaNum = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TerminosPago = table.Column<string>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(nullable: true),
                    Descuento = table.Column<double>(nullable: false),
                    TipoDescuento = table.Column<int>(nullable: false),
                    Impuesto = table.Column<double>(nullable: false),
                    TipoImpuesto = table.Column<int>(nullable: false),
                    MontoPago = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createBy = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FacturaId = table.Column<int>(nullable: false),
                    Articulo = table.Column<string>(nullable: true),
                    Cantidad = table.Column<double>(nullable: false),
                    Tarifa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticulosFactura_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosFactura_FacturaId",
                table: "ArticulosFactura",
                column: "FacturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosFactura");

            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
