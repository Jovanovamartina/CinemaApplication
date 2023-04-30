
using DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppMVC.Repositories.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieProgram> MoviePrograms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SnackOrder> SnackOrders { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CinemaHall>().ToTable("CinemaHall");
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<MovieProgram>().ToTable("MovieProgram");
            builder.Entity<Reservation>().ToTable("Reservation");
            builder.Entity<Size>().ToTable("Size");
            builder.Entity<Snack>().ToTable("Snack");
            builder.Entity<SnackOrder>().ToTable("SnackOrder");

            builder.Entity<Movie>().HasData
                (
            new Movie("Avengers: Endgame", "Action, Adventure, Superhero, Fantasy, SCI-FI", 182, new DateTime(2019, 4, 26), "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg")
            {
                Description = "After Thanos, an intergalactic warlord, disintegrates half of the universe, " +
                "the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance.",
                Id = 1
            },
            new Movie("Spider-Man: No Way Home", "Action, Adventure, Superhero, Fantasy, SCI-FI, Comedy", 148, new DateTime(2021, 12, 17), "https://m.media-amazon.com/images/M/MV5BZWMyYzFjYTYtNTRjYi00OGExLWE2YzgtOGRmYjAxZTU3NzBiXkEyXkFqcGdeQXVyMzQ0MzA0NTM@._V1_FMjpg_UX1000_.jpg")
            {
                Description = "Peter Parker seeks Doctor Strange's help to make people forget about Spiderman's identity. " +
                "However, when the spell he casts gets corrupted, several unwanted guests enter their universe.",
                Id = 2
            },
            new Movie("Avengers: Infinity War", "Action, Superhero, SCI-FI", 149, new DateTime(2018, 4, 23), "https://upload.wikimedia.org/wikipedia/en/4/4d/Avengers_Infinity_War_poster.jpg")
            {
                Description = "The Avengers must stop Thanos, an intergalactic warlord, from getting his hands on all the infinity stones. " +
                "However, Thanos is prepared to go to any lengths to carry out his insane plan.",
                Id = 3
            },
            new Movie("Top Gun: Maverick", "Action, Drama, Adventure", 131, new DateTime(2022, 5, 27), "https://upload.wikimedia.org/wikipedia/en/thumb/1/13/Top_Gun_Maverick_Poster.jpg/220px-Top_Gun_Maverick_Poster.jpg")
            {
                Description = "After more than 30 years of service as one of the Navy's top aviators, " +
                "Pete Maverick Mitchell is where he belongs, pushing the envelope as a courageous test pilot and dodging the advancement in rank that would ground him. " +
                "Training a detachment of graduates for a special assignment, Maverick must confront the ghosts of his " +
                "past and his deepest fears, culminating in a mission that demands the ultimate sacrifice from those who choose to fly it.",
                Id = 4
            },
            new Movie("Minions: The Rise Of Gru", "Adventure, Comedy", 87, new DateTime(2022, 7, 1), "https://m.media-amazon.com/images/M/MV5BZDQyODUwM2MtNzA0YS00ZjdmLTgzMjItZWRjN2YyYWE5ZTNjXkEyXkFqcGdeQXVyMTI2MzY1MjM1._V1_.jpg")
            {
                Description = "In the 1970s, young Gru tries to join a group of supervillains called the Vicious 6 after they oust their leader -- " +
                "the legendary fighter Wild Knuckles. When the interview turns disastrous, Gru and his Minions go on the run with the Vicious 6 hot on their tails. " +
                "Luckily, he finds an unlikely source for guidance -- Wild Knuckles himself -- and soon discovers that even bad guys need a little help from their friends.",
                Id = 5
            },
            new Movie("Lightyear", "Adventure, Comedy", 105, new DateTime(2022, 6, 17), "https://m.media-amazon.com/images/M/MV5BYjhmNjczZTAtNGVhNy00ODliLTllYTctOTA5MDc5NWNlOWEwXkEyXkFqcGdeQXVyNDI3NjU1NzQ@._V1_.jpg")
            {
                Description = "Legendary space ranger Buzz Lightyear embarks on an intergalactic adventure " +
                "alongside ambitious recruits Izzy, Mo, Darby, and his robot companion, Sox." +
                "As this motley crew tackles their toughest mission yet, they must learn to work together as a team to escape " +
                "the evil Zurg and his dutiful robot army that are never far behind.",
                Id = 6
            },
            new Movie("Doctor Strange: In The Multiverse Of Madness", "Action, Adventure", 126, new DateTime(2022, 5, 6), "https://m.media-amazon.com/images/M/MV5BNWM0ZGJlMzMtZmYwMi00NzI3LTgzMzMtNjMzNjliNDRmZmFlXkEyXkFqcGdeQXVyMTM1MTE1NDMx._V1_.jpg")
            {
                Description = "Doctor Strange teams up with a mysterious teenage girl from his dreams who can travel across " +
                "multiverses, to battle multiple threats, including other-universe versions of himself, which threaten to wipe out millions across the multiverse.",
                Id = 7
            },
            new Movie("The Batman", "Action, Adventure", 176, new DateTime(2022, 3, 4), "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg")
            {
                Description = "Batman is called to intervene when the mayor of Gotham City is murdered. " +
                "Soon, his investigation leads him to uncover a web of corruption, " +
                "linked to his own dark past.",
                Id = 8
            }
                );
            builder.Entity<Snack>().HasData
                (
                    new Snack("XL Popcorn", 150, "https://images.unsplash.com/photo-1572177191856-3cde618dee1f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=327&q=80")
                    {
                        Id = 1
                    },
                    new Snack("Nacho Crunch", 200, "https://images.unsplash.com/photo-1589656613566-eab25964fb6b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=464&q=80")
                    {
                        Id = 2
                    },
                    new Snack("Sweet Taste", 250, "https://images.unsplash.com/photo-1602296750425-f025b045f355?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80")
                    {
                        Id = 3
                    },
                    new Snack("XL Nacho Crunch", 250, "https://images.unsplash.com/photo-1589656613566-eab25964fb6b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=464&q=80")
                    {
                        Id = 4
                    },
                    new Snack("Slushie Mountain", 200, "https://i.pinimg.com/736x/6b/bb/f0/6bbbf096b688ba08ad7eba24d8e083b5.jpg")
                    {
                        Id = 5
                    }
                );
            builder.Entity<Size>().HasData
                (
                        new Size(300, "Large Cinema Hall 1A")
                        {
                            Id = 1
                        },
                        new Size(300, "Large Cinema Hall 1B")
                        {
                            Id = 2
                        },
                        new Size(200, "Medium Cinema Hall 2A")
                        {
                            Id = 3
                        },
                        new Size(200, "Medium Cinema Hall 2B")
                        {
                            Id = 4
                        },
                        new Size(200, "Medium Cinema Hall 2C")
                        {
                            Id = 5
                        },
                        new Size(100, "Small Cinema Hall 3A")
                        {
                            Id = 6
                        },
                        new Size(100, "Small Cinema Hall 3B")
                        {
                            Id = 7
                        },
                        new Size(100, "Small Cinema Hall 3C")
                        {
                            Id = 8
                        }
                );
            builder.Entity<CinemaHall>().HasData
                (
                      new CinemaHall(1, 6)
                      {
                          Id = 1
                      },
                      new CinemaHall(2, 4)
                      {
                          Id = 2
                      },
                      new CinemaHall(3, 6)
                      {
                          Id = 3
                      },
                      new CinemaHall(4, 1)
                      {
                          Id = 4
                      },
                      new CinemaHall(5, 2)
                      {
                          Id = 5
                      },
                      new CinemaHall(6, 1)
                      {
                          Id = 6
                      },
                      new CinemaHall(7, 1)
                      {
                          Id = 7
                      },
                      new CinemaHall(8, 3)
                      {
                          Id = 8
                      },
                      new CinemaHall(5, 2)
                      {
                          Id = 9
                      },
                      new CinemaHall(6, 1)
                      {
                          Id = 10
                      },
                      new CinemaHall(4, 2)
                      {
                          Id = 11
                      }
                );
            builder.Entity<MovieProgram>().HasData
                (
                     new MovieProgram(1, DateTime.Now, "20:00", "23:05", 250)
                     {
                         Id = 1
                     },
                     new MovieProgram(2, DateTime.Now, "20:00", "22:30", 250)
                     {
                         Id = 2
                     },
                     new MovieProgram(3, DateTime.Now, "17:00", "19:30", 250)
                     {
                         Id = 3
                     },
                     new MovieProgram(4, DateTime.Now, "20:20", "22:35", 250)
                     {
                         Id = 4
                     },

                     new MovieProgram(5, DateTime.Now.AddDays(1), "19:00", "20:30", 250)
                     {
                         Id = 5
                     },
                     new MovieProgram(6, DateTime.Now.AddDays(1), "20:45", "22:30", 250)
                     {
                         Id = 6
                     },
                     new MovieProgram(8, DateTime.Now.AddDays(1), "20:00", "23:00", 250)
                     {
                         Id = 7
                     },
                     new MovieProgram(2, DateTime.Now.AddDays(1), "20:00", "22:30", 250)
                     {
                         Id = 8
                     },

                     new MovieProgram(7, DateTime.Now.AddDays(2), "20:00", "22:05", 250)
                     {
                         Id = 9
                     },
                     new MovieProgram(9, DateTime.Now.AddDays(2), "19:00", "20:30", 250)
                     {
                         Id = 10
                     },
                     new MovieProgram(10, DateTime.Now.AddDays(2), "20:45", "22:30", 250)
                     {
                         Id = 11
                     },
                     new MovieProgram(11, DateTime.Now.AddDays(2), "20:20", "22:35", 250)
                     {
                         Id = 12
                     }
                );
        }

    }
}