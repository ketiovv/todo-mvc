using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoMVC.Infrastructure.Migrations
{
    public partial class OverrideIdentityUserAndCreateRelationWithTodoLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TodoLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_ApplicationUserId",
                table: "TodoLists",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_AspNetUsers_ApplicationUserId",
                table: "TodoLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_AspNetUsers_ApplicationUserId",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_TodoLists_ApplicationUserId",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
