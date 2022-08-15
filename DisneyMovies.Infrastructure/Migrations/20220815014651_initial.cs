using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyMovies.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    History = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    DurationInMinutes = table.Column<long>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMedia",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMedia", x => new { x.CharacterId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_CharacterMedia_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMedia_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMedia",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMedia", x => new { x.GenreId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_GenreMedia_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMedia_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "History", "ImgUrl", "Name", "Weight" },
                values: new object[] { 5, 14, "is a high school student and freelance hero/vigilante. She is unusual in this in that she not only lacks a secret identity, but also remains on good terms with various law enforcement, government, and military agencies. ", "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/qsDNX8DPwWydDn9oUIhe1WcTuUH.jpg", "Kimberly Ann Possible", 50.0 });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 1, "", "Action" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 2, "", "Comedy" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 3, "", "Drama" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 4, "", "Fantasy" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 5, "", "Christmas" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 6, "", "Mystery" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 7, "", "Romance" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 8, "", "Animation" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[] { 9, "", "Family" });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "CreationDate", "DurationInMinutes", "ImgUrl", "Rating", "Title", "Type" },
                values: new object[] { 5, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23L, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/qsDNX8DPwWydDn9oUIhe1WcTuUH.jpg", 3, "Kim Possible", 1 });

            migrationBuilder.InsertData(
                table: "CharacterMedia",
                columns: new[] { "CharacterId", "MediaId" },
                values: new object[] { 5, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMedia_MediaId",
                table: "CharacterMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMedia_MediaId",
                table: "GenreMedia",
                column: "MediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMedia");

            migrationBuilder.DropTable(
                name: "GenreMedia");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Medias");
        }
    }
}
