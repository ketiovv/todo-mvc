using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoMVC.Infrastructure.Migrations
{
    public partial class ChangeRelationConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoListId",
                table: "TodoItems",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_TodoListId",
                table: "TodoItems",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_TodoListId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodoListId",
                table: "TodoItems");
        }
    }
}
