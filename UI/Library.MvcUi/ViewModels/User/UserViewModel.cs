using Library.MvcUi.Models.Book;
using Library.MvcUi.Models.Order;
using Library.MvcUi.Models.User;

namespace Library.MvcUi.ViewModels.User
{
    public class UserViewModel
    {
        public UserModel UserModel { get; set; }
        public List<OrderModel> OrderModels { get; set; }
        public List<BookModel> BookModels { get; set; }
    }
}
