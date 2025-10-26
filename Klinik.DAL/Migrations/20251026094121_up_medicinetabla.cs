using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klinik.DAL.Migrations
{
    /// <inheritdoc />
    public partial class up_medicinetabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicineRealStok",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineRealStok",
                table: "Medicines");
        }
    }
}
