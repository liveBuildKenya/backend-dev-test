using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jambopay.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 18, 9, 37, 30, 143, DateTimeKind.Utc).AddTicks(8568)),
                    CustomerGuid = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 18, 9, 37, 30, 19, DateTimeKind.Utc).AddTicks(2143)),
                    Name = table.Column<string>(nullable: false),
                    AmbassadorCommissionRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Affiliate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 18, 9, 37, 30, 147, DateTimeKind.Utc).AddTicks(5804)),
                    CustomerId = table.Column<int>(nullable: false),
                    AmbassadorId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Affiliate_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 18, 9, 37, 30, 5, DateTimeKind.Utc).AddTicks(3746)),
                    SupporterId = table.Column<int>(nullable: false),
                    AmbassadorId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CommissionAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTransaction_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affiliate_CustomerId",
                table: "Affiliate",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTransaction_ServiceId",
                table: "ServiceTransaction",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affiliate");

            migrationBuilder.DropTable(
                name: "ServiceTransaction");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
