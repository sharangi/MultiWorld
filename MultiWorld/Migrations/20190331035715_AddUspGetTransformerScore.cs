using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiWorld.Migrations
{
    public partial class AddUspGetTransformerScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var usp = @"CREATE PROCEDURE [dbo].[uspGetTransformerScore]
                        @TransformerId uniqueidentifier
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        select top 1 (Strength + Intelligence + Speed + Endurance + Rank + Courage + Firepower + Skill) as Score from Transformers where Id = @TransformerId
                    END";

            migrationBuilder.Sql(usp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
