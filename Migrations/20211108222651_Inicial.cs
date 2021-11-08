using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Julio_Cesar.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposTareas",
                columns: table => new
                {
                    TipoTareaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Acomulado = table.Column<int>(type: "INTEGER", nullable: false),
                    DecripcionTipoTarea = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTareas", x => x.TipoTareaId);
                });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "Acomulado", "DecripcionTipoTarea" },
                values: new object[] { 1, 0, "Analisis" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "Acomulado", "DecripcionTipoTarea" },
                values: new object[] { 2, 0, "Diseño" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "Acomulado", "DecripcionTipoTarea" },
                values: new object[] { 3, 0, "Programacion" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "Acomulado", "DecripcionTipoTarea" },
                values: new object[] { 4, 0, "Prueba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposTareas");
        }
    }
}
