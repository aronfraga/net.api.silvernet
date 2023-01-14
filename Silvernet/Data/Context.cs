using Microsoft.EntityFrameworkCore;
using Silvernet.Models;

namespace Silvernet.Data {
	public class Context : DbContext {

		public Context(DbContextOptions<Context> options) : base(options) {
		
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

	}
}
