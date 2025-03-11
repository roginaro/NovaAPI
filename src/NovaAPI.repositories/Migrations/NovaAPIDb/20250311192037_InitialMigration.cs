using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovaAPI.Repositories.Migrations.NovaAPIDb
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "Varchar", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI"),
                    Description = table.Column<string>(type: "Varchar", maxLength: 200, nullable: false, collation: "Latin1_General_CI_AI"),
                    PRICE = table.Column<decimal>(type: "Money", precision: 2, nullable: false),
                    Image = table.Column<string>(type: "Varchar", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.PRODUCT_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
