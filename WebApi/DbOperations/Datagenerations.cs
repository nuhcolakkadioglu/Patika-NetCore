using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DbOperations
{
    public class Datagenerations
    {
        public static  void Initializer(IServiceProvider serviceProvider)
        {
            using (BookStoreDbContext context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(

                    new Book
                    {
                      
                        GenreId = 1,
                        PageCount = 250,
                        PublishDate = DateTime.Now,
                        Title = "php giriş"
                    },
                    new Book
                    {
                      
                        GenreId = 1,
                        PageCount = 250,
                        PublishDate = DateTime.Now,
                        Title = "Asp giriş"
                    },
                    new Book
                    {
                       
                        GenreId = 1,
                        PageCount = 250,
                        PublishDate = DateTime.Now,
                        Title = "mYsql giriş"
                    },
                    new Book
                    {
                        
                        GenreId = 1,
                        PageCount = 250,
                        PublishDate = DateTime.Now,
                        Title = "bootstrap giriş"
                    }
                        );

                context.SaveChanges();
            }

         
        }
    }
}
