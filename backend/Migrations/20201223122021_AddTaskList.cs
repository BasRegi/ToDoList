using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddTaskList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskListId",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_TaskListId",
                table: "ToDoItems",
                column: "TaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_TaskList_TaskListId",
                table: "ToDoItems",
                column: "TaskListId",
                principalTable: "TaskList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_TaskList_TaskListId",
                table: "ToDoItems");

            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_TaskListId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "TaskListId",
                table: "ToDoItems");
        }
    }
}
