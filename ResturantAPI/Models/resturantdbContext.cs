
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResturantAPI.Models
{
    public partial class resturantdbContext : DbContext
    {
        public bool IgnoreFilter { get; set; }
        public resturantdbContext()
        {
        }

        public resturantdbContext(DbContextOptions<resturantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customerorder> Customerorders { get; set; }
        public virtual DbSet<Resturantmenu> Resturantmenus { get; set; }
        public virtual DbSet<Resturant> Resturants { get; set; }
        public virtual DbSet<CsvView> CsvViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;port=3306;user=root;password=anmmn59;database=resturantdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CsvView>(entity =>
            {
                entity.ToTable("csvview");
                entity.HasNoKey();

                entity.Property(e => e.RestaurantName).HasColumnType("varchar(255)");
                entity.Property(e => e.NumberOfOrderedCustomer).HasColumnType("decimal(32,0)");
                entity.Property(e => e.ProfitInUsd).HasColumnType("decimal(42,2)");
                entity.Property(e => e.ProfitInNis).HasColumnType("decimal(42,2)");
                entity.Property(e => e.TheBestSellingMeal).HasColumnType("varchar(255)");
                entity.Property(e => e.MostPurchasedCustomer).HasColumnType("varchar(511)");
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("firstName")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedDateUTC)
                    .HasColumnName("CreatedDate")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedDateUTC)
                    .HasColumnName("UpdatedDate")
                    .HasColumnType("TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate().
                    HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Customerorder>(entity =>
            {
                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.ToTable("customerorder");
                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.HasIndex(e => e.CustomerId, "CustomerId_idx");

                entity.HasIndex(e => e.MealId, "MealId_idx");


                entity.Property(e => e.OrderQuantity).HasColumnType("int");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerId");


                entity.HasOne(d => d.Meal)
                    .WithMany()
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MealId");
            });

            modelBuilder.Entity<Resturantmenu>(entity =>
            {
                entity.ToTable("resturantmenu");

                entity.HasIndex(e => e.ResturantId, "ResturantId_idx");

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PriceInNis).HasColumnType("decimal(10,2)");

                entity.Property(e => e.PriceInUsd).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Quantity).HasColumnType("int");

                entity.Property(e => e.CreatedDateUTC)
                    .HasColumnName("CreatedDate")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedDateUTC)
                    .HasColumnName("UpdatedDate")
                    .HasColumnType("TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate().
                    HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Resturant)
                    .WithMany(p => p.Resturantmenus)
                    .HasForeignKey(d => d.ResturantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ResturantId");
            });

            modelBuilder.Entity<Resturant>(entity =>
            {
                entity.ToTable("resturant");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedDateUTC)
                    .HasColumnName("CreatedDate")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedDateUTC)
                    .HasColumnName("UpdatedDate")
                    .HasColumnType("TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate().
                    HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Customer>().HasQueryFilter(a => !a.Archived);
            modelBuilder.Entity<Resturantmenu>().HasQueryFilter(a => !a.Archived);
            modelBuilder.Entity<Resturant>().HasQueryFilter(a => !a.Archived);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
