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
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 20, 3, 58, 9, 76, DateTimeKind.Utc).AddTicks(2206)),
                    CustomerGuid = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AmbassadorId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CommissionBalance = table.Column<string>(nullable: true)
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
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 20, 3, 58, 8, 940, DateTimeKind.Utc).AddTicks(1310)),
                    Name = table.Column<string>(nullable: false),
                    AmbassadorCommissionRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommissionWithdrawal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 20, 3, 58, 9, 93, DateTimeKind.Utc).AddTicks(5196)),
                    CustomerId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionWithdrawal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommissionWithdrawal_Customer_CustomerId",
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
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 20, 3, 58, 8, 925, DateTimeKind.Utc).AddTicks(483)),
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
                        name: "FK_ServiceTransaction_Customer_AmbassadorId",
                        column: x => x.AmbassadorId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceTransaction_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTransaction_Customer_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommissionWithdrawal_CustomerId",
                table: "CommissionWithdrawal",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTransaction_AmbassadorId",
                table: "ServiceTransaction",
                column: "AmbassadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTransaction_ServiceId",
                table: "ServiceTransaction",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTransaction_SupporterId",
                table: "ServiceTransaction",
                column: "SupporterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommissionWithdrawal");

            migrationBuilder.DropTable(
                name: "ServiceTransaction");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
