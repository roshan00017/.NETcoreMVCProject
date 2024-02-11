using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password", "UserName" },
                values: new object[] { 1, "john@example.com", "password", "john_doe" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password", "UserName" },
                values: new object[] { 2, "jane@example.com", "password", "jane_doe" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password", "UserName" },
                values: new object[] { 3, "mike@example.com", "password", "mike_miles" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, 1, new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4039), 1, new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4054), "Category 1" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 2, 2, new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4055), 2, new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4056), "Category 2" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 3, 1, new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4057), 1, new DateTime(2024, 2, 11, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4058), "Category 3" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "CategoryId", "Description", "DueDate", "IsCompleted", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Description 1", new DateTime(2024, 2, 18, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4264), true, "Task 1", 1 },
                    { 2, 1, "Description 2", new DateTime(2024, 2, 25, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4279), false, "Task 2", 2 },
                    { 3, 2, "Description 3", new DateTime(2024, 3, 3, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4281), false, "Task 3", 1 },
                    { 4, 2, "Description 4", new DateTime(2024, 3, 10, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4282), false, "Task 4", 2 },
                    { 5, 3, "Description 5", new DateTime(2024, 3, 17, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4283), false, "Task 5", 1 },
                    { 6, 3, "Description 6", new DateTime(2024, 3, 24, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4285), false, "Task 6", 2 },
                    { 7, 1, "Description 7", new DateTime(2024, 3, 31, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4286), false, "Task 7", 1 },
                    { 8, 1, "Description 8", new DateTime(2024, 4, 7, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4288), false, "Task 8", 2 },
                    { 9, 2, "Description 9", new DateTime(2024, 4, 14, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4289), false, "Task 9", 1 },
                    { 10, 2, "Description 10", new DateTime(2024, 4, 21, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4290), false, "Task 10", 2 },
                    { 11, 3, "Description 11", new DateTime(2024, 4, 28, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4293), false, "Task 11", 1 },
                    { 12, 3, "Description 12", new DateTime(2024, 5, 5, 18, 32, 18, 653, DateTimeKind.Local).AddTicks(4294), false, "Task 12", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreatedBy",
                table: "Category",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ModifiedBy",
                table: "Category",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CategoryId",
                table: "Task",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserId",
                table: "Task",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
