using Microsoft.EntityFrameworkCore.Migrations;

namespace CuSubs.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PbsNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AftalenNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "CustomersSubscriptions",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsSubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersSubscriptions", x => new { x.CustomersCustomerId, x.SubscriptionsSubscriptionId });
                    table.ForeignKey(
                        name: "FK_CustomersSubscriptions_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersSubscriptions_Subscriptions_SubscriptionsSubscriptionId",
                        column: x => x.SubscriptionsSubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersSubscriptions_SubscriptionsSubscriptionId",
                table: "CustomersSubscriptions",
                column: "SubscriptionsSubscriptionId");
            migrationBuilder.Sql("ALTER TABLE Customers ADD CONSTRAINT CK_Customers_PbsNr_ CHECK(LEN(PbsNr) = 15)");
            migrationBuilder.Sql("ALTER TABLE Customers ADD CONSTRAINT CK_Customers_Regnr_ CHECK(LEN(Regnr) = 4)");
            migrationBuilder.Sql("ALTER TABLE Customers ADD CONSTRAINT CK_Customers_AccNr_ CHECK (LEN(AccNr)=10)");
            migrationBuilder.Sql("ALTER TABLE Customers ADD CONSTRAINT CK_Customers_CPR_ CHECK (LEN(CPR)=10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersSubscriptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
