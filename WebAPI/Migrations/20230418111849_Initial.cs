using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "counties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counties", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    price = table.Column<int>(type: "int", nullable: false),
                    isOnline = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    subject = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    grade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    countyId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_teachers_counties_countyId",
                        column: x => x.countyId,
                        principalTable: "counties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.id);
                    table.ForeignKey(
                        name: "FK_lessons_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lessons_teachers_teacherId",
                        column: x => x.teacherId,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "counties",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Bács-Kiskun" },
                    { 2, "Baranya" },
                    { 3, "Békés" },
                    { 4, "Borsod-Abaúj-Zemplén" },
                    { 5, "Csongrád" },
                    { 6, "Fejér" },
                    { 7, "Győr-Moson-Sopron" },
                    { 8, "Hajdú-Bihar" },
                    { 9, "Heves" },
                    { 10, "Jász-Nagykun-Szolnok" },
                    { 11, "Komárom-Esztergom" },
                    { 12, "Nógrád" },
                    { 13, "Pest" },
                    { 14, "Somogy" },
                    { 15, "Szabolcs-Szatmár-Bereg" },
                    { 16, "Tolna" },
                    { 17, "Vas" },
                    { 18, "Veszprém" },
                    { 19, "Zala" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "email", "name", "phoneNumber" },
                values: new object[,]
                {
                    { 1, "patrik@gmail.com", "Magyar Patrik", "06201234567" },
                    { 2, "zsombi@gmail.com", "Novák Zsombor", "06301234567" },
                    { 3, "jakab@gmail.com", "Gipsz Jakab", "06701234567" }
                });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "id", "countyId", "email", "grade", "isOnline", "name", "phoneNumber", "price", "subject" },
                values: new object[,]
                {
                    { 1, 1, "bela@gmail.com", "8. osztály", false, "Kis Béla", "06706666969", 2000, "matek;angol;magyar;atomfizika" },
                    { 2, 2, "anna@gmail.com", "9. osztály", false, "Nagy Anna", "06304201234", 3000, "matek" }
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "id", "date", "studentId", "teacherId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 19, 17, 12, 49, 515, DateTimeKind.Local).AddTicks(4037), 1, 1 },
                    { 2, new DateTime(2023, 2, 27, 14, 9, 49, 515, DateTimeKind.Local).AddTicks(4106), 2, 1 },
                    { 3, new DateTime(2022, 8, 19, 3, 32, 49, 515, DateTimeKind.Local).AddTicks(4116), 3, 2 },
                    { 4, new DateTime(2023, 7, 17, 16, 51, 49, 515, DateTimeKind.Local).AddTicks(4124), 2, 2 },
                    { 5, new DateTime(2023, 5, 20, 19, 41, 49, 515, DateTimeKind.Local).AddTicks(4128), 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_lessons_studentId",
                table: "lessons",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_teacherId",
                table: "lessons",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_countyId",
                table: "teachers",
                column: "countyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "counties");
        }
    }
}
