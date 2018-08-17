using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Item.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UnitMeasureId = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMaster_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemMaster_UnitMeasure_UnitMeasureId",
                        column: x => x.UnitMeasureId,
                        principalTable: "UnitMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_TypeId",
                table: "ItemMaster",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_UnitMeasureId",
                table: "ItemMaster",
                column: "UnitMeasureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMaster");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "UnitMeasure");
        }
    }
}
