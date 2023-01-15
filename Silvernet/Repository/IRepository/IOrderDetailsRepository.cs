using Silvernet.Models;

namespace Silvernet.Repository.IRepository {
	public interface IOrderDetailsRepository {

		Task<ICollection<OrderDetails>> GetAllOrderDetails();

		Task<OrderDetails> GetOneOrderDetails(int id);

		Task<bool> ExistOrderDetails(int id);

		Task<string> CreateOrderDetails(OrderDetails orderDetails);

		Task<string> UpdateOrderDetails(OrderDetails orderDetails);

		Task<string> DeleteOrderDetails(int id);

	}
}
