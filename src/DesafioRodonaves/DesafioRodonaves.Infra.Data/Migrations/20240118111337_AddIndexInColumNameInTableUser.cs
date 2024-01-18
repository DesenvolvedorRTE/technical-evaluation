using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioRodonaves.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexInColumNameInTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_usuarios_nome_do_usuario",
                table: "usuarios",
                column: "nome_do_usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_usuarios_nome_do_usuario",
                table: "usuarios");
        }
    }
}
