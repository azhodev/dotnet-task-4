using Microsoft.EntityFrameworkCore;
using Task4.Data.Models;

namespace Task4.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresEnum<UserStatus>("app", "user_status");

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users", "app");

            entity.HasKey(x => x.Id).HasName("users_pkey");

            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Name).HasColumnName("name");
            entity.Property(x => x.Email).HasColumnName("email").HasColumnType("citext");
            entity.Property(x => x.PasswordHash).HasColumnName("password_hash");
            entity.Property(x => x.Status).HasColumnName("status").HasColumnType("app.user_status");
            entity.Property(x => x.LastLoginAt).HasColumnName("last_login_at");
            entity.Property(x => x.LastActivityAt).HasColumnName("last_activity_at");
            entity.Property(x => x.CreatedAt).HasColumnName("created_at");
            entity.Property(x => x.RowVersion).HasColumnName("row_version");

            entity.HasIndex(x => x.Email).IsUnique().HasDatabaseName("ux_users_email");
            entity.HasIndex(x => x.LastLoginAt).HasDatabaseName("ix_users_last_login_at");
            entity.HasIndex(x => x.Status).HasDatabaseName("ix_users_status");
        });
    }
}
