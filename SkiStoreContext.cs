using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SkiStoreProject;

public partial class SkiStoreContext : DbContext
{
    public SkiStoreContext()
    {
    }

    public SkiStoreContext(DbContextOptions<SkiStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FFKVPG9;Database=SkiStore;User Id=SqlUser1;Password=asdf123;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Article__3214EC07DA23B1F8");

            entity.ToTable("Article");

            entity.HasIndex(e => e.Number, "UQ__Article__78A1A19D136C04B8").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PricePerDay).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Article__Categor__2D27B809");

            entity.HasOne(d => d.Customer).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Article__Custome__34C8D9D1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07109AF47A");

            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07E4756B9A");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Telefon, "UQ__Customer__92EB41695DFA3B88").IsUnique();

            entity.Property(e => e.Adress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3214EC07B734AE5E");

            entity.ToTable("employee");

            entity.HasIndex(e => e.Username, "UQ__employee__536C85E48DFAE183").IsUnique();

            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
