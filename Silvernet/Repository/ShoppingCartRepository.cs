using Silvernet.Data;
using Silvernet.Repository.IRepository;

namespace Silvernet.Repository {
	public class ShoppingCartRepository : IShoppingCartRepository {

		private readonly Context _dbcontext;

		public ShoppingCartRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}


	}
}
