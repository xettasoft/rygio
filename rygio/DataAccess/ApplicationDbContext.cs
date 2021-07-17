using Microsoft.EntityFrameworkCore;
using rygio.Domain.AppData;

namespace rygio.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Collectable> Collectables { get; set; }
        public DbSet<CollectableTrail> CollectableTrails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceMember> ExperienceMembers { get; set; }
        public DbSet<ExperienceStage> ExperienceStages { get; set; }
        public DbSet<ExperienceStageCollectible> ExperienceStageCollectibles { get; set; }
        public DbSet<Payout> Payouts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostMember> PostMembers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RegionMember> RegionMembers { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Username)
                .IsUnique();
            modelBuilder.Entity<Collectable>()
                .HasIndex(b => b.Reference)
                .IsUnique();
            modelBuilder.Entity<Experience>()
                .HasIndex(b => b.Reference)
                .IsUnique();
            modelBuilder.Entity<Post>()
                .HasIndex(b => b.Reference)
                .IsUnique();
            modelBuilder.Entity<Region>()
                .HasIndex(b => b.Reference)
                .IsUnique();
        }

    }
}
