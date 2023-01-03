using System;
using System.Linq;
using AutoMapper;
using HelloWebapi.Common;
using HelloWebapi.DBOperations;

namespace HelloWebapi.BookOperations.GetBookDetail
{


    public class GetBookDetailQuery {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper  _mapper;
        private BookStoreDbContext context;

        public int BookId {get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
                _dbContext = dbcontext;
                _mapper = mapper;
            
        }

        public GetBookDetailQuery(BookStoreDbContext context)
        {
            this.context = context;
        }

        public BookDetailViewModel Handle(){

            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("kitap _dbcontext te yok ");
            //source target a maplenecek
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book); 
             // ** MAPPER DÖNDÜRÜYOR ** new BookDetailViewModel();
           //****MAPPER KULLANNDIK*******
            // vm.Title = book.Title;
            // vm.PageCount = book.PageCount;
            // vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            // vm.Genre=((GenreEnum)book.GenreId).ToString();
            return vm; 
        }
    }

//bunu mapper ile Book.cs deki source a mapliyeceğiz
public class BookDetailViewModel{

    public string Title { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
}

}