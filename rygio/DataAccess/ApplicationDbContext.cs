using Microsoft.EntityFrameworkCore;
using rygio.Domain.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public DbSet<PostMember> postMembers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RegionMember> RegionMembers { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }


    }
}
