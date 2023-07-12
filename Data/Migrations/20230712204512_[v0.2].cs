using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMvc.Data.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShinobiName",
                table: "Shinobi");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shinobi",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NinjaClan",
                columns: table => new
                {
                    NinjaClanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShinobiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinjaClan", x => x.NinjaClanId);
                    table.ForeignKey(
                        name: "FK_NinjaClan_Shinobi_ShinobiId",
                        column: x => x.ShinobiId,
                        principalTable: "Shinobi",
                        principalColumn: "ShinobiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NinjaClan_ShinobiId",
                table: "NinjaClan",
                column: "ShinobiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NinjaClan");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shinobi");

            migrationBuilder.AddColumn<string>(
                name: "ShinobiName",
                table: "Shinobi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
