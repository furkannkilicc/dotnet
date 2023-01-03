using AutoMapper;
using HelloWebapi.BookOperations.GetBookDetail;
using static HelloWebapi.BookOperations.CreateBook.CreateBookCommand;
using static HelloWebapi.BookOperations.GetBooks.GetBooksQuery;

namespace HelloWebapi.Common{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateModel source , book Target yani creatmodel objesi book objesine maplenebilsin
            
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()) ); //cast ettik genre enum a otomatik id için 
           //formember ı her bir member ı nasıl mapleyeceğini belirtiyoruz
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()) );
        
        }

    }
}