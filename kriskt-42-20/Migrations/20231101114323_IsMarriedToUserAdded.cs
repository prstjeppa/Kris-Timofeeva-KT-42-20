using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kriskt_42_20.Migrations
{
    /// <inheritdoc />
    public partial class IsMarriedToUserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_prepod_cd_degree_Academic_degreeDegreeId",
                table: "cd_prepod");

            migrationBuilder.RenameColumn(
                name: "Academic_degreeDegreeId",
                table: "cd_prepod",
                newName: "DegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_cd_prepod_Academic_degreeDegreeId",
                table: "cd_prepod",
                newName: "IX_cd_prepod_DegreeId");

            migrationBuilder.RenameColumn(
                name: "c_kafedra_name",
                table: "cd_kafedra",
                newName: "Название кафедры");

            migrationBuilder.RenameColumn(
                name: "kafedra_id",
                table: "cd_kafedra",
                newName: "Идентификатор записи кафедры");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_prepod_cd_degree_DegreeId",
                table: "cd_prepod",
                column: "DegreeId",
                principalTable: "cd_degree",
                principalColumn: "degree_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_prepod_cd_degree_DegreeId",
                table: "cd_prepod");

            migrationBuilder.RenameColumn(
                name: "DegreeId",
                table: "cd_prepod",
                newName: "Academic_degreeDegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_cd_prepod_DegreeId",
                table: "cd_prepod",
                newName: "IX_cd_prepod_Academic_degreeDegreeId");

            migrationBuilder.RenameColumn(
                name: "Название кафедры",
                table: "cd_kafedra",
                newName: "c_kafedra_name");

            migrationBuilder.RenameColumn(
                name: "Идентификатор записи кафедры",
                table: "cd_kafedra",
                newName: "kafedra_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_prepod_cd_degree_Academic_degreeDegreeId",
                table: "cd_prepod",
                column: "Academic_degreeDegreeId",
                principalTable: "cd_degree",
                principalColumn: "degree_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
