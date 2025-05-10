using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsLibraryData.Migrations
{
    /// <inheritdoc />
    public partial class namkeDirectorNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Persons_DirectorId",
                table: "Films");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorId",
                table: "Films",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Persons_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Persons_DirectorId",
                table: "Films");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorId",
                table: "Films",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Persons_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
