using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioRodonaves.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_da_unidade = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    codigo_da_unidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_do_usuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    permissoes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "colaboradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    id_unidade = table.Column<int>(type: "integer", nullable: false),
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colaboradores", x => x.id);
                    table.ForeignKey(
                        name: "FK_colaboradores_unidades_id_unidade",
                        column: x => x.id_unidade,
                        principalTable: "unidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_colaboradores_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_colaboradores_id_unidade",
                table: "colaboradores",
                column: "id_unidade");

            migrationBuilder.CreateIndex(
                name: "IX_colaboradores_id_usuario",
                table: "colaboradores",
                column: "id_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unidades_codigo_da_unidade",
                table: "unidades",
                column: "codigo_da_unidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unidades_nome_da_unidade",
                table: "unidades",
                column: "nome_da_unidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_nome_do_usuario",
                table: "usuarios",
                column: "nome_do_usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colaboradores");

            migrationBuilder.DropTable(
                name: "unidades");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
