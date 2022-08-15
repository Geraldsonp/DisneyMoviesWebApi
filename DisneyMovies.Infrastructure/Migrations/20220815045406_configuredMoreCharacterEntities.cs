using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyMovies.Infrastructure.Migrations
{
    public partial class configuredMoreCharacterEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://static.wikia.nocookie.net/kimpossible/images/4/49/Kim_Possible_Mugshot.png/revision/latest?cb=20150728134300");

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "History", "ImgUrl", "Name", "Weight" },
                values: new object[] { 1, 15, "Ronald Stoppable has been Kim Possible's best friend since Pre-K, her next door neighbor, and finally boyfriend, mainly serving as her sidekick during missions.", "https://static.wikia.nocookie.net/kimpossible/images/b/b2/Ron_Stoppable_Mugshot.png/revision/latest?cb=20120416162613", "Ron Stoppable", 55.0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "History", "ImgUrl", "Name", "Weight" },
                values: new object[] { 2, 14, "Bonnie Rockwaller is Kim Possible's Middleton High School classmate, fellow cheerleader, and her archrival since at least middle school.", "https://static.wikia.nocookie.net/kimpossible/images/9/97/Bonnie_Mugshot.png/revision/latest?cb=20120420210125", "Bonnie RockWaller", 60.0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "History", "ImgUrl", "Name", "Weight" },
                values: new object[] { 3, 35, "Drew Theodore P. Lipsky, alias Dr. Drakken, is a genius robotics inventor and engineer, considered by Kim Possible as her arch-nemesis. A self-proclaimed mad scientist, Drakken dreamed of world domination, but was constantly thwarted by the efforts of Team Possible. Voiced by John DiMaggio, he is the show's main antagonist.", "https://static.wikia.nocookie.net/kimpossible/images/d/d3/Dr.Drakken.png/revision/latest/scale-to-width-down/200?cb=20200208094132", "Drew Lipsky", 80.0 });

            migrationBuilder.InsertData(
                table: "GenreMedia",
                columns: new[] { "GenreId", "MediaId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "GenreMedia",
                columns: new[] { "GenreId", "MediaId" },
                values: new object[] { 8, 5 });

            migrationBuilder.InsertData(
                table: "CharacterMedia",
                columns: new[] { "CharacterId", "MediaId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "CharacterMedia",
                columns: new[] { "CharacterId", "MediaId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "CharacterMedia",
                columns: new[] { "CharacterId", "MediaId" },
                values: new object[] { 3, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMedia",
                keyColumns: new[] { "CharacterId", "MediaId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterMedia",
                keyColumns: new[] { "CharacterId", "MediaId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterMedia",
                keyColumns: new[] { "CharacterId", "MediaId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "GenreMedia",
                keyColumns: new[] { "GenreId", "MediaId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "GenreMedia",
                keyColumns: new[] { "GenreId", "MediaId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/qsDNX8DPwWydDn9oUIhe1WcTuUH.jpg");
        }
    }
}
