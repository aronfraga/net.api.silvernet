using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Repository.IRepository;

namespace Silvernet.Repository {
	public class OrderDetailsRepository : IOrderDetailsRepository {

		private readonly Context _dbcontext;

		public OrderDetailsRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public Task<string> CreateOrderDetails(OrderDetails orderDetails) {
			throw new NotImplementedException();
		}

		public Task<string> DeleteOrderDetails(int id) {
			throw new NotImplementedException();
		}

		public Task<bool> ExistOrderDetails(int id) {
			throw new NotImplementedException();
		}

		public Task<ICollection<OrderDetails>> GetAllOrderDetails() {
			throw new NotImplementedException();
		}

		public Task<OrderDetails> GetOneOrderDetails(int id) {
			throw new NotImplementedException();
		}

		public Task<string> UpdateOrderDetails(OrderDetails orderDetails) {
			throw new NotImplementedException();
		}

	}
}
