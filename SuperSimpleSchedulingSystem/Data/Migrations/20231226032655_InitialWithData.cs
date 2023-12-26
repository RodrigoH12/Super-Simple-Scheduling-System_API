using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperSimpleSchedulingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Class",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Schedule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudent",
                schema: "dbo",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudent", x => new { x.ClassId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ClassStudent_Class_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "dbo",
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "dbo",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Class",
                columns: new[] { "Id", "Description", "Schedule", "Teacher", "Title" },
                values: new object[,]
                {
                    { new Guid("08cb5f72-944f-4e9c-9e94-08db4d6c094c"), "Explore the best practices in software engineering for creating maintainable and scalable applications.", 3, "Henry White", "Software Engineering Best Practices" },
                    { new Guid("2f29c595-2e96-40d5-9e86-08db4d6c094c"), "In this class you will learn the fundamentals of Javascript thanks to the realization of multiple projects", 0, "Jhon Petersonn", "Introduction to Programming with Javascript" },
                    { new Guid("4c84c62b-b98f-4670-9e88-08db4d6c094c"), "Learn the basics of web development, including HTML, CSS, and JavaScript.", 2, "Bob Smith", "Web Development Basics" },
                    { new Guid("646a14a8-9a45-4c79-9e87-08db4d6c094c"), "Understand the principles of database design and master SQL for effective data management.", 0, "Charlie Brown", "Database Design and SQL" },
                    { new Guid("6eeab56d-9357-43a5-9e96-08db4d6c094c"), "Learn the essentials of network security, including encryption, firewalls, and intrusion detection.", 0, "Ivy Robinson", "Network Security" },
                    { new Guid("a0d208e3-2b70-4c31-9e8b-08db4d6c094c"), "Explore the fundamental concepts of data structures and algorithms, with hands-on coding exercises.", 1, "Alice Johnson", "Data Structures and Algorithms" },
                    { new Guid("a9bb7a24-f2bb-4faf-9e91-08db4d6c094c"), "Get an introduction to cloud computing and popular cloud platforms like AWS and Azure.", 1, "Jack Miller", "Cloud Computing Intermediate" },
                    { new Guid("b0a1221c-414f-45d6-9e92-08db4d6c094c"), "Dive into the basics of artificial intelligence and machine learning algorithms.", 2, "Grace Watson", "Artificial Intelligence Fundamentals" },
                    { new Guid("c791a7a4-625e-4a46-9e90-08db4d6c094c"), "Explore the basics of cybersecurity and learn essential techniques to secure computer systems.", 1, "Edward Turner", "Cybersecurity Fundamentals" },
                    { new Guid("d8276c8f-84e5-41fa-9e8c-08db4d6c094c"), "Build cross-platform mobile applications using React Native and modern JavaScript frameworks.", 3, "Diana Miller", "Mobile App Development with React Native" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("3b9ef2b3-44f4-4b0a-8c4a-08db4d6c094c"), "Pass123", "rodrigo.heredia" },
                    { new Guid("3c66c9fa-8759-45d7-9e8a-08db4d6c094c"), "He1loWorlD", "brian.anderson" },
                    { new Guid("4890f590-f25e-45d8-9e78-08db4d6c094c"), "12345.J", "john.peterson" },
                    { new Guid("61bc6e41-7d14-4cf2-9e87-08db4d6c094c"), "TestingTesting@", "jessica.brown" },
                    { new Guid("aa4fbdba-35f7-45b5-9e88-08db4d6c094c"), "Password321", "christopher.davies" },
                    { new Guid("b821e05d-873a-481e-8c4b-08db4d6c094c"), "CaMi!23", "camila.peredo" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Student",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("7fae9a91-4c35-4e57-9e83-08db4d6c094c"), "Camila", "Peredo", new Guid("b821e05d-873a-481e-8c4b-08db4d6c094c") },
                    { new Guid("9bc9a0ec-f5e1-42b5-9e82-08db4d6c094c"), "John", "Peterson", new Guid("4890f590-f25e-45d8-9e78-08db4d6c094c") },
                    { new Guid("a7f570f2-0b1b-4779-9e85-08db4d6c094c"), "Jessica", "Brown", new Guid("61bc6e41-7d14-4cf2-9e87-08db4d6c094c") },
                    { new Guid("e2d8cc80-29ca-45b1-9e89-08db4d6c094c"), "Brian", "Anderson", new Guid("3c66c9fa-8759-45d7-9e8a-08db4d6c094c") },
                    { new Guid("f5d72e55-a870-4f1a-9e80-08db4d6c094c"), "Rodrigo", "Heredia", new Guid("3b9ef2b3-44f4-4b0a-8c4a-08db4d6c094c") },
                    { new Guid("f98231c8-9d22-4c69-9e84-08db4d6c094c"), "Christopher", "Davis", new Guid("aa4fbdba-35f7-45b5-9e88-08db4d6c094c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_StudentId",
                schema: "dbo",
                table: "ClassStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                schema: "dbo",
                table: "Student",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Class",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
