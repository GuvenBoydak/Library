using Library.MvcUi.Models.Book;
using Library.MvcUi.Models.Order;
using Library.MvcUi.Models.User;

namespace Library.MvcUi.ViewModels.Order
{
    public class OrderViewModel
    {
        public List<UserModel> UserModels { get; set; }
        public BookModel BookModel { get; set; }

        public AddOrderInput AddOrderInput { get; set; }
    }
}
