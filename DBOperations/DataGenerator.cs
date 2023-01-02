using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWebapi.DBOperations{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider  serviceProvider )
        {
            //<> arasına tipini tanımladık 
            using (var context = new BookStoreDbContext (serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())) 
            {
                //db de data varsa tekrardan yazma
                if(context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange( new Book{
                // Id= 1,
                Title ="Lean Startup",
                GenreId = 1,//Personal Growth
                PageCount  = 200,
                PublishDate = new DateTime(1999,08,11)
            },
            new Book{
                // Id= 2,                               [DatabaseGenerated(DatabaseGeneratedOption.Identity)] yaparak books alanında id otomatik arttırıyorzu

                Title ="Tanrılar Okulu",
                GenreId = 3,//Science Fiction 
                PageCount  = 400,
                PublishDate = new DateTime(2022,08,11)
            },
              new Book{
                // Id= 3,
                Title =" Hayvan çiftliği",
                GenreId = 2,//Science Fiction 
                PageCount  = 330,
                PublishDate = new DateTime(2032,08,11)
            });
            context.SaveChanges();



            }        
        }
    }
}