using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BigFile.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BigFiles",
                columns: table => new
                {
                    BigFileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    LastWriteTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Length = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigFiles", x => x.BigFileId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExceptionLog = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    ExceptionMessage = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    FolderPath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BigFiles");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
