using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace slotlib.data.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsibilityTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Responsibilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResponsibilityTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibilityTemplates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsibilities_TemplateId_TaskDate_Shift",
                table: "Responsibilities",
                columns: new[] { "TemplateId", "TaskDate", "Shift" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibilities_ResponsibilityTemplates_TemplateId",
                table: "Responsibilities",
                column: "TemplateId",
                principalTable: "ResponsibilityTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsibilities_ResponsibilityTemplates_TemplateId",
                table: "Responsibilities");

            migrationBuilder.DropTable(
                name: "ResponsibilityTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Responsibilities_TemplateId_TaskDate_Shift",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Responsibilities");
        }
    }
}
