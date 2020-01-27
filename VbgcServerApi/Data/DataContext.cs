using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.Helpers;

namespace VbgcServerApi.Data
{
    public class DataContext : DbContext
    {
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Complexity> Complexities { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<TransactionStatus> TransactionStatus { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<PlayerSize> PlayerSizes { get; set; }
		public DbSet<Franchise> Franchises { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
			{
				modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
			}

			modelBuilder.Entity<UserInRole>().HasKey(o => new { o.UserId, o.RoleId });
			modelBuilder.Entity<UserInRole>()
				.HasOne<User>(sc => sc.User)
				.WithMany(s => s.UserInRoles)
				.HasForeignKey(sc => sc.UserId);
			modelBuilder.Entity<UserInRole>()
				.HasOne<Role>(sc => sc.Role)
				.WithMany(s => s.UserInRoles)
				.HasForeignKey(sc => sc.RoleId);

			modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.OrderId, o.GameId });
			modelBuilder.Entity<OrderDetail>()
				.HasOne<Order>(sc => sc.Order)
				.WithMany(s => s.OrderDetails)
				.HasForeignKey(sc => sc.OrderId);
			modelBuilder.Entity<OrderDetail>()
				.HasOne<Game>(sc => sc.Game)
				.WithMany(s => s.OrderDetails)
				.HasForeignKey(sc => sc.GameId);

			SeedAdminUser(modelBuilder);
		}

		private void SeedAdminUser(ModelBuilder modelBuilder)
		{
			var adminRole = new Role { RoleId = 1, RoleName = "admin" };
			modelBuilder.Entity<Role>().HasData(adminRole);

			byte[] passwordHash, passwordSalt;
			AuthHelper.CreatePasswordHash("admin", out passwordHash, out passwordSalt);
			var adminUser = new User
			{
				UserId = 1,
				Username = "admin",
				FirstName = "Default",
				LastName = "Admin",
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt
			};
			modelBuilder.Entity<User>().HasData(adminUser);

			modelBuilder.Entity<UserInRole>().HasData(new UserInRole
			{
				RoleId = adminRole.RoleId,
				UserId = adminUser.UserId
			});
		}
	}
}
