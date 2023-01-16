using Silvernet.Models;
using Silvernet.Models.DTO;

namespace Silvernet.Repository.IRepository {
	public interface IOrderDetailRepository {

		Task<ICollection<OrderDetail>> GetAllOrderDetail();

		Task<ICollection<OrderDetail>> GetAllOrderDetailByUser(string userEmail);

		Task<OrderDetail> GetOneOrderDetail(int id);

		Task<OrderDetailViewDTO> CreateOrderDetail(string email);

	}
}
