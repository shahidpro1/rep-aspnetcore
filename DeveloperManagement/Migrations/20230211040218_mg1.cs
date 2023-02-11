using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperManagement.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "DeveloperId", "Age", "JobTitle", "Name" },
                values: new object[] { 1, 27, "Jr. Developer 1", "Ali" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "DeveloperId", "Age", "JobTitle", "Name" },
                values: new object[] { 2, 29, "Jr. Developer 2", "Osman" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "DeveloperId", "Age", "JobTitle", "Name" },
                values: new object[] { 3, 37, "Sr. Developer 1", "Subhan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
