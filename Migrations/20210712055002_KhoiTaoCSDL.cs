using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SE141048_VoQuocHuy_PE.Migrations
{
    public partial class KhoiTaoCSDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    proID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employee = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.proID);
                });

            migrationBuilder.CreateTable(
                name: "Deparments",
                columns: table => new
                {
                    depID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    depName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    married = table.Column<bool>(type: "bit", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    professorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparments", x => x.depID);
                    table.ForeignKey(
                        name: "FK_Deparments_Professors_professorID",
                        column: x => x.professorID,
                        principalTable: "Professors",
                        principalColumn: "proID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deparments_professorID",
                table: "Deparments",
                column: "professorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deparments");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
