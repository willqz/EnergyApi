using Microsoft.EntityFrameworkCore;

namespace Energy.Domain.Entities;

public partial class EnergyDbContext : DbContext
{
    public EnergyDbContext()
    {
    }

    public EnergyDbContext(DbContextOptions<EnergyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Distributor> Distributors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EnergyDb;User Id=sa;Password=123!asd;TrustServerCertificate=true;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Distributor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Distribu__3214EC07AD764722");

            entity.ToTable("Distributor");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
