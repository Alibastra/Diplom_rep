using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class AddLinkForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CheckIns",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "CheckIns",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplys_CheckInID",
                table: "Supplys",
                column: "CheckInID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplys_ServiceID",
                table: "Supplys",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_CustomerID",
                table: "CheckIns",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_RoomID",
                table: "CheckIns",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_Customers_CustomerID",
                table: "CheckIns",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_Rooms_RoomID",
                table: "CheckIns",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplys_CheckIns_CheckInID",
                table: "Supplys",
                column: "CheckInID",
                principalTable: "CheckIns",
                principalColumn: "CheckInID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplys_Services_ServiceID",
                table: "Supplys",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_Customers_CustomerID",
                table: "CheckIns");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_Rooms_RoomID",
                table: "CheckIns");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplys_CheckIns_CheckInID",
                table: "Supplys");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplys_Services_ServiceID",
                table: "Supplys");

            migrationBuilder.DropIndex(
                name: "IX_Supplys_CheckInID",
                table: "Supplys");

            migrationBuilder.DropIndex(
                name: "IX_Supplys_ServiceID",
                table: "Supplys");

            migrationBuilder.DropIndex(
                name: "IX_CheckIns_CustomerID",
                table: "CheckIns");

            migrationBuilder.DropIndex(
                name: "IX_CheckIns_RoomID",
                table: "CheckIns");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CheckIns",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "CheckIns",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
