
using Core.Entity.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Concrete.EntityFramework.Seed;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class HubContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            optionsBuilder.UseMySql(
                configuration.GetValue<string>("ConnectionStrings:DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PostHasTag
            modelBuilder
                .Entity<PostHasTag>()
                .HasKey(x => new { x.PostId, x.TagId });
            modelBuilder.Entity<PostHasTag>()
                .HasOne<Post>(x => x.Post)
                .WithMany(s => s.Tags)
                .HasForeignKey(x => x.PostId);
            modelBuilder.Entity<PostHasTag>()
                .HasOne<Tag>(x => x.Tag)
                .WithMany(s => s.Posts)
                .HasForeignKey(x => x.TagId);

            // UserLikePost
            modelBuilder
                .Entity<UserLikePost>()
                .HasKey(x => new { x.UserId, x.PostId });
            modelBuilder.Entity<UserLikePost>()
                .HasOne<Post>(x => x.Post)
                .WithMany(s => s.Likes)
                .HasForeignKey(x => x.PostId);
            modelBuilder.Entity<UserLikePost>()
                .HasOne<User>(x => x.User)
                .WithMany(s => s.LikedPosts)
                .HasForeignKey(x => x.UserId);

            // UserDislikePost
            modelBuilder
                .Entity<UserDislikePost>()
                .HasKey(x => new { x.UserId, x.PostId });
            modelBuilder.Entity<UserDislikePost>()
                .HasOne<Post>(x => x.Post)
                .WithMany(s => s.Dislikes)
                .HasForeignKey(x => x.PostId);
            modelBuilder.Entity<UserDislikePost>()
                .HasOne<User>(x => x.User)
                .WithMany(s => s.DislikedPosts)
                .HasForeignKey(x => x.UserId);

            // UserLikeComment
            modelBuilder
                .Entity<UserLikeComment>()
                .HasKey(x => new { x.UserId, x.CommentId });
            modelBuilder.Entity<UserLikeComment>()
                .HasOne<Comment>(x => x.Comment)
                .WithMany(s => s.Likes)
                .HasForeignKey(x => x.CommentId);
            modelBuilder.Entity<UserLikeComment>()
                .HasOne<User>(x => x.User)
                .WithMany(s => s.LikedComments)
                .HasForeignKey(x => x.UserId);

            // UserDislikeComment
            modelBuilder
                .Entity<UserDislikeComment>()
                .HasKey(x => new { x.UserId, x.CommentId });
            modelBuilder.Entity<UserDislikeComment>()
                .HasOne<Comment>(x => x.Comment)
                .WithMany(s => s.Dislikes)
                .HasForeignKey(x => x.CommentId);
            modelBuilder.Entity<UserDislikeComment>()
                .HasOne<User>(x => x.User)
                .WithMany(s => s.DislikedComments)
                .HasForeignKey(x => x.UserId);

            // Comment
            modelBuilder
                .Entity<Comment>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Comments);

            // Post
            modelBuilder
                .Entity<Post>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Posts);

            
            SeedData.Seed(modelBuilder);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IEntity)entityEntry.Entity).Updated = DateTimeOffset.Now.ToUnixTimeSeconds();

                if (entityEntry.State == EntityState.Added)
                {
                    ((IEntity)entityEntry.Entity).Created = DateTimeOffset.Now.ToUnixTimeSeconds();
                }
            }

            return base.SaveChanges();
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<DepartmentCode> DepartmentCodes { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCode> UserCodes { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}