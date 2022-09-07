using Core.Entity.Concrete;
using Core.Utilities.Security.Hashing;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataAccess.Concrete.EntityFramework.Seed
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            // Seed Role
            modelBuilder.Entity<OperationClaim>().HasData(
                new OperationClaim { Id = 1, Name = Role.Student },
                new OperationClaim { Id = 2, Name = Role.Business },
                new OperationClaim { Id = 3, Name = Role.Admin }
            );

            // Seed User
            string password = "myStrongPassword123";
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Berk Selvi",
                    Email = "berkslv@gmail.com",
                    Status = true,
                    Username = "berkslv",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Role = Role.Admin,
                }
            );

            string password2 = "myStrongPassword123";
            byte[] passwordHash2, passwordSalt2;
            HashingHelper.CreatePasswordHash(password2, out passwordHash2, out passwordSalt2);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    Name = "Deneme kullanıcısı",
                    Email = "test@example.com",
                    Status = true,
                    Username = "testuser",
                    PasswordSalt = passwordSalt2,
                    PasswordHash = passwordHash2,
                    Role = Role.Student,
                    UniversityId = 1,
                    FacultyId = 1,
                    DepartmentId = 1
                }
            );

            // Seed UserOperationClaim
            modelBuilder.Entity<UserOperationClaim>().HasData(
                new UserOperationClaim { Id = 1, UserId = 1, OperationClaimId = 3 }
            );
            modelBuilder.Entity<UserOperationClaim>().HasData(
                new UserOperationClaim { Id = 2, UserId = 2, OperationClaimId = 1 }
            );

            // deserialize JSON directly from a file
            var fileLocation = "/Users/berkslv/Documents/project/social-media-app/service/DataAccess/data.json";

            using (StreamReader file = File.OpenText(fileLocation))
            {
                JsonSerializer serializer = new JsonSerializer();

                var dataSet = (DataSet)serializer.Deserialize(file, typeof(DataSet));

                // Seed University
                modelBuilder.Entity<University>().HasData(dataSet.Universities);

                // Seed Faculty
                modelBuilder.Entity<Faculty>().HasData(dataSet.Faculties);

                // Seed DepartmentCode
                modelBuilder.Entity<DepartmentCode>().HasData(dataSet.DepartmentCodes);

                // Seed Department
                modelBuilder.Entity<Department>().HasData(dataSet.Departments);

                // Seed Tag
                modelBuilder.Entity<Tag>().HasData(dataSet.Tags);

                // Seed Post
                modelBuilder.Entity<Post>().HasData(dataSet.Posts);

                // Seed PostHasTag
                modelBuilder.Entity<PostHasTag>().HasData(dataSet.PostHasTags);

                // Seed Comment
                modelBuilder.Entity<Comment>().HasData(dataSet.Comments);
            }
        }
    }

    public class DataSet
    {
        public List<University> Universities { get; set; }

        public List<Faculty> Faculties { get; set; }

        public List<Department> Departments { get; set; }

        public List<DepartmentCode> DepartmentCodes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<PostHasTag> PostHasTags { get; set; }
    }
}
