using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HelloWebapi.Common;
using HelloWebapi.DBOperations;


namespace HelloWebapi.BookOperations.CreateBook{

public class CreateBookCommand{
    public CreateBookModel Model {get; set; }
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }




    public void Handle(){
         

          var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
        if(book is not null)
            throw new InvalidOperationException("Kitap Zaten Mevcut!!");
            //target obje Book source üzerinden tipi alıcak Model. model ile gelen veriyi book objesine convert et
            book = _mapper.Map<Book>(Model); // new Book();
            //Mapper kullandığımız için gereksiz oldu bu kısımlar 
            // book.Title = Model.Title;
            // book.PublishDate=Model.PublishDate;
            // book.GenreId= Model.GenreId;
            // book.PageCount = Model.PageCount;

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