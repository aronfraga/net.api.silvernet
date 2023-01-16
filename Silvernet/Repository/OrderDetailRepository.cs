using Microsoft.EntityFrameworkCore;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Models.DTO;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;

namespace Silvernet.Repository {
	public class OrderDetailRepository : IOrderDetailRepository{

		private readonly Context _dbcontext;

		public OrderDetailRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public async Task<OrderDetailViewDTO> CreateOrderDetail(string email) {
			
			var shoppingCarts = await _dbcontext.ShoppingCarts.Include(data => data.User)
															  .Include(data => data.Product)
															  .Where(data => data.User.Email == email)
														      .Where(data => data.Status == false)
												              .ToListAsync();

			if (shoppingCarts.Count() == 0) throw new Exception($"{Messages.ORDER_NO_ORDER} {email}");

			var user = await _dbcontext.Users.FirstOrDefaultAsync(data => data.Email == email);
			if (user == null) throw new Exception(Messages.SOME_WRONG);

			OrderDetail orderDetail = new OrderDetail();
			OrderDetailViewDTO detailViewDTO = new OrderDetailViewDTO();

			foreach (var item in shoppingCarts) {
				item.Status = true;
				detailViewDTO.FinalPrice += item.TotalPrice;
			}

			detailViewDTO.shoppingCart = shoppingCarts;

			orderDetail.UserId = user.Id;
			orderDetail.FinalPrice = detailViewDTO.FinalPrice;

			_dbcontext.ShoppingCarts.UpdateRange(shoppingCarts);
			await _dbcontext.OrderDetails.AddAsync(orderDetail);
			await _dbcontext.SaveChangesAsync();

			return detailViewDTO;
		}

		public async Task<ICollection<OrderDetail>> GetAllOrderDetail() {
			return await _dbcontext.OrderDetails.Include(data => data.User).ToListAsync();
		}

		public async Task<ICollection<OrderDetail>> GetAllOrderDetailByUser(string userEmail) {
			return await _dbcontext.OrderDetails.Include(data => data.User)
												.Where(data => data.User.Email == userEmail)
												.ToListAsync();
		}

		public async Task<OrderDetail> GetOneOrderDetail(int id) {
			if (id == null || id == 0) throw new Exception(Messages.ORDER_BY_PARAMS);
			var response = await _dbcontext.OrderDetails.Include(data => data.User).FirstOrDefaultAsync(data => data.Id == id);
			if (response == null) throw new Exception(Messages.ORDER_NOT_EXIST);
			return response;
		}

	}
}
