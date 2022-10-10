using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentUploadFile.DataAccess.Migrations
{
    public partial class initilze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Document");

            migrationBuilder.CreateTable(
                name: "documents",
                schema: "Document",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "Document",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Document_files",
                schema: "Document",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document_ID = table.Column<int>(type: "int", nullable: true),
                    File_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document_files", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Document_files_documents_Document_ID",
                        column: x => x.Document_ID,
                        principalSchema: "Document",
                        principalTable: "documents",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_files_Document_ID",
                schema: "Document",
                table: "Document_files",
                column: "Document_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document_files",
                schema: "Document");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "Document");

            migrationBuilder.DropTable(
                name: "documents",
                schema: "Document");
        }
    }
}
