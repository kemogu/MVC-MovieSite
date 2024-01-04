using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movieSiteApp.data;
using movieSiteApp.entity;

namespace movieSiteApp.data.Concrete
{
    public class SeedDatabase
    {
        public static void Initialize(AppDbContext context)
        {   // Database elle veri girme
            if(context.Movies.Any() || context.Categories.Any())
            {
                return; // database doluysa geri dönecek
            }
            // Categories tablosuna veri ekleme
            context.Categories.AddRange(
            new Category(){Id=1,Name="Dram"},
            new Category(){Id=2,Name="Suç"},
            new Category(){Id=3,Name="Aksiyon"},
            new Category(){Id=4,Name="Fantastik"},
            new Category(){Id=5,Name="Western"},
            new Category(){Id=6,Name="Gerilim"}
            );

            // Movies tablosuna veri ekleme
            context.Movies.AddRange(
                new Movie 
                {
                    Id = 1,
                    Title = "Esaretin Bedeli",
                    Duration = 142,
                    ReleaseDate =  new DateTime(1972),
                    ImdbRating = (double)9.3m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 2,
                    Title = "Baba",
                    Duration = 175,
                    ReleaseDate =  new DateTime(1994),
                    ImdbRating = (double)9.2m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 3,
                    Title = "Kara Şövalye",
                    Duration = 152,
                    ReleaseDate =  new DateTime(2008),
                    ImdbRating = (double)9.0m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 4,
                    Title = "Baba 2",
                    Duration = 202,
                    ReleaseDate =  new DateTime(1974),
                    ImdbRating = (double)9.0m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 5,
                    Title = "12 Öfkeli Adam",
                    Duration = 96,
                    ReleaseDate =  new DateTime(1957),
                    ImdbRating = (double)9.0m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 6,
                    Title = "Schindler'in Listesi",
                    Duration = 195,
                    ReleaseDate =  new DateTime(1993),
                    ImdbRating = (double)9.0m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 7,
                    Title = "Yüzüklerin Efendisi: Kralın Dönüşü",
                    Duration = 201,
                    ReleaseDate =  new DateTime(2003),
                    ImdbRating = (double)9.0m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 8,
                    Title = "Ucuz Roman",
                    Duration = 154,
                    ReleaseDate =  new DateTime(1994),
                    ImdbRating = (double)8.9m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 9,
                    Title = "Yüzüklerin Efendisi: Yüzük Kardeşliği",
                    Duration = 178,
                    ReleaseDate =  new DateTime(2001),
                    ImdbRating = (double)8.9m,
                    Description = "Ödüllü film"
                },
                new Movie 
                {
                    Id = 10,
                    Title = "İyi, Kötü ve Çirkin",
                    Duration = 161,
                    ReleaseDate =  new DateTime(1966),
                    ImdbRating = (double)8.8m,
                    Description = "Ödüllü film"
                }
            );
            // MoviesCategory tablosuna veri ekleme
            context.MovieCategories.AddRange(
            new MovieCategory(){MovieId=1,CategoryId=1},          
            new MovieCategory(){MovieId=1,CategoryId=2},          
            new MovieCategory(){MovieId=2,CategoryId=1},          
            new MovieCategory(){MovieId=2,CategoryId=2},          
            new MovieCategory(){MovieId=3,CategoryId=2},          
            new MovieCategory(){MovieId=3,CategoryId=3},          
            new MovieCategory(){MovieId=4,CategoryId=1},          
            new MovieCategory(){MovieId=4,CategoryId=2},          
            new MovieCategory(){MovieId=5,CategoryId=1},          
            new MovieCategory(){MovieId=5,CategoryId=2},
            new MovieCategory(){MovieId=6,CategoryId=1},          
            new MovieCategory(){MovieId=6,CategoryId=2},
            new MovieCategory(){MovieId=7,CategoryId=3},          
            new MovieCategory(){MovieId=7,CategoryId=4},
            new MovieCategory(){MovieId=8,CategoryId=6},          
            new MovieCategory(){MovieId=8,CategoryId=2},   
            new MovieCategory(){MovieId=9,CategoryId=3},          
            new MovieCategory(){MovieId=9,CategoryId=4},
            new MovieCategory(){MovieId=10,CategoryId=5},          
            new MovieCategory(){MovieId=10,CategoryId=2}
            );

            context.SaveChanges();
        }
    }
}