using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ProfessorsAndSubjectsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "ProfessorId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Victor", "Vtorov" },
                    { 2, "Anastasiia", "Stotskaya" },
                    { 3, "Eduard", "Chernishov" },
                    { 4, "Alexander", "Zubarev" },
                    { 5, "Andrey", "Weinmeister" },
                    { 6, "Mikhail", "Kopichev" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Control Systems", 1 },
                    { 7, "Adaptive And Nonlinear Systems", 1 },
                    { 2, "LabView", 2 },
                    { 3, "Electrical Engineering", 3 },
                    { 4, "TOE", 4 },
                    { 5, "History", 5 },
                    { 6, "Microcontrollers", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 6);
        }
    }
}
