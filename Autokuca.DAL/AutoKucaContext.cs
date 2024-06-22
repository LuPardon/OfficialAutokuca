using System;
using System.Collections.Generic;
using Autokuca.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autokuca.DAL;

public partial class AutoKucaContext : IdentityDbContext
{
    public AutoKucaContext()
    {
    }

    public AutoKucaContext(DbContextOptions<AutoKucaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Salon> Saloni { get; set; }

    public virtual DbSet<Vozilo> Vozila { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-29MJTKP\\SQLEXPRESS;Initial Catalog=auto_kuca; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

         modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasNoKey();

        modelBuilder.Entity<IdentityUserRole<string>>()
           .HasNoKey();

        modelBuilder.Entity<IdentityUserToken<string>>()
       .HasNoKey();

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Salon>(entity =>
        {
            entity.HasKey(e => e.IdSalona).HasName("PK__salon__A2712FEE52A44B9E");

            entity.ToTable("salon");

            entity.Property(e => e.IdSalona).HasColumnName("id_salona");
            entity.Property(e => e.NazivSalona)
                .HasMaxLength(100)
                .HasColumnName("naziv_salona");
        });

        modelBuilder.Entity<Vozilo>(entity =>
        {
            entity.HasKey(e => e.IdVozilo).HasName("PK__vozilo__899BBC82208DEA1F");

            entity.ToTable("vozilo");

            entity.Property(e => e.IdVozilo).HasColumnName("id_vozilo");
            entity.Property(e => e.Cijena)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cijena");
            entity.Property(e => e.GodProizvodnje).HasColumnName("god_proizvodnje");
            entity.Property(e => e.Gorivo)
                .HasColumnType("text")
                .HasColumnName("gorivo");
            entity.Property(e => e.IdSalona).HasColumnName("id_salona");
            entity.Property(e => e.Mjenjac)
                .HasColumnType("text")
                .HasColumnName("mjenjac");
            entity.Property(e => e.ModelVozila)
                .HasColumnType("text")
                .HasColumnName("model_vozila");
            entity.Property(e => e.OznakaVozila)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("oznaka_vozila");
            entity.Property(e => e.Proizvodac)
                .HasMaxLength(50)
                .HasColumnName("proizvodac");
            entity.Property(e => e.SnagaMotora)
                .HasMaxLength(15)
                .HasColumnName("snaga_motora");
            entity.Property(e => e.TipVozila)
                .HasMaxLength(50)
                .HasColumnName("tip_vozila");
            entity.Property(e => e.VrstaVozila)
                .HasColumnType("text")
                .HasColumnName("vrsta_vozila");

            entity.HasOne(d => d.IdSalonaNavigation).WithMany(p => p.Vozilos)
                .HasForeignKey(d => d.IdSalona)
                .HasConstraintName("FK__vozilo__id_salon__71D1E811");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
