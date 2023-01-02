using System;
using System.Collections.Generic;
using System.Linq;
using HelloWebapi.Common;
using HelloWebapi.DBOperations;


namespace HelloWebapi.BookOperations.CreateBook{

public class CreateBookCommand{
    public CreateBookModel Model {get; set; }
    private readonly BookStoreDbContext _dbContext;

    public CreateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }




    public void Handle(){
         

          var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
        if(book is not null)
            throw new InvalidOperationException("Kitap Zaten Mevcut!!");
            book = new Book();
            book.Title = Model.Title;
            book.PublishDate=Model.PublishDate;
            book.GenreId= Model.GenreId;
            book.PageCount = Model.PageCount;

        _dbContext.Books.Add(book);
        _dbContext.SaveChanges(); // bunu ekledik db e ekleyince kayıt mesi için InmemoryDB yani
    }





    public class CreateBookModel{
        public string Title { get; set; }
        public int GenreId  { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }

}

        
    
}