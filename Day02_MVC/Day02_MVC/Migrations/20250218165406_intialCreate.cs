using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day02_MVC.Migrations
{
	/// <inheritdoc />
	public partial class intialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Departments",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Departments", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Courses",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Degree = table.Column<float>(type: "real", nullable: false),
					MinDegree = table.Column<float>(type: "real", nullable: false),
					DepartmentId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Courses", x => x.Id);
					table.ForeignKey(
						name: "FK_Courses_Departments_DepartmentId",
						column: x => x.DepartmentId,
						principalTable: "Departments",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Students",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Age = table.Column<int>(type: "int", nullable: false),
					DepartmentId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Students", x => x.Id);
					table.ForeignKey(
						name: "FK_Students_Departments_DepartmentId",
						column: x => x.DepartmentId,
						principalTable: "Departments",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Teachers",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
					DepartmentId = table.Column<int>(type: "int", nullable: false),
					CourseId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Teachers", x => x.Id);
					table.ForeignKey(
						name: "FK_Teachers_Courses_CourseId",
						column: x => x.CourseId,
						principalTable: "Courses",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_Teachers_Departments_DepartmentId",
						column: x => x.DepartmentId,
						principalTable: "Departments",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "StuCrsResults",
				columns: table => new
				{
					CourseId = table.Column<int>(type: "int", nullable: false),
					StudentId = table.Column<int>(type: "int", nullable: false),
					Grade = table.Column<float>(type: "real", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StuCrsResults", x => new { x.StudentId, x.CourseId });
					table.ForeignKey(
						name: "FK_StuCrsResults_Courses_CourseId",
						column: x => x.CourseId,
						principalTable: "Courses",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_StuCrsResults_Students_StudentId",
						column: x => x.StudentId,
						principalTable: "Students",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Courses_DepartmentId",
				table: "Courses",
				column: "DepartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_StuCrsResults_CourseId",
				table: "StuCrsResults",
				column: "CourseId");

			migrationBuilder.CreateIndex(
				name: "IX_Students_DepartmentId",
				table: "Students",
				column: "DepartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_Teachers_CourseId",
				table: "Teachers",
				column: "CourseId");

			migrationBuilder.CreateIndex(
				name: "IX_Teachers_DepartmentId",
				table: "Teachers",
				column: "DepartmentId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "StuCrsResults");

			migrationBuilder.DropTable(
				name: "Teachers");

			migrationBuilder.DropTable(
				name: "Students");

			migrationBuilder.DropTable(
				name: "Courses");

			migrationBuilder.DropTable(
				name: "Departments");
		}
	}
}
