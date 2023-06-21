using AutoMapper;
using Library.Application.DTOs.Book;
using Library.Application.DTOs.Category;
using Library.Application.DTOs.Order;
using Library.Application.DTOs.User;
using Library.Application.DTOs.Writer;
using Library.Application.Features.Command.Book.AddBook;
using Library.Application.Features.Command.Category.AddCategory;
using Library.Application.Features.Command.Order.AddOrder;
using Library.Application.Features.Command.User.RegisterUser;
using Library.Application.Features.Command.Writer.AddWriter;
using Library.Domain.Entities;

namespace Library.Application.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Writer, WriterDto>().ReverseMap();
        CreateMap<Writer, WriterListDto>().ReverseMap();
        CreateMap<Writer, AddWriterCommand>().ReverseMap();

        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryListDto>().ReverseMap();
        CreateMap<Category, AddCategoryCommand>().ReverseMap();

        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserListDto>().ReverseMap();
        CreateMap<User, RegisterUserCommand>().ReverseMap();

        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderListDto>().ReverseMap();
        CreateMap<Order, AddOrderCommand>().ReverseMap();

        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookListDto>().ReverseMap();
        CreateMap<Book, AddBookCommand>().ReverseMap();
    }
}