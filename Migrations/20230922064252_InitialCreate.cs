using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvoApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avocados",
                columns: table => new
                {
                    AvocadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalVolume = table.Column<decimal>(type: "TEXT", nullable: false),
                    Plu4046 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Plu4225 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Plu4770 = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalBags = table.Column<decimal>(type: "TEXT", nullable: false),
                    SmallBags = table.Column<decimal>(type: "TEXT", nullable: false),
                    LargeBags = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExtraLargeBags = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avocados", x => x.AvocadoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avocados");
        }
    }
}
