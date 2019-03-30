using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiWorld.Migrations
{
    public partial class AddTranformersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transformers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Allegiance = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Endurance = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Courage = table.Column<int>(nullable: false),
                    Firepower = table.Column<int>(nullable: false),
                    Skill = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transformers");
        }
    }
}
