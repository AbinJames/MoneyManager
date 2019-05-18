using Microsoft.EntityFrameworkCore;
using MoneyManager.API.Data.SeriesManagerData;

namespace MoneyManager.API.Data.Services.SeriesManagerDataContext
{
    /// <summary>
    /// Class containing initial data for database
    /// </summary>
    public static class SeriesManagerSeeder
    {
        /// <summary>
        /// Function iniializes database with data on migration
        /// </summary>
        /// <param name="modelBuilder">builder Parameter from context</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Series>().HasData(
                new Series { SeriesId = 1, ApiId = 7194, SeriesName = "13 Reasons Why" },
                new Series { SeriesId = 2, ApiId = 31339, SeriesName = "A Discovery of Witches" },
                new Series { SeriesId = 3, ApiId = 3949, SeriesName = "A series of unfortunate events" },
                new Series { SeriesId = 4, ApiId = 31, SeriesName = "Agents of S.H.I.E.L.D." },
                new Series { SeriesId = 5, ApiId = 12036, SeriesName = "Altered Carbon" },
                new Series { SeriesId = 6, ApiId = 3182, SeriesName = "American Gods" },
                new Series { SeriesId = 7, ApiId = 4, SeriesName = "Arrow" },
                new Series { SeriesId = 8, ApiId = 919, SeriesName = "Attack on Titan" },
                new Series { SeriesId = 9, ApiId = 2540, SeriesName = "Avengers Assemble" },
                new Series { SeriesId = 10, ApiId = 22084, SeriesName = "Ben 10" },
                new Series { SeriesId = 11, ApiId = 21142, SeriesName = "Big Hero 6 The Series" },
                new Series { SeriesId = 12, ApiId = 20683, SeriesName = "Black Lightning" },
                new Series { SeriesId = 13, ApiId = 57, SeriesName = "Blackish" },
                new Series { SeriesId = 14, ApiId = 1855, SeriesName = "Blindspot" },
                new Series { SeriesId = 15, ApiId = 49, SeriesName = "Brooklyn Nine-Nine" },
                new Series { SeriesId = 16, ApiId = 25414, SeriesName = "Castle Rock" },
                new Series { SeriesId = 17, ApiId = 25242, SeriesName = "Castlevania" },
                new Series { SeriesId = 18, ApiId = 15307, SeriesName = "Cloak and Dagger" },
                new Series { SeriesId = 19, ApiId = 25110, SeriesName = "Condor" },
                new Series { SeriesId = 20, ApiId = 15, SeriesName = "Constantine" },
                new Series { SeriesId = 21, ApiId = 1369, SeriesName = "Daredevil" },
                new Series { SeriesId = 22, ApiId = 1851, SeriesName = "Dcs Legends of Tomorrow" },
                new Series { SeriesId = 23, ApiId = 210, SeriesName = "Doctor Who" },
                new Series { SeriesId = 24, ApiId = 2368, SeriesName = "Dragon Ball Super" },
                new Series { SeriesId = 25, ApiId = 133, SeriesName = "Elementary" },
                new Series { SeriesId = 26, ApiId = 1824, SeriesName = "Fear The Walking Dead" },
                new Series { SeriesId = 27, ApiId = 23314, SeriesName = "Final Space" },
                new Series { SeriesId = 28, ApiId = 20003, SeriesName = "Freedom Fighters The Ray" },
                new Series { SeriesId = 29, ApiId = 3022, SeriesName = "Future Man" },
                new Series { SeriesId = 30, ApiId = 82, SeriesName = "Game of Thrones" },
                new Series { SeriesId = 31, ApiId = 31257, SeriesName = "God Friended Me" },
                new Series { SeriesId = 32, ApiId = 11, SeriesName = "Gotham" },
                new Series { SeriesId = 33, ApiId = 28366, SeriesName = "Grown-ish" },
                new Series { SeriesId = 34, ApiId = 2476, SeriesName = "Guardians of the Galaxy" },
                new Series { SeriesId = 35, ApiId = 21216, SeriesName = "Happy" },
                new Series { SeriesId = 36, ApiId = 36768, SeriesName = "Happy Together" },
                new Series { SeriesId = 37, ApiId = 7, SeriesName = "Homeland" },
                new Series { SeriesId = 38, ApiId = 2300, SeriesName = "Into The Badlands" },
                new Series { SeriesId = 39, ApiId = 2175, SeriesName = "Iron Fist" },
                new Series { SeriesId = 40, ApiId = 1589, SeriesName = "iZombie" },
                new Series { SeriesId = 41, ApiId = 1370, SeriesName = "Jessica Jones" },
                new Series { SeriesId = 42, ApiId = 12522, SeriesName = "Justice League Action" },
                new Series { SeriesId = 43, ApiId = 11918, SeriesName = "Kong King of the Apes" },
                new Series { SeriesId = 44, ApiId = 3082, SeriesName = "Krypton" },
                new Series { SeriesId = 45, ApiId = 41, SeriesName = "Last Man Standing" },
                new Series { SeriesId = 46, ApiId = 6393, SeriesName = "Legion" },
                new Series { SeriesId = 47, ApiId = 5495, SeriesName = "Lethal Weapon" },
                new Series { SeriesId = 48, ApiId = 8898, SeriesName = "Lost in Space" },
                new Series { SeriesId = 49, ApiId = 1859, SeriesName = "Lucifer" },
                new Series { SeriesId = 50, ApiId = 2174, SeriesName = "Luke Cage" },
                new Series { SeriesId = 51, ApiId = 5511, SeriesName = "MacGyver" },
                new Series { SeriesId = 52, ApiId = 32819, SeriesName = "Magnum P I" },
                new Series { SeriesId = 53, ApiId = 12888, SeriesName = "Man with a plan" },
                new Series { SeriesId = 54, ApiId = 31365, SeriesName = "Manifest" },
                new Series { SeriesId = 55, ApiId = 2176, SeriesName = "Marvels The Defenders" },
                new Series { SeriesId = 56, ApiId = 324, SeriesName = "Masterchef" },
                new Series { SeriesId = 57, ApiId = 3160, SeriesName = "MasterChef Australia" },
                new Series { SeriesId = 58, ApiId = 417, SeriesName = "MasterChef Junior" },
                new Series { SeriesId = 59, ApiId = 80, SeriesName = "Modern Family" },
                new Series { SeriesId = 60, ApiId = 1871, SeriesName = "Mr Robot" },
                new Series { SeriesId = 61, ApiId = 488, SeriesName = "Naruto Shippuden" },
                new Series { SeriesId = 62, ApiId = 590, SeriesName = "Pokemon" },
                new Series { SeriesId = 63, ApiId = 3144, SeriesName = "Preacher" },
                new Series { SeriesId = 64, ApiId = 216, SeriesName = "Rick and Morty" },
                new Series { SeriesId = 65, ApiId = 34300, SeriesName = "Rise of the Teenage Mutant Ninja Turtles" },
                new Series { SeriesId = 66, ApiId = 5262, SeriesName = "Riverdale" },
                new Series { SeriesId = 67, ApiId = 37920, SeriesName = "Runaways" },
                new Series { SeriesId = 68, ApiId = 22188, SeriesName = "Salvation" },
                new Series { SeriesId = 69, ApiId = 14612, SeriesName = "Santa Clarita Diet" },
                new Series { SeriesId = 70, ApiId = 2158, SeriesName = "Shadowhunters" },
                new Series { SeriesId = 71, ApiId = 335, SeriesName = "Sherlock" },
                new Series { SeriesId = 72, ApiId = 143, SeriesName = "Silicon Valley" },
                new Series { SeriesId = 73, ApiId = 21928, SeriesName = "Spider-Man" },
                new Series { SeriesId = 74, ApiId = 713, SeriesName = "SpongeBob SquarePants" },
                new Series { SeriesId = 75, ApiId = 7480, SeriesName = "Star Trek Discovery" },
                new Series { SeriesId = 76, ApiId = 36483, SeriesName = "Star Wars Resistance" },
                new Series { SeriesId = 77, ApiId = 2993, SeriesName = "Stranger things" },
                new Series { SeriesId = 78, ApiId = 17862, SeriesName = "Stretch Armstrong and the Flex Fighters" },
                new Series { SeriesId = 79, ApiId = 1850, SeriesName = "Supergirl" },
                new Series { SeriesId = 80, ApiId = 19, SeriesName = "Supernatural" },
                new Series { SeriesId = 81, ApiId = 33395, SeriesName = "Take Two" },
                new Series { SeriesId = 82, ApiId = 6, SeriesName = "The 100" },
                new Series { SeriesId = 83, ApiId = 34017, SeriesName = "The Adventures of Kid Danger" },
                new Series { SeriesId = 84, ApiId = 66, SeriesName = "The Big Bang Theory" },
                new Series { SeriesId = 85, ApiId = 37675, SeriesName = "The Dragon Prince" },
                new Series { SeriesId = 86, ApiId = 36449, SeriesName = "The Epic Tales of Captain Underpants" },
                new Series { SeriesId = 87, ApiId = 13, SeriesName = "The Flash" },
                new Series { SeriesId = 88, ApiId = 25948, SeriesName = "The Gifted" },
                new Series { SeriesId = 89, ApiId = 17078, SeriesName = "The Grand Tour" },
                new Series { SeriesId = 90, ApiId = 35839, SeriesName = "The Neighborhood" },
                new Series { SeriesId = 91, ApiId = 20263, SeriesName = "The Orville" },
                new Series { SeriesId = 92, ApiId = 16544, SeriesName = "The Punisher" },
                new Series { SeriesId = 93, ApiId = 28134, SeriesName = "The Purge" },
                new Series { SeriesId = 94, ApiId = 32938, SeriesName = "The Rookie" },
                new Series { SeriesId = 95, ApiId = 14116, SeriesName = "The Tick" },
                new Series { SeriesId = 96, ApiId = 4296, SeriesName = "The Tom and Jerry Show" },
                new Series { SeriesId = 97, ApiId = 73, SeriesName = "The Walking Dead" },
                new Series { SeriesId = 98, ApiId = 1878, SeriesName = "Thunderbirds are go" },
                new Series { SeriesId = 99, ApiId = 8873, SeriesName = "Timeless " },
                new Series { SeriesId = 100, ApiId = 27557, SeriesName = "Titans" },
                new Series { SeriesId = 101, ApiId = 38387, SeriesName = "Transformers Cyberverse" },
                new Series { SeriesId = 102, ApiId = 7523, SeriesName = "Van Helsing" },
                new Series { SeriesId = 103, ApiId = 15296, SeriesName = "Voltron Legendary Defender" },
                new Series { SeriesId = 104, ApiId = 1371, SeriesName = "Westworld" },
                new Series { SeriesId = 105, ApiId = 689, SeriesName = "Young Justice" },
                new Series { SeriesId = 106, ApiId = 26020, SeriesName = "Young Sheldon" }
            );

            modelBuilder.Entity<Comics>().HasData(
                new Comics { ComicsId = 1, ComicsName = "Doomsday Clock" },
                new Comics { ComicsId = 2, ComicsName = "The Life of Captain Marvel" },
                new Comics { ComicsId = 3, ComicsName = "Tony Stark Iron Man" },
                new Comics { ComicsId = 4, ComicsName = "Spider-geddon" }
            );
        }
    }
}
