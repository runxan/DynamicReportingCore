using Microsoft.EntityFrameworkCore.Migrations;

namespace DynaimcReporting.Migrations
{
    public partial class _InitalSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagramType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatabaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    ReportTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportMasters_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportMasters_ReportType_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "ReportType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterDataType = table.Column<int>(type: "int", nullable: false),
                    ReportMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportParameters_ReportMasters_ReportMasterId",
                        column: x => x.ReportMasterId,
                        principalTable: "ReportMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportMasters_CategorieId",
                table: "ReportMasters",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportMasters_ReportTypeId",
                table: "ReportMasters",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportParameters_ReportMasterId",
                table: "ReportParameters",
                column: "ReportMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportParameters");

            migrationBuilder.DropTable(
                name: "ReportMasters");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ReportType");
        }
    }
}
