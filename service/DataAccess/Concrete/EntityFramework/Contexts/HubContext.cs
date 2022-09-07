
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
            // read from ENV
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            if (connectionString is null)
            {
                connectionString = "server=localhost;user=root;password=123456789;database=hub";
            }

            optionsBuilder.UseMySql(
                connectionString,
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
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                                   .Where(x => x.State == EntityState.Added)
                                   .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                var entity = insertedEntry as IEntity;
                //If the inserted object is an IEntity. 
                if (entity != null)
                {
                    entity.Created = DateTimeOffset.Now.ToUnixTimeSeconds();
                    entity.Updated = DateTimeOffset.Now.ToUnixTimeSeconds();
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Modified)
                       .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                //If the inserted object is an IEntity. 
                var entity = modifiedEntry as IEntity;
                if (entity != null)
                {
                    entity.Updated = DateTimeOffset.Now.ToUnixTimeSeconds();
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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