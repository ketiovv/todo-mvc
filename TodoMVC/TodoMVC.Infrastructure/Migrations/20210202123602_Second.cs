using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoMVC.Infrastructure.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoLists",
                newName: "ListName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListName",
                table: "TodoLists",
                newName: "Name");
        }
    }
}
