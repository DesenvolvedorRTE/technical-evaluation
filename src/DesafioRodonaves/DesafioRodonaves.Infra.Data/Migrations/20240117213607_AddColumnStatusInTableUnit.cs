using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioRodonaves.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnStatusInTableUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "unidades",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "unidades");
        }
    }
}
