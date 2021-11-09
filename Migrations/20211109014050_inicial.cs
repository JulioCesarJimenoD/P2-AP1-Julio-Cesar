using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Julio_Cesar.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Total = table.Column<int>(type: "INTEGER", nullable: false),
                    DecripcionProyecto = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

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

            migrationBuilder.CreateTable(
                name: "ProyectosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTareaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_TiposTareas_TipoTareaId",
                        column: x => x.TipoTareaId,
                        principalTable: "TiposTareas",
                        principalColumn: "TipoTareaId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_ProyectoId",
                table: "ProyectosDetalle",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_TipoTareaId",
                table: "ProyectosDetalle",
                column: "TipoTareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectosDetalle");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "TiposTareas");
        }
    }
}
