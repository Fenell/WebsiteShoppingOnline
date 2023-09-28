using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingOnline.DAL.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "SeoTitle", "Status", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("313e7a81-9b89-4981-8389-477cb23cfabb"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "Adias", null, "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("d80cd77c-a89b-4ff2-8f60-20bfe056c2ed"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "Nike", null, "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "SeoTitle", "Status", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("30f958f6-f5b0-4651-8918-5d02f8cb6cee"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "T-Shirt", null, "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("5bd691e4-bd41-47c3-bb5b-e23319511841"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "Polo", null, "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "Status", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("64718a33-4e12-4310-bfa6-459a3b03bac5"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "Trắng", "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("a0097f6c-3c63-4a8b-875a-80e0adfb4891"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "Đen", "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Promotion",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DiscountPercent", "IsDeleted", "PromotionStatus", "UpdateAt", "UpdateBy" },
                values: new object[] { new Guid("6dfb12e5-04bc-4680-b953-4b53e8e56cb5"), "xxxx-noi-em-anh-chien-de-giam-10%", new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", 10, false, "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "Status", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("3f12e4d9-0e48-4c32-b788-7769d2be7b2c"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "XL", "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("468a7e91-42a7-4e09-9834-d3bc0ce2c2f5"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, "M", "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "CustomerName", "IsDeleted", "Note", "OrderStatus", "PaymentMethod", "PhoneNumber", "PromotionId", "Total", "UpdateAt", "UpdateBy" },
                values: new object[] { new Guid("46b23fc3-bf12-4104-8785-d650360181ed"), "Thai Binh", new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", "Mai Tuan Dat", false, "Khach vip", "SUCCESS", null, "1234567890", new Guid("6dfb12e5-04bc-4680-b953-4b53e8e56cb5"), 259000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "CreatedBy", "DefaultImage", "Description", "Discount", "IsDeleted", "Name", "Price", "SeoTitle", "Status", "UpdateAt", "UpdateBy" },
                values: new object[] { new Guid("38e3f05f-f89a-4fb3-8cb7-9262110d7d16"), new Guid("313e7a81-9b89-4981-8389-477cb23cfabb"), new Guid("5bd691e4-bd41-47c3-bb5b-e23319511841"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", null, "- Được kiểm tra hàng trước khi nhận hàng- Đổi hàng trong vòng 30 ngày kể từ khi nhận hàng", 275000m, false, "Regular.XL.2.3131", 259000m, null, "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "CreatedBy", "DefaultImage", "Description", "Discount", "IsDeleted", "Name", "Price", "SeoTitle", "Status", "UpdateAt", "UpdateBy" },
                values: new object[] { new Guid("4dccaddc-9dbc-4f6d-a6c8-244be05d735f"), new Guid("d80cd77c-a89b-4ff2-8f60-20bfe056c2ed"), new Guid("30f958f6-f5b0-4651-8918-5d02f8cb6cee"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", null, "- Được kiểm tra hàng trước khi nhận hàng- Đổi hàng trong vòng 30 ngày kể từ khi nhận hàng", 275000m, false, "Regular L.3.2987", 339000m, null, "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "ProductItem",
                columns: new[] { "Id", "ColorId", "CreatedAt", "CreatedBy", "IsDeleted", "ProductId", "Quantity", "SizeId", "Status", "UpdateAt", "UpdateBy" },
                values: new object[] { new Guid("18ec90bf-8932-4a59-bbb2-34de95ce9602"), new Guid("a0097f6c-3c63-4a8b-875a-80e0adfb4891"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, new Guid("38e3f05f-f89a-4fb3-8cb7-9262110d7d16"), 1, new Guid("3f12e4d9-0e48-4c32-b788-7769d2be7b2c"), "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "ProductItem",
                columns: new[] { "Id", "ColorId", "CreatedAt", "CreatedBy", "IsDeleted", "ProductId", "Quantity", "SizeId", "Status", "UpdateAt", "UpdateBy" },
                values: new object[] { new Guid("3c0915db-2bcf-47f9-be6e-f39bc127abca"), new Guid("a0097f6c-3c63-4a8b-875a-80e0adfb4891"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, new Guid("4dccaddc-9dbc-4f6d-a6c8-244be05d735f"), 1, new Guid("3f12e4d9-0e48-4c32-b788-7769d2be7b2c"), "ACTIVE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "OrderId", "OrderStatus", "Price", "ProductItemId", "Quantity", "UpdateAt", "UpdateBy" },
                values: new object[] { new Guid("d2dda39f-b2a0-467f-970d-1f9ded874aa0"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Xuan Minh Chien", false, new Guid("46b23fc3-bf12-4104-8785-d650360181ed"), "SUCCESS", 259000m, new Guid("18ec90bf-8932-4a59-bbb2-34de95ce9602"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: new Guid("64718a33-4e12-4310-bfa6-459a3b03bac5"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: new Guid("d2dda39f-b2a0-467f-970d-1f9ded874aa0"));

            migrationBuilder.DeleteData(
                table: "ProductItem",
                keyColumn: "Id",
                keyValue: new Guid("3c0915db-2bcf-47f9-be6e-f39bc127abca"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("468a7e91-42a7-4e09-9834-d3bc0ce2c2f5"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("46b23fc3-bf12-4104-8785-d650360181ed"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4dccaddc-9dbc-4f6d-a6c8-244be05d735f"));

            migrationBuilder.DeleteData(
                table: "ProductItem",
                keyColumn: "Id",
                keyValue: new Guid("18ec90bf-8932-4a59-bbb2-34de95ce9602"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d80cd77c-a89b-4ff2-8f60-20bfe056c2ed"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("30f958f6-f5b0-4651-8918-5d02f8cb6cee"));

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: new Guid("a0097f6c-3c63-4a8b-875a-80e0adfb4891"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("38e3f05f-f89a-4fb3-8cb7-9262110d7d16"));

            migrationBuilder.DeleteData(
                table: "Promotion",
                keyColumn: "Id",
                keyValue: new Guid("6dfb12e5-04bc-4680-b953-4b53e8e56cb5"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("3f12e4d9-0e48-4c32-b788-7769d2be7b2c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("313e7a81-9b89-4981-8389-477cb23cfabb"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5bd691e4-bd41-47c3-bb5b-e23319511841"));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
