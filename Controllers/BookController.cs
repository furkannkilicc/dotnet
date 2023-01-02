using System;
using System.Linq;
using HelloWebapi.BookOperations.CreateBook;
using HelloWebapi.BookOperations.DeleteBook;
using HelloWebapi.BookOperations.GetBookDetail;
using HelloWebapi.BookOperations.GetBooks;
using HelloWebapi.BookOperations.UpdateBook;
using HelloWebapi.DBOperations;
using Microsoft.AspNetCore.Mvc;

using static HelloWebapi.BookOperations.CreateBook.CreateBookCommand;
using static HelloWebapi.BookOperations.UpdateBook.UpdateBookCommand;

namespace HelloWebapi.AddControllers
{

    // [ApiController]
    [Route("[controller]s")]

    public class BookController : ControllerBase

    {
        //priv -readonly ile sadece constructordan erişilip set ettik  uyg içinden değişemez sadece ctor içinde set edilebilir.
        private readonly BookStoreDbContext _context;


        //constructor ile dbcontext e erişiyoruz 
        public BookController(BookStoreDbContext context)
        {
            _context = context;

        }

        // private static List<Book>BookList = new List<Book>()
        // {
        //     new Book{
        //         Id= 1,
        //         Title ="Lean Startup",
        //         GenreId = 1,//Personal Growth
        //         PageCount  = 200,
        //         PublishDate = new DateTime(1999,08,11)
        //     },
        //     new Book{
        //         Id= 2,
        //         Title ="Tanrılar Okulu",
        //         GenreId = 1,//Science Fiction 
        //         PageCount  = 400,
        //         PublisDate = new DateTime(2022,08,11)
        //     },
        //       new Book{
        //         Id= 3,
        //         Title =" Hayvan çiftliği",
        //         GenreId = 1,//Science Fiction 
        //         PageCount  = 330,
        //         PublisDate = new DateTime(2032,08,11)
        //     },
        // };

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
            //******** GetBooksQuery içinde Model yaparak değiştirdik ******
            // var  bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>(); 
            // return bookList;
        }

        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
           
           BookDetailViewModel result;
            try
            {
                 GetBookDetailQuery query = new GetBookDetailQuery(_context);
            query.BookId = id;
            result =  query.Handle();
            }
            catch (Exception ex )
            {
                
                return BadRequest(ex.Message);
             }
                return Ok(result);
           
           
           

           
           
            //  var  book = BookList.Where(book=> book.Id == id).SingleOrDefault();  eski hali buydu _contex e set ederek book liste eriştik
            // ************v2****************
            // var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            // return book;
        
    
        }
        // 2 HttpGet olmaz kızar üstteki root daha doğru bir yaklaşım
        //  [HttpGet]
        // public Book Get ([FromQuery] string id)
        // {
        //     var  book = BookList.Where(book=> book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }


        //POST
        [HttpPost]

        //validasyon badrequest döndürdüğümüz için void => IActionResult döndürdük
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle(); 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
             
             return Ok();

            // var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            // if(book is not null)
            //     return BadRequest();

            // _context.Books.Add(newBook);
            // _context.SaveChanges(); //// bunu ekledik db e ekleyince kayıt mesi için InmemoryDB yani
            // return Ok("İşlem tamam Status 200");
        }


        [HttpPut("{id}")]
        // updateBook adı , updatedbook ise parametre olarak verdiğimiz
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
           try
           {
                UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;
            command.Handle();
           }
           catch (Exception ex)
           {
                return BadRequest(ex.Message);             
           }
       
            return Ok();
           
            // var book = _context.Books.SingleOrDefault(x => x.Id == id);
            // if (book is null)
            //     return BadRequest();
            // //default yani değiştirilmişse or !=0
            // book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            // book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            // book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            // book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            // _context.SaveChanges();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {   
                try
                {
                    DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
                }
                catch (Exception ex)
                {
                    
                    return BadRequest(ex.Message);
                }
                return Ok();
                



            // var book = _context.Books.SingleOrDefault(x => x.Id == id);
            // if (book is null)
            //     return BadRequest();

            // _context.Books.Remove(book);
            // _context.SaveChanges();
            // return Ok();
        }


    }
}