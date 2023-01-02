
//ORM ARCI İLE DB İLE KOD DAKİ NESNELER ARASINDAKİ KÖPRÜ 
using Microsoft.EntityFrameworkCore;

namespace HelloWebapi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        { } 
        //book entity adı  books ile oluşturulan db de oluştuurlucak table adı , BOOK BOOKS UN REPLİKASI DB DEKİ BOOKS A BOOK İLE ERİŞEBİLİYORUZ
        public DbSet<Book> Books {get; set;}


    }

}
