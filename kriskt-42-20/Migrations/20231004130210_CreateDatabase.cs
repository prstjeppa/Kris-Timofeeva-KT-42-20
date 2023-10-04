using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kriskt_42_20.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_kafedra",
                columns: table => new
                {
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_kafedra_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_kafedra_kafedra_id", x => x.kafedra_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_prepod",
                columns: table => new
                {
                    prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_firstname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_student_lastname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_student_middlename = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_prepod_prepod_id", x => x.prepod_id);
                    table.ForeignKey(
                        name: "fk_f_kafedra_id",
                        column: x => x.kafedra_id,
                        principalTable: "cd_kafedra",
                        principalColumn: "kafedra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_prepod_fk_f_kafedra_id",
                table: "cd_prepod",
                column: "kafedra_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_prepod");

            migrationBuilder.DropTable(
                name: "cd_kafedra");
        }
    }
}
