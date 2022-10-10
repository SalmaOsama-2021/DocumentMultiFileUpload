using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentUploadFile.DataAccess.Migrations
{
    public partial class addFilename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "documentFileName",
                schema: "Document",
                table: "Document_files",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "documentFileName",
                schema: "Document",
                table: "Document_files");
        }
    }
}
