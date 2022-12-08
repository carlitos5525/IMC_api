using Microsoft.EntityFrameworkCore.Migrations;

namespace icm_api.Migrations
{
    public partial class ajuste_imc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Imc_resultado",
                table: "Imcs",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imc_resultado",
                table: "Imcs");
        }
    }
}
