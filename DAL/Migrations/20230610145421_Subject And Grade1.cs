using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SubjectAndGrade1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Professors_ProfessorId1",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ProfessorId1",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ProfessorId1",
                table: "Subjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId1",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ProfessorId1",
                table: "Subjects",
                column: "ProfessorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Professors_ProfessorId1",
                table: "Subjects",
                column: "ProfessorId1",
                principalTable: "Professors",
                principalColumn: "Id");
        }
    }
}
