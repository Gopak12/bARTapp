using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bARTapp.Migrations
{
    public partial class CreateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Contact",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AccountName",
                table: "Contact",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Name",
                table: "Account",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Account_AccountName",
                table: "Contact",
                column: "AccountName",
                principalTable: "Account",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Account_AccountName",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Contact_AccountName",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Contact");
        }
    }
}
