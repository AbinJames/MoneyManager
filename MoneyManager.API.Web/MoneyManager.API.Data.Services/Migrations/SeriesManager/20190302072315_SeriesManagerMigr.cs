using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoneyManager.API.Data.Services.Migrations.SeriesManager
{
    public partial class SeriesManagerMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    ComicsId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ComicsName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.ComicsId);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApiId = table.Column<long>(nullable: false),
                    SeriesName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesId);
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "ComicsId", "ComicsName" },
                values: new object[,]
                {
                    { 1L, "Doomsday Clock" },
                    { 2L, "The Life of Captain Marvel" },
                    { 3L, "Tony Stark Iron Man" },
                    { 4L, "Spider-geddon" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "SeriesId", "ApiId", "SeriesName" },
                values: new object[,]
                {
                    { 77L, 2993L, "Stranger things" },
                    { 76L, 36483L, "Star Wars Resistance" },
                    { 75L, 7480L, "Star Trek Discovery" },
                    { 74L, 713L, "SpongeBob SquarePants" },
                    { 73L, 21928L, "Spider-Man" },
                    { 72L, 143L, "Silicon Valley" },
                    { 71L, 335L, "Sherlock" },
                    { 70L, 2158L, "Shadowhunters" },
                    { 69L, 14612L, "Santa Clarita Diet" },
                    { 68L, 22188L, "Salvation" },
                    { 67L, 20172L, "Runaways" },
                    { 65L, 34300L, "Rise of the Teenage Mutant Ninja Turtles" },
                    { 78L, 17862L, "Stretch Armstrong and the Flex Fighters" },
                    { 64L, 216L, "Rick and Morty" },
                    { 63L, 3144L, "Preacher" },
                    { 62L, 590L, "Pokemon" },
                    { 61L, 488L, "Naruto Shippuden" },
                    { 60L, 1871L, "Mr Robot" },
                    { 59L, 80L, "Modern Family" },
                    { 58L, 417L, "MasterChef Junior" },
                    { 57L, 3160L, "MasterChef Australia" },
                    { 56L, 324L, "Masterchef" },
                    { 55L, 2176L, "Marvels The Defenders" },
                    { 66L, 5262L, "Riverdale" },
                    { 79L, 1850L, "Supergirl" },
                    { 81L, 33395L, "Take Two" },
                    { 54L, 31365L, "Manifest" },
                    { 104L, 1371L, "Westworld" },
                    { 103L, 15296L, "Voltron Legendary Defender" },
                    { 102L, 7523L, "Van Helsing" },
                    { 101L, 38387L, "Transformers Cyberverse" },
                    { 100L, 27557L, "Titans" },
                    { 99L, 8873L, "Timeless " },
                    { 98L, 1878L, "Thunderbirds are go" },
                    { 97L, 73L, "The Walking Dead" },
                    { 96L, 4296L, "The Tom and Jerry Show" },
                    { 95L, 14116L, "The Tick" },
                    { 94L, 32938L, "The Rookie" },
                    { 93L, 28134L, "The Purge" },
                    { 92L, 16544L, "The Punisher" },
                    { 91L, 20263L, "The Orville" },
                    { 90L, 35839L, "The Neighborhood" },
                    { 89L, 17078L, "The Grand Tour" },
                    { 88L, 25948L, "The Gifted" },
                    { 87L, 13L, "The Flash" },
                    { 86L, 36449L, "The Epic Tales of Captain Underpants" },
                    { 85L, 37675L, "The Dragon Prince" },
                    { 84L, 66L, "The Big Bang Theory" },
                    { 83L, 34017L, "The Adventures of Kid Danger" },
                    { 82L, 6L, "The 100" },
                    { 80L, 19L, "Supernatural" },
                    { 53L, 12888L, "Man with a plan" },
                    { 51L, 5511L, "MacGyver" },
                    { 105L, 689L, "Young Justice" },
                    { 23L, 210L, "Doctor Who" },
                    { 22L, 1851L, "Dcs Legends of Tomorrow" },
                    { 21L, 1369L, "Daredevil" },
                    { 20L, 15L, "Constantine" },
                    { 19L, 25110L, "Condor" },
                    { 18L, 15307L, "Cloak and Dagger" },
                    { 17L, 25242L, "Castlevania" },
                    { 16L, 25414L, "Castle Rock" },
                    { 15L, 49L, "Brooklyn Nine-Nine" },
                    { 14L, 1855L, "Blindspot" },
                    { 13L, 57L, "Blackish" },
                    { 12L, 20683L, "Black Lightning" },
                    { 11L, 21142L, "Big Hero 6 The Series" },
                    { 10L, 22084L, "Ben 10" },
                    { 9L, 2540L, "Avengers Assemble" },
                    { 8L, 919L, "Attack on Titan" },
                    { 7L, 4L, "Arrow" },
                    { 6L, 3182L, "American Gods" },
                    { 5L, 12036L, "Altered Carbon" },
                    { 4L, 31L, "Agents of S.H.I.E.L.D." },
                    { 3L, 3949L, "A series of unfortunate events" },
                    { 2L, 31339L, "A Discovery of Witches" },
                    { 1L, 7194L, "13 Reasons Why" },
                    { 24L, 2368L, "Dragon Ball Super" },
                    { 52L, 32819L, "Magnum P I" },
                    { 25L, 133L, "Elementary" },
                    { 27L, 23314L, "Final Space" },
                    { 50L, 2174L, "Luke Cage" },
                    { 49L, 1859L, "Lucifer" },
                    { 48L, 8898L, "Lost in Space" },
                    { 47L, 5495L, "Lethal Weapon" },
                    { 46L, 6393L, "Legion" },
                    { 45L, 41L, "Last Man Standing" },
                    { 44L, 3082L, "Krypton" },
                    { 43L, 11918L, "Kong King of the Apes" },
                    { 42L, 12522L, "Justice League Action" },
                    { 41L, 1370L, "Jessica Jones" },
                    { 40L, 1589L, "iZombie" },
                    { 39L, 2175L, "Iron Fist" },
                    { 38L, 2300L, "Into The Badlands" },
                    { 37L, 7L, "Homeland" },
                    { 36L, 36768L, "Happy Together" },
                    { 35L, 21216L, "Happy" },
                    { 34L, 2476L, "Guardians of the Galaxy" },
                    { 33L, 28366L, "Grown-ish" },
                    { 32L, 11L, "Gotham" },
                    { 31L, 31257L, "God Friended Me" },
                    { 30L, 82L, "Game of Thrones" },
                    { 29L, 3022L, "Future Man" },
                    { 28L, 20003L, "Freedom Fighters The Ray" },
                    { 26L, 1824L, "Fear The Walking Dead" },
                    { 106L, 26020L, "Young Sheldon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comics");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
