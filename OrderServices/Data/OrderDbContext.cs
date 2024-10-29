
//using Microsoft.EntityFrameworkCore;
//using OrderServices.Model;
//namespace OrderServices.Data
//{
//    public class OrderDbContext : DbContext
//    {
//        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options) { 
//        }
         
//        public DbSet<OrderModel> Orders { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<OrderModel>().HasData(
//                new OrderModel
//                {
//                    Id = 1,
//                }
//                );
//        }
//            }

//}
