using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VidlyCore.Data.Migrations
{
    public partial class PopulateGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Genre", newName: "Genres");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
