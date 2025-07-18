using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConversionPLayerPositionIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionTemp",
                table: "Players",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.Sql(@"
                UPDATE Players SET PositionTemp =
                    CASE Position
                    WHEN 1 THEN 'GK'
                    WHEN 2 THEN 'LB'
                    WHEN 3 THEN 'CB'
                    WHEN 4 THEN 'RB'
                    WHEN 5 THEN 'LM'
                    WHEN 6 THEN 'CM'
                    WHEN 7 THEN 'RM'
                    WHEN 8 THEN 'FW'
                END
            ");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players"
            );

            migrationBuilder.RenameColumn(
                name: "PositionTemp",
                table: "Players",
                newName: "Position"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionTemp",
                table: "Players",
                type: "int",
                maxLength: 100,
                nullable: true);

            migrationBuilder.Sql(@"
                UPDATE Players SET PositionTemp =
                    CASE Position
                    WHEN 'GK' THEN 1
                    WHEN 'LB' THEN 2
                    WHEN 'CB' THEN 3
                    WHEN 'RB' THEN 4
                    WHEN 'LM' THEN 5
                    WHEN 'CM' THEN 6
                    WHEN 'RM' THEN 7
                    WHEN 'FW' THEN 8
                END
            ");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players"
            );

            migrationBuilder.RenameColumn(
                name: "PositionTemp",
                table: "Players",
                newName: "Position"
            );
        }
    }
}
