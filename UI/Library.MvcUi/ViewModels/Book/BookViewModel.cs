using Library.MvcUi.Models.Book;
using Library.MvcUi.Models.Category;
using Library.MvcUi.Models.Order;
using Library.MvcUi.Models.User;
using Library.MvcUi.Models.Writer;

namespace Library.MvcUi.ViewModels.Book
{
    public class BookViewModel
    {
        public List<BookModel> BookModels { get; set; }
        public List<CategoryModel> CategoryModels { get; set; }
        public List<WriterModel> WriterModels { get; set; }
        public List<OrderModel> OrderModels { get; set; }
        public List<UserModel> UserModels { get; set; }
        public AddBookInput AddBookInput { get; set; }
    }
}
