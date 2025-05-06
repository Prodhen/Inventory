using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_CreatedBy",
                table: "SaleOrders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_UpdatedBy",
                table: "SaleOrders",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_CreatedBy",
                table: "SaleItems",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_UpdatedBy",
                table: "SaleItems",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Users_CreatedBy",
                table: "SaleItems",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Users_UpdatedBy",
                table: "SaleItems",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_CreatedBy",
                table: "SaleOrders",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_UpdatedBy",
                table: "SaleOrders",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Users_CreatedBy",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Users_UpdatedBy",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_CreatedBy",
                table: "SaleOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_UpdatedBy",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_CreatedBy",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_UpdatedBy",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleItems_CreatedBy",
                table: "SaleItems");

            migrationBuilder.DropIndex(
                name: "IX_SaleItems_UpdatedBy",
                table: "SaleItems");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(2647), new byte[] { 245, 77, 231, 158, 6, 144, 80, 124, 217, 107, 95, 61, 231, 174, 12, 217, 230, 48, 161, 40, 46, 109, 173, 132, 161, 246, 211, 186, 183, 83, 22, 152, 82, 110, 72, 204, 123, 88, 129, 124, 164, 62, 57, 26, 112, 252, 175, 81, 99, 11, 180, 146, 61, 157, 146, 131, 138, 99, 42, 212, 170, 65, 150, 158 }, new byte[] { 51, 175, 121, 122, 183, 88, 173, 71, 1, 236, 67, 128, 3, 103, 10, 40, 21, 214, 24, 127, 191, 216, 177, 255, 247, 111, 49, 48, 73, 27, 202, 37, 57, 236, 24, 74, 238, 116, 139, 143, 243, 119, 114, 163, 116, 238, 134, 169, 219, 97, 220, 44, 242, 99, 71, 148, 238, 31, 95, 179, 160, 42, 15, 129, 43, 111, 216, 112, 19, 65, 255, 135, 183, 71, 19, 40, 162, 163, 132, 196, 192, 138, 211, 77, 160, 193, 252, 133, 33, 226, 182, 239, 237, 224, 234, 72, 104, 74, 163, 113, 171, 12, 137, 129, 200, 70, 157, 63, 34, 15, 56, 83, 42, 87, 74, 215, 79, 59, 25, 11, 64, 193, 100, 196, 8, 229, 9, 61 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(2666), new byte[] { 243, 170, 32, 210, 23, 104, 180, 58, 159, 13, 62, 249, 102, 248, 229, 146, 91, 139, 56, 237, 44, 62, 166, 232, 57, 143, 87, 116, 254, 102, 165, 181, 20, 138, 220, 202, 70, 86, 159, 38, 3, 129, 219, 56, 160, 121, 71, 187, 60, 185, 18, 128, 125, 153, 147, 60, 104, 36, 227, 46, 132, 157, 188, 31 }, new byte[] { 62, 51, 243, 133, 160, 32, 103, 28, 227, 78, 40, 10, 254, 131, 104, 9, 8, 193, 141, 2, 137, 110, 218, 219, 250, 57, 61, 21, 2, 2, 25, 235, 42, 199, 41, 188, 51, 32, 221, 152, 102, 193, 214, 251, 11, 32, 180, 253, 209, 13, 33, 147, 28, 160, 183, 195, 96, 252, 52, 144, 30, 53, 176, 173, 191, 206, 2, 116, 117, 137, 228, 25, 111, 239, 125, 185, 225, 7, 212, 171, 19, 46, 235, 218, 143, 47, 38, 203, 77, 102, 44, 44, 156, 101, 145, 34, 171, 189, 101, 73, 211, 214, 44, 165, 215, 62, 217, 158, 0, 225, 160, 47, 200, 172, 152, 73, 19, 71, 102, 205, 38, 193, 6, 199, 66, 234, 71, 38 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PassWordHash", "PassWordSalt" },
                values: new object[] { new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(2669), new byte[] { 88, 105, 72, 44, 229, 112, 78, 39, 206, 192, 119, 155, 108, 178, 221, 122, 26, 4, 1, 5, 59, 176, 21, 64, 51, 180, 103, 216, 197, 91, 205, 79, 89, 236, 92, 8, 94, 168, 104, 211, 64, 37, 61, 249, 255, 170, 205, 163, 120, 177, 75, 150, 206, 54, 125, 216, 239, 191, 194, 157, 39, 222, 85, 54 }, new byte[] { 21, 84, 15, 149, 58, 147, 65, 23, 191, 41, 253, 216, 141, 147, 3, 78, 86, 61, 194, 64, 84, 192, 221, 21, 101, 3, 197, 28, 1, 73, 118, 224, 187, 205, 192, 84, 217, 143, 79, 221, 55, 158, 155, 55, 21, 199, 174, 243, 8, 203, 217, 209, 10, 45, 31, 250, 43, 210, 122, 3, 61, 165, 181, 232, 193, 42, 231, 217, 246, 129, 171, 162, 70, 54, 91, 23, 109, 19, 203, 229, 4, 196, 67, 98, 11, 253, 46, 48, 109, 25, 232, 24, 209, 196, 76, 245, 44, 94, 129, 195, 68, 189, 26, 55, 141, 255, 198, 221, 126, 118, 199, 23, 103, 35, 254, 43, 206, 103, 116, 184, 116, 111, 43, 204, 242, 137, 56, 60 } });
        }
    }
}
