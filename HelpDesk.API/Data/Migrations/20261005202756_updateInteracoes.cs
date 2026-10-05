using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateInteracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interacao_Chamados_ChamadoId",
                table: "Interacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interacao",
                table: "Interacao");

            migrationBuilder.RenameTable(
                name: "Interacao",
                newName: "Interacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Interacao_ChamadoId",
                table: "Interacoes",
                newName: "IX_Interacoes_ChamadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interacoes",
                table: "Interacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interacoes_Chamados_ChamadoId",
                table: "Interacoes",
                column: "ChamadoId",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interacoes_Chamados_ChamadoId",
                table: "Interacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interacoes",
                table: "Interacoes");

            migrationBuilder.RenameTable(
                name: "Interacoes",
                newName: "Interacao");

            migrationBuilder.RenameIndex(
                name: "IX_Interacoes_ChamadoId",
                table: "Interacao",
                newName: "IX_Interacao_ChamadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interacao",
                table: "Interacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interacao_Chamados_ChamadoId",
                table: "Interacao",
                column: "ChamadoId",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
