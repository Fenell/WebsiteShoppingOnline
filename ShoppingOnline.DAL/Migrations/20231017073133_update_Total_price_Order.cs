using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingOnline.DAL.Migrations
{
    public partial class update_Total_price_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a5dd7b19-ce2b-4fbc-87e7-733a408c0202");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "a6dcc09e-47d9-4642-a93d-2c91157b2e4a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db178b5b-8446-4be0-842b-b6b9e25bcc11", "AQAAAAEAACcQAAAAENfgBQVbcjNzq4V6oxRFmupoCr4dWYHk//5k/3FBA9VgYJ8X+fcAFZg2Trwd2ZlF3Q==", "c7cb25df-5e26-4786-8bc9-3e5e22a80fdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3376b22a-bf77-4179-8c92-02b8c3840a65", "AQAAAAEAACcQAAAAEHsymfTgEtv1t8zGOMaUkKHVMIeHaWqOADqqb6VUDgQcb6UWvLlWin4hcMLepAmCFA==", "3358ef00-03cc-4cf8-b862-59270b72530d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "b5ef3c9d-e618-4647-9be1-eb2fd98ee12a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "b2e585c7-48c1-4633-81ed-6baca3b1e4fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e680803-70da-4d0d-a0c7-0afadbf8f42e", "AQAAAAEAACcQAAAAEPrD0wdU34+ctYbU6n2vQrjagAE9TJ4FWFiIbipI52H0/AwrnOzgRvM1jwuG4H//UA==", "a019a5cc-aed5-440d-ac3c-efcc2ea5ee95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2776e3e-beb9-4d0c-8d97-cb9e41716092", "AQAAAAEAACcQAAAAELRAPRlQxyYlvSI7adgB3nq6T3FNMvqKziq2ivJbg97IRKLDe1AgMDfib3onCznveg==", "d181c6ed-ebc4-475f-9162-ff42a6290fe8" });
        }
    }
}
