using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterChamadoNomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Chamados",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Chamados",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Chamados",
                newName: "DataAbertura");

            migrationBuilder.RenameColumn(
                name: "requester",
                table: "Chamados",
                newName: "SolicitanteNome");

            migrationBuilder.RenameColumn(
                name: "evaluation",
                table: "Chamados",
                newName: "Solucao");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Chamados",
                newName: "DataFechamento");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Chamados",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "categoria",
                table: "Chamados",
                newName: "Prioridade");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Chamados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_CategoriaId",
                table: "Chamados",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Categoria_CategoriaId",
                table: "Chamados",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Categoria_CategoriaId",
                table: "Chamados");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_CategoriaId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Chamados");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Chamados",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Chamados",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Solucao",
                table: "Chamados",
                newName: "evaluation");

            migrationBuilder.RenameColumn(
                name: "SolicitanteNome",
                table: "Chamados",
                newName: "requester");

            migrationBuilder.RenameColumn(
                name: "Prioridade",
                table: "Chamados",
                newName: "categoria");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Chamados",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "DataFechamento",
                table: "Chamados",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "DataAbertura",
                table: "Chamados",
                newName: "startDate");
        }
    }
}
