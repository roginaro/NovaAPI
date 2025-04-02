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
                name: "TB_CUSTOMER",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(type: "Varchar", maxLength: 100, nullable: false, collation: "Latin1_General_CI_AI"),
                    DOCUMENT = table.Column<string>(type: "Varchar", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI"),
                    EMAIL = table.Column<string>(type: "Varchar", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI"),
                    PHONE = table.Column<string>(type: "Varchar", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI"),
                    ADDRESS = table.Column<string>(type: "Varchar", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CUSTOMER", x => x.CUSTOMER_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    NAME = table.Column<string>(type: "Varchar", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI"),
                    DESCRIPTION = table.Column<string>(type: "Varchar", maxLength: 200, nullable: false, collation: "Latin1_General_CI_AI"),
                    PRICE = table.Column<decimal>(type: "Money", precision: 2, nullable: false),
                    IMAGE = table.Column<string>(type: "Varchar", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.PRODUCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDER",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DATE = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NUMBER = table.Column<string>(type: "Varchar", maxLength: 100, nullable: false, collation: "Latin1_General_CI_AI"),
                    STATUS = table.Column<string>(type: "Varchar", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AI"),
                    CustomerId = table.Column<int>(type: "Varchar", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER", x => x.ORDER_ID);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_01",
                        column: x => x.CustomerId,
                        principalTable: "TB_CUSTOMER",
                        principalColumn: "CUSTOMER_ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDERPRODUCT",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDERPRODUCT", x => new { x.ORDER_ID, x.PRODUCT_ID });
                    table.ForeignKey(
                        name: "FK_TB_ORDERPRODUCT_TB_ORDER_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "TB_ORDER",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ORDERPRODUCT_TB_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "TB_PRODUCT",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_TB_CUSTOMER_01",
                table: "TB_CUSTOMER",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_TB_ORDER_01",
                table: "TB_ORDER",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_CustomerId",
                table: "TB_ORDER",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IDX_TB_ORDERPRODUCT_01",
                table: "TB_ORDERPRODUCT",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_TB_ORDERPRODUCT_02",
                table: "TB_ORDERPRODUCT",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_TB_PRODUCT_01",
                table: "TB_PRODUCT",
                column: "PRODUCT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ORDERPRODUCT");

            migrationBuilder.DropTable(
                name: "TB_ORDER");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_CUSTOMER");
        }
    }
}
