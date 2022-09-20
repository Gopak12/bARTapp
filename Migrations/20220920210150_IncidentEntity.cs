using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bARTapp.Migrations
{
    public partial class IncidentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IncidentName",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    Name = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Decsription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_IncidentName",
                table: "Account",
                column: "IncidentName");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Incident_IncidentName",
                table: "Account",
                column: "IncidentName",
                principalTable: "Incident",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Incident_IncidentName",
                table: "Account");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropIndex(
                name: "IX_Account_IncidentName",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IncidentName",
                table: "Account");
        }
    }
}
