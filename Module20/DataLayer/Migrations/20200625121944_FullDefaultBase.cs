using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class FullDefaultBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8);

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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "ProfessorId",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Attendance",
                columns: new[] { "AttendanceId", "Date", "IsStudentOnLecture", "Mark", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 1 },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 4, 2 },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 4, 2 },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 4, 2 },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 4, 2 },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 2 },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 1 },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 1 },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 1 },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 1 },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 1 },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 3, 3 },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 3, 3 },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 3, 3 },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 3, 3 },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 3, 3 },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 4, 3 },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 3, 2 },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 4, 3 },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 4, 3 },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 3 },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 3 },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 3 },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 3 },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 2 },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 2 },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 2 },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 2 },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 2 },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 1 },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 1 },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 1 },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 1 },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 1 },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 3 },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 4, 3 },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 3, 2 },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 3, 2 },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 3, 2 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 1 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1, 3 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1, 3 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1, 3 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1, 3 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1, 3 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 1, 2 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 1, 2 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 1, 2 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 1, 2 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 2 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 1 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 1 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 1 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 1 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 1 },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 3, 2 },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 3, 1 },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 3, 1 },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 3, 1 },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 3, 1 },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 3, 1 },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 2, 3 },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 3 },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 2, 3 },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 2, 3 },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 2, 3 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 2 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 2 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 2 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 2 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 2 },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Name", "ProfessorId" },
                values: new object[] { 4, "Adaptive And Nonlinear Systems", 1 });

            migrationBuilder.InsertData(
                table: "Attendance",
                columns: new[] { "AttendanceId", "Date", "IsStudentOnLecture", "Mark", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 4 },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 4 },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 4 },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 4 },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 4 },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 4, 4 },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 4, 4 },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 4 },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4, 4 },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, 3, 4 },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, 3, 4 },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 4 },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, 3, 4 },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, 3, 4 },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 4 },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 2, 4 },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 2, 4 },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 4 },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2, 4 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 4 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1, 4 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 1, 4 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1, 4 },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0, 3, 4 },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 5, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 100);

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "ProfessorId", "Name", "Surname" },
                values: new object[,]
                {
                    { 4, "Alexander", "Zubarev" },
                    { 5, "Andrey", "Weinmeister" },
                    { 6, "Mikhail", "Kopichev" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Name", "Surname" },
                values: new object[,]
                {
                    { 6, "Alexander", "Enotov" },
                    { 7, "Kirill", "Ofitserov" },
                    { 8, "Egor", "Sorokin" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Name", "ProfessorId" },
                values: new object[] { 7, "Adaptive And Nonlinear Systems", 1 });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 4,
                columns: new[] { "Name", "ProfessorId" },
                values: new object[] { "TOE", 4 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Name", "ProfessorId" },
                values: new object[] { 5, "History", 5 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Name", "ProfessorId" },
                values: new object[] { 6, "Microcontrollers", 6 });
        }
    }
}
