using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_WEBAPI_BLAZOR.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "Italy", "Ferrari" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 2, "Italy", "Lamborghini" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 3, "Germany", "Porsche" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Engine", "ManufacturerId", "Model", "Year" },
                values: new object[] { 1, "Red", "V8 TWIN TURBO", 1, "488 PISTA", 2022 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Engine", "ManufacturerId", "Model", "Year" },
                values: new object[] { 2, "White", "V12", 2, "AVENTADOR", 2021 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Engine", "ManufacturerId", "Model", "Year" },
                values: new object[] { 3, "Silver", "V10", 3, "Carrera GT", 2006 });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
