using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioBuilder.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_Second_Table_Skills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillsRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    skillDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    skillProvider = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    skillDateAchieved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    careerRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsRecord_CareerRecord",
                        column: x => x.careerRecordId,
                        principalTable: "CareerRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillsRecords_careerRecordId",
                table: "SkillsRecords",
                column: "careerRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsRecords");
        }
    }
}
