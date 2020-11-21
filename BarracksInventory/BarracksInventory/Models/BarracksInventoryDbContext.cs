using Microsoft.EntityFrameworkCore;

namespace BarracksInventory.Models
{
    public class BarracksInventoryDbContext
    : DbContext
    {
        //   F i e l d s   &   P r o p e t r i e s

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Inspection> Inspections { get; set; }

        //   C o n s t r u c t o r s

        public BarracksInventoryDbContext(DbContextOptions<BarracksInventoryDbContext> options)
           : base(options)
        {
        }

        //   M e t h o d s
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasData
                (new Account
                {
                    UserId = 1,
                    UnitId = 123,
                    Name = "Joe Rock",
                    SSN = "654-54-6546",
                    Phone = "555 123-1234",
                    Address = "123 Littlehouse St. Prairie, IA",
                }
                );

            modelBuilder.Entity<Account>().HasData
                (new Account
                {
                    UserId = 2,
                    UnitId = 23,
                    Name = "Joey Stone",
                    SSN = "654-54-6547",
                    Phone = "555 123-5234",
                    Address = "123 Littlehouse St. Prairie, IA",
                }
                );

            modelBuilder.Entity<Account>().HasData
                (new Account
                {
                    UserId = 3,
                    UnitId = 13,
                    Name = "Jill Rock",
                    SSN = "654-74-6546",
                    Phone = "555 523-1234",
                    Address = "126 Littlehouse St. Prairie, IA",
                }
                );

            modelBuilder.Entity<Account>().HasData
                (new Account
                {
                    UserId = 4,
                    UnitId = 12,
                    Name = "Jim Rock",
                    SSN = "653-54-6546",
                    Phone = "555 823-1234",
                    Address = "123 &1/2 Littlehouse St. Prairie, IA",
                }
                );

            modelBuilder.Entity<Account>().HasData
                (new Account
                {
                    UserId = 5,
                    UnitId = 1223,
                    Name = "Joe Cool",
                    SSN = "654-54-6646",
                    Phone = "555 923-1234",
                    Address = "122 Littlehouse St. Prairie, IA",
                }
                );

            modelBuilder.Entity<Account>().HasData
                (new Account
                {
                    UserId = 6,
                    UnitId = 623,
                    Name = "Mark Pen",
                    SSN = "654-54-6846",
                    Phone = "555 883-1234",
                    Address = "123 Mittlehouse St. Prairie, IA",
                }
                );
        }
    }
}
