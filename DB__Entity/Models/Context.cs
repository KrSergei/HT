using Microsoft.EntityFrameworkCore;

namespace DB__Entity.Models
{
    public class Context : DbContext
    {
        private string _connectionString = "Host=localhost;Username=postgres;Password=1;Database=ChatDb";
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine).UseLazyLoadingProxies().UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {

                entity.HasKey(x => x.ID_user).HasName("user_pkey");
                entity.ToTable("Users");
                entity.Property(x => x.ID_user).HasColumnName("user_id");
                entity.Property(x => x.Name)
                      .HasMaxLength(255)
                      .HasColumnName("Name");
            });

            modelBuilder.Entity<Message>(entity => 
            { 
                entity.HasKey(x => x.id_message).HasName("message_pkey");
                entity.ToTable("Messages");
                entity.Property(x => x.id_message).HasColumnName("message_id");
                entity.Property(x => x.text).HasColumnName("text");
                entity.Property(x => x.FromUserId).HasColumnName("from_user_id");
                entity.Property(x => x.ToUserId).HasColumnName("to_user_id");

                entity.HasOne(x => x.FromUser)
                      .WithMany(p => p.FromMessages)
                      .HasForeignKey(c => c.FromUserId)
                      .HasConstraintName("messages_from_user_id_fkey");

                entity.HasOne(x => x.ToUser)
                      .WithMany(p => p.ToMessages)
                      .HasForeignKey(c => c.ToUserId)
                      .HasConstraintName("messages_to_user_id_fkey");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
