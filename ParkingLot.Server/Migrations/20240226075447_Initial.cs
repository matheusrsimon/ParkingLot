using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkingLot.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpotSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSections_SpotSizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "SpotSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpotSizeUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usage = table.Column<int>(type: "int", nullable: false),
                    VehicleSizeId = table.Column<int>(type: "int", nullable: false),
                    SpotSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotSizeUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotSizeUsages_SpotSizes_SpotSizeId",
                        column: x => x.SpotSizeId,
                        principalTable: "SpotSizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpotSizeUsages_SpotSizes_VehicleSizeId",
                        column: x => x.VehicleSizeId,
                        principalTable: "SpotSizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_SpotSizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "SpotSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_ParkingSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ParkingSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SpotSizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Small" },
                    { 2, "Medium" },
                    { 3, "Large" }
                });

            migrationBuilder.InsertData(
                table: "ParkingSections",
                columns: new[] { "Id", "Count", "SizeId" },
                values: new object[,]
                {
                    { 1, 10, 1 },
                    { 2, 10, 2 },
                    { 3, 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "SpotSizeUsages",
                columns: new[] { "Id", "SpotSizeId", "Usage", "VehicleSizeId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 2, 1, 2 },
                    { 5, 3, 1, 2 },
                    { 6, 2, 3, 3 },
                    { 7, 3, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name", "SizeId" },
                values: new object[,]
                {
                    { 1, "Motorcycle", 1 },
                    { 2, "Car", 2 },
                    { 3, "Van", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSections_SizeId",
                table: "ParkingSections",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotSizeUsages_SpotSizeId",
                table: "SpotSizeUsages",
                column: "SpotSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotSizeUsages_VehicleSizeId",
                table: "SpotSizeUsages",
                column: "VehicleSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SectionId",
                table: "Vehicles",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TypeId",
                table: "Vehicles",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_SizeId",
                table: "VehicleTypes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpotSizeUsages");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ParkingSections");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "SpotSizes");
        }
    }
}
