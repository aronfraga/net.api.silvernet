using Microsoft.EntityFrameworkCore;

namespace Silvernet.Data {
	public class Context : DbContext {

		public Context(DbContextOptions<Context> options) : base(options) {
		
		}


	}
}
