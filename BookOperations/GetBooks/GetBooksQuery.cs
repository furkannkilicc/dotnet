



using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HelloWebapi.Common;
using HelloWebapi.DBOperations;

namespace HelloWebapi.BookOperations.GetBooks
{


    public class GetBooksQuery 
    {
        //db operations içindeki dosyadan alır bookstoredbcontext i

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        
        public List<BooksViewModel> Handle()
        { 
            //BookControle getBooks içinden aldık
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            // mapper ile *****  new List<BooksViewModel>();
            //mapper ile yapacağız LİSTE OLACAK AMA
            // foreach (var book in bookList)
            // {
            //     vm.Add(new BooksViewModel()
            //     {
            //         Title = book.Title,
            //         Genre = ((GenreEnum)book.GenreId).ToString(),
            //         PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //         PageCount = book.PageCount
            //     });
            // }
            return vm;
        }
        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
 
}


}