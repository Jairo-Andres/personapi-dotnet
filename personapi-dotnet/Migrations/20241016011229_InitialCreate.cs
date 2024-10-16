using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personapi_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    cc = table.Column<long>(type: "bigint", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    genero = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__persona__3213666D0C8EDE94", x => x.cc);
                });

            migrationBuilder.CreateTable(
                name: "profesion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    des = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__profesio__3213E83FA37B88C0", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "telefono",
                columns: table => new
                {
                    num = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    oper = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    duenio = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__telefono__DF908D65862EB666", x => x.num);
                    table.ForeignKey(
                        name: "FK_telefono_persona",
                        column: x => x.duenio,
                        principalTable: "persona",
                        principalColumn: "cc");
                });

            migrationBuilder.CreateTable(
                name: "estudios",
                columns: table => new
                {
                    id_prof = table.Column<int>(type: "int", nullable: false),
                    cc_per = table.Column<long>(type: "bigint", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    univer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__estudios__FB3F71A6AED01524", x => new { x.id_prof, x.cc_per });
                    table.ForeignKey(
                        name: "FK_estudio_persona",
                        column: x => x.cc_per,
                        principalTable: "persona",
                        principalColumn: "cc");
                    table.ForeignKey(
                        name: "FK_estudio_profesion",
                        column: x => x.id_prof,
                        principalTable: "profesion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudios_cc_per",
                table: "estudios",
                column: "cc_per");

            migrationBuilder.CreateIndex(
                name: "IX_telefono_duenio",
                table: "telefono",
                column: "duenio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudios");

            migrationBuilder.DropTable(
                name: "telefono");

            migrationBuilder.DropTable(
                name: "profesion");

            migrationBuilder.DropTable(
                name: "persona");
        }
    }
}
