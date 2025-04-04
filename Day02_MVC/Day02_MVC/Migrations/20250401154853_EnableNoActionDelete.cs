

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day02_MVC.Migrations
{
	/// <inheritdoc />
	public partial class EnableNoActionDelete : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_StuCrsResults_Students_StudentId",
				table: "StuCrsResults");

			migrationBuilder.AddForeignKey(
				name: "FK_StuCrsResults_Students_StudentId",
				table: "StuCrsResults",
				column: "StudentId",
				principalTable: "Students",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_StuCrsResults_Students_StudentId",
				table: "StuCrsResults");

			migrationBuilder.AddForeignKey(
				name: "FK_StuCrsResults_Students_StudentId",
				table: "StuCrsResults",
				column: "StudentId",
				principalTable: "Students",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
