using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THE_SPOT.Migrations
{
    public partial class DeptEmployeePR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeptEmployeePR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qty = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemPrice = table.Column<float>(type: "real", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptEmployeePR", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeptEmployeePR");
        }
    }
}
