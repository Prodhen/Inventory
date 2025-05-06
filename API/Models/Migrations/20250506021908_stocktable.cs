using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Models.Migrations
{
    /// <inheritdoc />
    public partial class stocktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SaleOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "SaleItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Reference = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Remarks = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 2, 19, 6, 108, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 2, 19, 6, 108, DateTimeKind.Utc).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 2, 19, 6, 108, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 6, 2, 19, 6, 108, DateTimeKind.Utc).AddTicks(8219), new byte[] { 134, 213, 7, 174, 31, 108, 26, 244, 3, 143, 24, 23, 126, 61, 51, 221, 190, 141, 72, 209, 166, 181, 180, 215, 41, 105, 143, 86, 41, 1, 75, 91, 112, 72, 124, 21, 207, 140, 125, 187, 183, 12, 123, 227, 158, 231, 94, 24, 16, 200, 66, 115, 100, 16, 238, 148, 147, 245, 105, 29, 76, 81, 9, 28 }, new byte[] { 191, 94, 90, 171, 87, 200, 116, 68, 86, 236, 75, 48, 33, 3, 206, 182, 180, 92, 122, 221, 116, 117, 39, 174, 125, 198, 44, 187, 219, 100, 127, 143, 177, 166, 11, 6, 230, 105, 112, 112, 49, 142, 138, 12, 163, 55, 9, 148, 5, 166, 243, 205, 220, 60, 254, 120, 2, 224, 193, 90, 234, 105, 90, 76, 103, 98, 36, 175, 121, 147, 216, 251, 179, 185, 62, 83, 223, 206, 251, 248, 9, 194, 104, 57, 48, 203, 208, 108, 180, 229, 163, 205, 165, 196, 155, 243, 177, 199, 215, 169, 152, 170, 118, 86, 178, 67, 187, 106, 107, 66, 210, 2, 187, 241, 37, 1, 35, 199, 210, 3, 116, 195, 150, 140, 155, 8, 159, 77 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 6, 2, 19, 6, 108, DateTimeKind.Utc).AddTicks(8221), new byte[] { 226, 145, 39, 90, 233, 87, 81, 32, 101, 123, 14, 221, 205, 116, 249, 104, 27, 187, 230, 54, 63, 87, 245, 194, 55, 133, 200, 144, 58, 195, 213, 179, 163, 49, 166, 149, 185, 71, 46, 162, 123, 73, 250, 137, 194, 203, 122, 68, 247, 85, 160, 199, 149, 187, 183, 110, 113, 180, 56, 68, 127, 118, 251, 141 }, new byte[] { 43, 74, 132, 114, 68, 241, 105, 131, 238, 10, 72, 168, 162, 191, 210, 107, 85, 218, 11, 214, 171, 48, 236, 104, 102, 227, 159, 158, 35, 28, 51, 220, 249, 152, 14, 103, 252, 240, 212, 41, 97, 159, 83, 155, 169, 43, 32, 138, 255, 126, 30, 27, 229, 11, 195, 119, 240, 4, 95, 141, 183, 78, 67, 98, 13, 114, 165, 25, 178, 166, 171, 208, 171, 39, 129, 50, 240, 199, 84, 32, 178, 110, 187, 120, 128, 251, 173, 53, 93, 1, 246, 48, 172, 157, 42, 206, 188, 183, 116, 95, 185, 35, 197, 226, 230, 40, 64, 205, 20, 36, 47, 29, 2, 3, 15, 78, 76, 149, 21, 254, 20, 6, 187, 189, 88, 195, 68, 183 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 6, 2, 19, 6, 108, DateTimeKind.Utc).AddTicks(8273), new byte[] { 99, 243, 69, 174, 1, 117, 235, 41, 94, 124, 56, 75, 200, 145, 187, 219, 158, 124, 134, 1, 248, 35, 230, 32, 218, 42, 165, 158, 30, 52, 13, 193, 75, 72, 208, 233, 139, 87, 27, 250, 171, 227, 176, 215, 205, 107, 12, 156, 92, 43, 188, 46, 205, 107, 76, 189, 187, 43, 83, 234, 251, 228, 112, 74 }, new byte[] { 131, 254, 181, 55, 150, 24, 176, 106, 6, 138, 148, 149, 221, 225, 165, 100, 153, 136, 215, 103, 115, 152, 210, 187, 254, 98, 183, 155, 18, 205, 86, 73, 153, 39, 246, 253, 48, 128, 29, 44, 155, 60, 203, 245, 166, 17, 132, 202, 41, 165, 63, 36, 191, 88, 205, 187, 183, 215, 13, 131, 126, 192, 212, 72, 221, 83, 3, 9, 202, 85, 93, 204, 155, 228, 27, 111, 203, 69, 56, 47, 152, 13, 208, 191, 88, 170, 27, 241, 1, 212, 2, 231, 86, 187, 15, 63, 226, 25, 47, 209, 125, 170, 72, 223, 37, 41, 57, 30, 35, 166, 92, 203, 254, 62, 197, 200, 224, 56, 193, 117, 104, 229, 183, 197, 187, 243, 81, 50 } });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_CreatedBy",
                table: "Stocks",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UpdatedBy",
                table: "Stocks",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "SaleItems");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 19, 8, 44, 479, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 19, 8, 44, 479, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 19, 8, 44, 479, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 5, 19, 8, 44, 479, DateTimeKind.Utc).AddTicks(4200), new byte[] { 116, 136, 255, 218, 93, 213, 132, 203, 62, 16, 11, 168, 149, 147, 147, 100, 51, 230, 195, 230, 160, 10, 243, 64, 151, 118, 146, 225, 50, 61, 168, 138, 194, 24, 224, 237, 165, 54, 161, 1, 88, 57, 46, 251, 2, 13, 81, 104, 146, 178, 148, 200, 199, 197, 89, 59, 195, 123, 14, 120, 146, 198, 45, 5 }, new byte[] { 43, 27, 151, 90, 36, 185, 246, 128, 77, 43, 38, 107, 132, 96, 61, 86, 7, 106, 150, 217, 120, 24, 74, 216, 106, 94, 213, 21, 43, 100, 249, 196, 160, 116, 170, 47, 129, 1, 59, 242, 174, 16, 18, 14, 159, 194, 184, 188, 121, 83, 81, 168, 122, 146, 96, 175, 171, 90, 189, 206, 234, 188, 2, 248, 116, 36, 30, 15, 168, 217, 41, 197, 94, 134, 242, 138, 121, 170, 252, 16, 148, 239, 210, 22, 74, 197, 20, 16, 50, 164, 190, 184, 247, 160, 208, 16, 122, 229, 123, 7, 243, 220, 207, 41, 224, 109, 180, 88, 52, 2, 135, 221, 7, 43, 226, 49, 102, 109, 25, 102, 86, 154, 2, 91, 186, 91, 214, 97 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 5, 19, 8, 44, 479, DateTimeKind.Utc).AddTicks(4202), new byte[] { 82, 100, 169, 146, 214, 95, 224, 164, 12, 169, 15, 95, 195, 64, 159, 57, 64, 88, 205, 181, 108, 204, 108, 86, 134, 111, 209, 67, 245, 247, 0, 145, 196, 6, 207, 37, 3, 195, 234, 77, 75, 249, 245, 161, 134, 39, 34, 145, 245, 64, 33, 186, 136, 239, 174, 210, 64, 211, 176, 37, 174, 64, 213, 173 }, new byte[] { 9, 249, 12, 15, 8, 105, 253, 118, 168, 4, 5, 108, 66, 174, 23, 59, 156, 42, 16, 204, 208, 4, 188, 121, 19, 230, 104, 72, 86, 40, 159, 28, 5, 35, 13, 64, 203, 202, 196, 194, 58, 135, 72, 131, 125, 205, 232, 100, 73, 50, 118, 208, 216, 146, 105, 70, 206, 125, 84, 21, 238, 104, 126, 88, 55, 103, 95, 138, 114, 163, 24, 35, 129, 0, 205, 224, 243, 146, 214, 143, 225, 18, 130, 79, 211, 86, 43, 75, 244, 219, 154, 173, 212, 242, 17, 185, 70, 47, 253, 11, 226, 50, 95, 205, 14, 62, 243, 193, 205, 206, 195, 71, 107, 109, 189, 134, 130, 222, 4, 33, 248, 80, 157, 127, 97, 165, 174, 56 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 5, 19, 8, 44, 479, DateTimeKind.Utc).AddTicks(4205), new byte[] { 105, 30, 94, 4, 48, 111, 158, 166, 123, 245, 53, 94, 230, 171, 132, 217, 128, 20, 79, 181, 97, 88, 234, 145, 238, 203, 213, 65, 222, 2, 39, 74, 223, 49, 190, 133, 86, 133, 250, 115, 154, 132, 226, 7, 101, 154, 182, 101, 61, 77, 42, 125, 97, 152, 8, 149, 173, 65, 216, 145, 168, 145, 76, 198 }, new byte[] { 17, 207, 53, 228, 190, 113, 242, 103, 121, 71, 54, 60, 175, 116, 4, 165, 215, 82, 100, 180, 93, 255, 105, 85, 91, 135, 188, 202, 184, 168, 213, 173, 133, 254, 213, 39, 28, 211, 222, 223, 57, 241, 252, 22, 151, 65, 244, 19, 172, 12, 195, 79, 196, 56, 150, 84, 248, 16, 27, 231, 82, 221, 98, 140, 35, 89, 204, 153, 174, 178, 196, 48, 202, 220, 106, 174, 111, 194, 244, 184, 220, 189, 46, 247, 219, 175, 249, 71, 197, 16, 139, 152, 241, 195, 224, 247, 87, 88, 146, 114, 66, 211, 254, 57, 73, 235, 153, 121, 126, 51, 63, 116, 80, 10, 25, 24, 234, 62, 63, 226, 84, 232, 26, 97, 69, 185, 117, 30 } });
        }
    }
}
