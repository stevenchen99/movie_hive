using Microsoft.EntityFrameworkCore;
using MovieHive.Models;

namespace MovieHive.Data
{
    public static class InitDB
    {
        /*
            Dependency Injection (DI) is designed to work with instances of classes rather than static classes.
            This is because static classes and methods are associated with the type itself,
            and they cannot be instantiated or injected in the same way as instances of non-static classes.
        */

        public static void Initialize(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var ctx = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (ctx != null)
                    SeedData(ctx, isProduction);
            }
        }

        private static void SeedData(AppDbContext ctx, bool isProduction)
        {
            if (isProduction)
            {
                Console.WriteLine("Migration in Progress...");
                try
                {
                    ctx.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (!ctx.Movies.Any())
            {
                Console.WriteLine("======== Seeding Movie Data ========");
                ctx.Movies.AddRange(
                    new Movie
                    {
                        MovieId = "10001",
                        Title = "The Secret Garden",
                        Description =
                            "A magical story of a young orphaned girl who discovers a hidden, neglected garden.",
                        Genre = ["Fantasy", "Drama"],
                        Director = "Marc Munden",
                        Year = "2020",
                        Duration = 100, // in minutes
                        Rating = "PG"
                    },
                    new Movie
                    {
                        MovieId = "10002",
                        Title = "The Hunger Games",
                        Description =
                            "In a dystopian future, Katniss Everdeen volunteers to take her sister's place in a brutal competition where teenagers fight to the death.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Gary Ross",
                        Year = "2012",
                        Duration = 142,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10003",
                        Title = "The Avengers",
                        Description =
                            "Earth's mightiest heroes, including Iron Man, Captain America, and Thor, team up to stop the mischievous Loki and his alien army from enslaving humanity.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Joss Whedon",
                        Year = "2012",
                        Duration = 143,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10004",
                        Title = "Frozen",
                        Description =
                            "Princess Anna sets off on a journey with rugged iceman Kristoff and his loyal reindeer, Sven, to find her estranged sister, whose icy powers have trapped their kingdom in eternal winter.",
                        Genre = ["Animation", "Adventure", "Comedy"],
                        Director = "Chris Buck, Jennifer Lee",
                        Year = "2013",
                        Duration = 102,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        MovieId = "10005",
                        Title = "Interstellar",
                        Description =
                            "In a future where Earth is becoming uninhabitable, a group of astronauts undertakes a dangerous mission through a wormhole to find a new habitable planet for humanity.",
                        Genre = ["Adventure", "Drama", "Sci-Fi"],
                        Director = "Christopher Nolan",
                        Year = "2014",
                        Duration = 169,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10006",
                        Title = "Joker",
                        Description =
                            "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He embarks on a downward spiral of revolution and bloody crime.",
                        Genre = ["Crime", "Drama", "Thriller"],
                        Director = "Todd Phillips",
                        Year = "2019",
                        Duration = 122,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10007",
                        Title = "Gravity",
                        Description =
                            "A medical engineer and an astronaut work together to survive after an accident leaves them adrift in space.",
                        Genre = ["Drama", "Sci-Fi", "Thriller"],
                        Director = "Alfonso Cuarón",
                        Year = "2013",
                        Duration = 91,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10008",
                        Title = "La La Land",
                        Description =
                            "In Los Angeles, aspiring actress Mia and jazz musician Sebastian fall in love but are faced with opportunities that threaten to separate them.",
                        Genre = ["Comedy", "Drama", "Musical"],
                        Director = "Damien Chazelle",
                        Year = "2016",
                        Duration = 128,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10009",
                        Title = "Black Panther",
                        Description =
                            "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and confront a challenger from his country's past.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Ryan Coogler",
                        Year = "2018",
                        Duration = 134,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10010",
                        Title = "Toy Story 4",
                        Description =
                            "Woody, Buzz Lightyear, and the rest of the gang embark on a road trip with Bonnie and a new toy named Forky.",
                        Genre = ["Animation", "Adventure", "Comedy"],
                        Director = "Josh Cooley",
                        Year = "2019",
                        Duration = 100,
                        Rating = "G"
                    },
                    new Movie
                    {
                        MovieId = "10011",
                        Title = "Inception",
                        Description =
                            "A thief who enters the dreams of others to steal their secrets gets a chance to redeem himself by planting an idea in the mind of a CEO.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Christopher Nolan",
                        Year = "2010",
                        Duration = 148,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10012",
                        Title = "The Martian",
                        Description =
                            "During a manned mission to Mars, Astronaut Mark Watney is presumed dead after a fierce storm and left behind by his crew. But Watney has survived and finds himself stranded and alone on the hostile planet.",
                        Genre = ["Adventure", "Drama", "Sci-Fi"],
                        Director = "Ridley Scott",
                        Year = "2015",
                        Duration = 144,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10013",
                        Title = "Avengers: Infinity War",
                        Description =
                            "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Anthony Russo, Joe Russo",
                        Year = "2018",
                        Duration = 149,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10014",
                        Title = "Coco",
                        Description =
                            "Aspiring musician Miguel, confronted with his family's ancestral ban on music, enters the Land of the Dead to find his great-great-grandfather, a legendary singer.",
                        Genre = ["Animation", "Adventure", "Comedy"],
                        Director = "Lee Unkrich, Adrian Molina",
                        Year = "2017",
                        Duration = 105,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        MovieId = "10015",
                        Title = "The Social Network",
                        Description =
                            "Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, but is later sued by two brothers who claimed he stole their idea, and the co-founder who was later squeezed out of the business.",
                        Genre = ["Biography", "Drama"],
                        Director = "David Fincher",
                        Year = "2010",
                        Duration = 120,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10016",
                        Title = "Mad Max: Fury Road",
                        Description =
                            "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search of her homeland with the aid of a group of female prisoners, a psychotic worshiper, and a drifter named Max.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "George Miller",
                        Year = "2015",
                        Duration = 120,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10017",
                        Title = "The Revenant",
                        Description =
                            "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.",
                        Genre = ["Adventure", "Drama", "Thriller"],
                        Director = "Alejandro González Iñárritu",
                        Year = "2015",
                        Duration = 156,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10018",
                        Title = "The Grand Budapest Hotel",
                        Description =
                            "A writer encounters the owner of an aging high-class hotel, who tells him of his early years serving as a lobby boy in the hotel's glorious years under an exceptional concierge.",
                        Genre = ["Adventure", "Comedy", "Crime"],
                        Director = "Wes Anderson",
                        Year = "2014",
                        Duration = 99,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10019",
                        Title = "Jurassic World",
                        Description =
                            "A new theme park, built on the original site of Jurassic Park, creates a genetically modified hybrid dinosaur, the Indominus Rex, which escapes containment and goes on a killing spree.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Colin Trevorrow",
                        Year = "2015",
                        Duration = 124,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10020",
                        Title = "Black Swan",
                        Description =
                            "A committed dancer struggles to maintain her sanity after winning the lead role in a production of Tchaikovsky's 'Swan Lake'.",
                        Genre = ["Drama", "Thriller"],
                        Director = "Darren Aronofsky",
                        Year = "2010",
                        Duration = 108,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10021",
                        Title = "The Shape of Water",
                        Description =
                            "At a top-secret research facility in the 1960s, a lonely janitor forms a unique relationship with an amphibious creature that is being held in captivity.",
                        Genre = ["Adventure", "Drama", "Fantasy"],
                        Director = "Guillermo del Toro",
                        Year = "2017",
                        Duration = 123,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10022",
                        Title = "The Wolf of Wall Street",
                        Description =
                            "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption, and the federal government.",
                        Genre = ["Biography", "Comedy", "Crime"],
                        Director = "Martin Scorsese",
                        Year = "2013",
                        Duration = 180,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10023",
                        Title = "The Imitation Game",
                        Description =
                            "During World War II, mathematician Alan Turing tries to crack the enigma code with help from fellow mathematicians.",
                        Genre = ["Biography", "Drama", "Thriller"],
                        Director = "Morten Tyldum",
                        Year = "2014",
                        Duration = 114,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10024",
                        Title = "Moonlight",
                        Description =
                            "A young African-American man grapples with his identity and sexuality while experiencing the everyday struggles of childhood, adolescence, and burgeoning adulthood.",
                        Genre = ["Drama"],
                        Director = "Barry Jenkins",
                        Year = "2016",
                        Duration = 111,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10025",
                        Title = "The Shape of Water",
                        Description =
                            "At a top-secret research facility in the 1960s, a lonely janitor forms a unique relationship with an amphibious creature that is being held in captivity.",
                        Genre = ["Adventure", "Drama", "Fantasy"],
                        Director = "Guillermo del Toro",
                        Year = "2017",
                        Duration = 123,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10026",
                        Title = "The Greatest Showman",
                        Description =
                            "Inspired by the imagination of P.T. Barnum, The Greatest Showman is an original musical that celebrates the birth of show business and tells of a visionary who rose from nothing to create a spectacle that became a worldwide sensation.",
                        Genre = ["Biography", "Drama", "Musical"],
                        Director = "Michael Gracey",
                        Year = "2017",
                        Duration = 105,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        MovieId = "10027",
                        Title = "Birdman or (The Unexpected Virtue of Ignorance)",
                        Description =
                            "A washed-up actor who once played an iconic superhero must overcome his ego and family trouble as he mounts a Broadway play in a bid to reclaim his past glory.",
                        Genre = ["Comedy", "Drama"],
                        Director = "Alejandro González Iñárritu",
                        Year = "2014",
                        Duration = 119,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10028",
                        Title = "La La Land",
                        Description =
                            "In Los Angeles, aspiring actress Mia and jazz musician Sebastian fall in love but are faced with opportunities that threaten to separate them.",
                        Genre = ["Comedy", "Drama", "Musical"],
                        Director = "Damien Chazelle",
                        Year = "2016",
                        Duration = 128,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10029",
                        Title = "Inception",
                        Description =
                            "A thief who enters the dreams of others to steal their secrets gets a chance to redeem himself by planting an idea in the mind of a CEO.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Christopher Nolan",
                        Year = "2010",
                        Duration = 148,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10030",
                        Title = "The Dark Knight Rises",
                        Description =
                            "Eight years after the Joker's reign of anarchy, Batman, with the help of the enigmatic Catwoman, is forced from his exile to save Gotham City from the brutal guerrilla terrorist Bane.",
                        Genre = ["Action", "Adventure", "Thriller"],
                        Director = "Christopher Nolan",
                        Year = "2012",
                        Duration = 164,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10031",
                        Title = "Toy Story 3",
                        Description =
                            "The toys are mistakenly delivered to a day-care center instead of the attic right before Andy leaves for college, and it's up to Woody to convince the other toys that they weren't abandoned and to return home.",
                        Genre = ["Animation", "Adventure", "Comedy"],
                        Director = "Lee Unkrich",
                        Year = "2010",
                        Duration = 103,
                        Rating = "G"
                    },
                    new Movie
                    {
                        MovieId = "10032",
                        Title = "Gravity",
                        Description =
                            "A medical engineer and an astronaut work together to survive after an accident leaves them adrift in space.",
                        Genre = ["Drama", "Sci-Fi", "Thriller"],
                        Director = "Alfonso Cuarón",
                        Year = "2013",
                        Duration = 91,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10033",
                        Title = "1917",
                        Description =
                            "Two young British soldiers during the First World War are given an impossible mission: deliver a message deep in enemy territory that will stop 1,600 men, and one of the soldiers' brothers, from walking straight into a deadly trap.",
                        Genre = ["Drama", "War"],
                        Director = "Sam Mendes",
                        Year = "2019",
                        Duration = 119,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10034",
                        Title = "Get Out",
                        Description =
                            "A young African-American visits his white girlfriend's parents for the weekend, where his simmering uneasiness about their reception of him eventually reaches a boiling point.",
                        Genre = ["Horror", "Mystery", "Thriller"],
                        Director = "Jordan Peele",
                        Year = "2017",
                        Duration = 104,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10035",
                        Title = "The Help",
                        Description =
                            "An aspiring author during the civil rights movement of the 1960s decides to write a book detailing the African American maids' point of view on the white families for which they work, and the hardships they go through on a daily basis.",
                        Genre = ["Drama"],
                        Director = "Tate Taylor",
                        Year = "2011",
                        Duration = 146,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10036",
                        Title = "The King's Speech",
                        Description =
                            "The story of King George VI, his impromptu ascension to the throne of the British Empire in 1936, and the speech therapist who helped the unsure monarch overcome his stammer.",
                        Genre = ["Biography", "Drama", "History"],
                        Director = "Tom Hooper",
                        Year = "2010",
                        Duration = 118,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10037",
                        Title = "Logan",
                        Description =
                            "In a future where mutants are nearly extinct, an elderly and weary Logan leads a quiet life. But when Laura, a mutant child pursued by scientists, comes to him for help, he must get her to safety.",
                        Genre = ["Action", "Drama", "Sci-Fi"],
                        Director = "James Mangold",
                        Year = "2017",
                        Duration = 137,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10038",
                        Title = "The Girl with the Dragon Tattoo",
                        Description =
                            "A journalist is aided by a young female hacker in his search for the killer of a woman who has been dead for forty years.",
                        Genre = ["Crime", "Drama", "Mystery"],
                        Director = "David Fincher",
                        Year = "2011",
                        Duration = 158,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10039",
                        Title = "Her",
                        Description =
                            "In a near future, a lonely writer develops an unlikely relationship with an operating system designed to meet his every need.",
                        Genre = ["Drama", "Romance", "Sci-Fi"],
                        Director = "Spike Jonze",
                        Year = "2013",
                        Duration = 126,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10040",
                        Title = "The Revenant",
                        Description =
                            "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.",
                        Genre = ["Adventure", "Drama", "Thriller"],
                        Director = "Alejandro González Iñárritu",
                        Year = "2015",
                        Duration = 156,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10041",
                        Title = "Arrival",
                        Description =
                            "A linguist is recruited by the military to assist in translating alien communications.",
                        Genre = ["Drama", "Mystery", "Sci-Fi"],
                        Director = "Denis Villeneuve",
                        Year = "2016",
                        Duration = 116,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10042",
                        Title = "Whiplash",
                        Description =
                            "A promising young drummer enrolls at a cutthroat music conservatory where his dreams of greatness are mentored by an instructor who will stop at nothing to realize a student's potential.",
                        Genre = ["Drama", "Music"],
                        Director = "Damien Chazelle",
                        Year = "2014",
                        Duration = 107,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10043",
                        Title = "Black Panther",
                        Description =
                            "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and confront a challenger from his country's past.",
                        Genre = ["Action", "Adventure", "Sci-Fi"],
                        Director = "Ryan Coogler",
                        Year = "2018",
                        Duration = 134,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10044",
                        Title = "The Florida Project",
                        Description =
                            "Set over one summer, the film follows precocious six-year-old Moonee as she courts mischief and adventure with her ragtag playmates and bonds with her rebellious but caring mother, all while living in the shadows of Disney World.",
                        Genre = ["Drama"],
                        Director = "Sean Baker",
                        Year = "2017",
                        Duration = 111,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10045",
                        Title = "The Shape of Water",
                        Description =
                            "At a top-secret research facility in the 1960s, a lonely janitor forms a unique relationship with an amphibious creature that is being held in captivity.",
                        Genre = ["Adventure", "Drama", "Fantasy"],
                        Director = "Guillermo del Toro",
                        Year = "2017",
                        Duration = 123,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10046",
                        Title = "Hereditary",
                        Description =
                            "After the family matriarch passes away, a grieving family is haunted by tragic and disturbing occurrences, and begin to unravel dark secrets.",
                        Genre = ["Drama", "Horror", "Mystery"],
                        Director = "Ari Aster",
                        Year = "2018",
                        Duration = 127,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10047",
                        Title = "The Grand Budapest Hotel",
                        Description =
                            "A writer encounters the owner of an aging high-class hotel, who tells him of his early years serving as a lobby boy in the hotel's glorious years under an exceptional concierge.",
                        Genre = ["Adventure", "Comedy", "Crime"],
                        Director = "Wes Anderson",
                        Year = "2014",
                        Duration = 99,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10048",
                        Title = "Silver Linings Playbook",
                        Description =
                            "After a stint in a mental institution, former teacher Pat Solitano moves back in with his parents and tries to reconcile with his ex-wife. Things get more challenging when Pat meets Tiffany, a mysterious girl with problems of her own.",
                        Genre = ["Comedy", "Drama", "Romance"],
                        Director = "David O. Russell",
                        Year = "2012",
                        Duration = 122,
                        Rating = "R"
                    },
                    new Movie
                    {
                        MovieId = "10049",
                        Title = "The Theory of Everything",
                        Description =
                            "The story of the relationship between the famous physicist Stephen Hawking and his wife.",
                        Genre = ["Biography", "Drama", "Romance"],
                        Director = "James Marsh",
                        Year = "2014",
                        Duration = 123,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieId = "10050",
                        Title = "Room",
                        Description = "A young boy is raised within the confines of a small shed.",
                        Genre = ["Drama", "Thriller"],
                        Director = "Lenny Abrahamson",
                        Year = "2015",
                        Duration = 118,
                        Rating = "R"
                    }
                );
                ctx.SaveChanges();
                Console.WriteLine("======== Movie Data Seeding Successful ========");
            }
            else
            {
                Console.WriteLine("Movie Data Already Exists");
            }
        }
    }
}
