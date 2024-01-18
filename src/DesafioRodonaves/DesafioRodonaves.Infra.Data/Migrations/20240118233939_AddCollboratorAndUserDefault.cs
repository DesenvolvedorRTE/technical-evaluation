using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioRodonaves.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCollboratorAndUserDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var unit = new
            {
                Id = 1,
                UnitName = "Unidade Padrão",
                UnitCode = "Codigo_12345",
                Status = true

            };
            migrationBuilder.InsertData(
                table: "unidades",
                columns: new[] { "id", "nome_da_unidade", "codigo_da_unidade", "status" },
                values: new object[] { unit.Id, unit.UnitName, unit.UnitCode, unit.Status }
            );

            var user = new
            {
                Id = 1,
                Login = "admin",
                Password = "Admin12345#@",
                Status = true

            };

            migrationBuilder.InsertData(
               table: "usuarios",
               columns: new[] { "id", "nome_do_usuario", "senha", "status" },
               values: new object[] { user.Id, user.Login, HashPassword(user.Password), user.Status }
           );

            var collaborator = new

            {
                Id = 1,
                Name = "admin",
                UnitId = 1,
                UserId = 1
               

            };

            migrationBuilder.InsertData(
               table: "colaboradores",
               columns: new[] { "id", "nome", "id_unidade", "id_usuario" },
               values: new object[] { collaborator.Id, collaborator.Name, collaborator.UnitId, collaborator.UserId }
           );


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

        private string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<object>();
            return passwordHasher.HashPassword(null, password);
        }
    }
}
