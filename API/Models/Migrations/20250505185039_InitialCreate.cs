using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Models.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaleDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PassWordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PassWordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    ImagePath = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    SkuCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaleOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantitySold = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItems_SaleOrders_SaleOrderId",
                        column: x => x.SaleOrderId,
                        principalTable: "SaleOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ImagePath", "PassWordHash", "PassWordSalt", "RoleId", "Status", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { 1, new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(2647), null, null, new byte[] { 245, 77, 231, 158, 6, 144, 80, 124, 217, 107, 95, 61, 231, 174, 12, 217, 230, 48, 161, 40, 46, 109, 173, 132, 161, 246, 211, 186, 183, 83, 22, 152, 82, 110, 72, 204, 123, 88, 129, 124, 164, 62, 57, 26, 112, 252, 175, 81, 99, 11, 180, 146, 61, 157, 146, 131, 138, 99, 42, 212, 170, 65, 150, 158 }, new byte[] { 51, 175, 121, 122, 183, 88, 173, 71, 1, 236, 67, 128, 3, 103, 10, 40, 21, 214, 24, 127, 191, 216, 177, 255, 247, 111, 49, 48, 73, 27, 202, 37, 57, 236, 24, 74, 238, 116, 139, 143, 243, 119, 114, 163, 116, 238, 134, 169, 219, 97, 220, 44, 242, 99, 71, 148, 238, 31, 95, 179, 160, 42, 15, 129, 43, 111, 216, 112, 19, 65, 255, 135, 183, 71, 19, 40, 162, 163, 132, 196, 192, 138, 211, 77, 160, 193, 252, 133, 33, 226, 182, 239, 237, 224, 234, 72, 104, 74, 163, 113, 171, 12, 137, 129, 200, 70, 157, 63, 34, 15, 56, 83, 42, 87, 74, 215, 79, 59, 25, 11, 64, 193, 100, 196, 8, 229, 9, 61 }, null, true, null, null, "admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "ImagePath", "Price", "ProductName", "SkuCode", "StockQuantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(3000), 1, "Good", null, 18m, "Mango", "MG-001", 200, null, null },
                    { 2, new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(3003), 1, "Apples from china", null, 20m, "Apple", "AP-002", 150, null, null },
                    { 3, new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(3006), 1, "Organic  bananas", null, 10m, "Banana", "BN-003", 300, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ImagePath", "PassWordHash", "PassWordSalt", "RoleId", "Status", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(2666), 1, null, new byte[] { 243, 170, 32, 210, 23, 104, 180, 58, 159, 13, 62, 249, 102, 248, 229, 146, 91, 139, 56, 237, 44, 62, 166, 232, 57, 143, 87, 116, 254, 102, 165, 181, 20, 138, 220, 202, 70, 86, 159, 38, 3, 129, 219, 56, 160, 121, 71, 187, 60, 185, 18, 128, 125, 153, 147, 60, 104, 36, 227, 46, 132, 157, 188, 31 }, new byte[] { 62, 51, 243, 133, 160, 32, 103, 28, 227, 78, 40, 10, 254, 131, 104, 9, 8, 193, 141, 2, 137, 110, 218, 219, 250, 57, 61, 21, 2, 2, 25, 235, 42, 199, 41, 188, 51, 32, 221, 152, 102, 193, 214, 251, 11, 32, 180, 253, 209, 13, 33, 147, 28, 160, 183, 195, 96, 252, 52, 144, 30, 53, 176, 173, 191, 206, 2, 116, 117, 137, 228, 25, 111, 239, 125, 185, 225, 7, 212, 171, 19, 46, 235, 218, 143, 47, 38, 203, 77, 102, 44, 44, 156, 101, 145, 34, 171, 189, 101, 73, 211, 214, 44, 165, 215, 62, 217, 158, 0, 225, 160, 47, 200, 172, 152, 73, 19, 71, 102, 205, 38, 193, 6, 199, 66, 234, 71, 38 }, null, true, null, null, "manager" },
                    { 3, new DateTime(2025, 5, 5, 18, 50, 39, 203, DateTimeKind.Utc).AddTicks(2669), 1, null, new byte[] { 88, 105, 72, 44, 229, 112, 78, 39, 206, 192, 119, 155, 108, 178, 221, 122, 26, 4, 1, 5, 59, 176, 21, 64, 51, 180, 103, 216, 197, 91, 205, 79, 89, 236, 92, 8, 94, 168, 104, 211, 64, 37, 61, 249, 255, 170, 205, 163, 120, 177, 75, 150, 206, 54, 125, 216, 239, 191, 194, 157, 39, 222, 85, 54 }, new byte[] { 21, 84, 15, 149, 58, 147, 65, 23, 191, 41, 253, 216, 141, 147, 3, 78, 86, 61, 194, 64, 84, 192, 221, 21, 101, 3, 197, 28, 1, 73, 118, 224, 187, 205, 192, 84, 217, 143, 79, 221, 55, 158, 155, 55, 21, 199, 174, 243, 8, 203, 217, 209, 10, 45, 31, 250, 43, 210, 122, 3, 61, 165, 181, 232, 193, 42, 231, 217, 246, 129, 171, 162, 70, 54, 91, 23, 109, 19, 203, 229, 4, 196, 67, 98, 11, 253, 46, 48, 109, 25, 232, 24, 209, 196, 76, 245, 44, 94, 129, 195, 68, 189, 26, 55, 141, 255, 198, 221, 126, 118, 199, 23, 103, 35, 254, 43, 206, 103, 116, 184, 116, 111, 43, 204, 242, 137, 56, 60 }, null, true, null, null, "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedBy",
                table: "Products",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdatedBy",
                table: "Products",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductId",
                table: "SaleItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleOrderId",
                table: "SaleItems",
                column: "SaleOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedBy",
                table: "Users",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
