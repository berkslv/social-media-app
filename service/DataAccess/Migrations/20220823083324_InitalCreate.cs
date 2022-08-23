using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DepartmentCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCodes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FoundationYear = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Altitude = table.Column<double>(type: "double", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    DepartmentCodeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_DepartmentCodes_DepartmentCodeId",
                        column: x => x.DepartmentCodeId,
                        principalTable: "DepartmentCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniversityId = table.Column<int>(type: "int", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserCodes",
                columns: table => new
                {
                    UserCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCodes", x => x.UserCodeId);
                    table.ForeignKey(
                        name: "FK_UserCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostHasTag",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHasTag", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostHasTag_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostHasTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserDislikePost",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDislikePost", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserDislikePost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDislikePost_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLikePost",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikePost", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserLikePost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikePost_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserDislikeComment",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDislikeComment", x => new { x.UserId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_UserDislikeComment_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDislikeComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLikeComment",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Updated = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikeComment", x => new { x.UserId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_UserLikeComment_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikeComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "DepartmentCodes",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 1661243520L, "Acil Yardım ve Afet Yönetimi", 1661243520L },
                    { 2, 1661243520L, "Alman Dili ve Edebiyatı", 1661243520L },
                    { 3, 1661243520L, "Arkeoloji", 1661243520L },
                    { 4, 1661243520L, "Bahçe Bitkileri", 1661243520L },
                    { 5, 1661243520L, "Beslenme ve Diyetetik", 1661243520L },
                    { 6, 1661243520L, "Bilgisayar Mühendisliği", 1661243520L },
                    { 7, 1661243520L, "Bitki Koruma", 1661243520L },
                    { 8, 1661243520L, "Biyoloji", 1661243520L },
                    { 9, 1661243520L, "Biyomedikal Mühendisliği", 1661243520L },
                    { 10, 1661243520L, "Biyosistem Mühendisliği", 1661243520L },
                    { 11, 1661243520L, "Coğrafya", 1661243520L },
                    { 12, 1661243520L, "Çalışma Ekonomisi ve Endüstri İlişkileri", 1661243520L },
                    { 13, 1661243520L, "Çevre Mühendisliği", 1661243520L },
                    { 14, 1661243520L, "Elektrik-Elektronik Mühendisliği", 1661243520L },
                    { 15, 1661243520L, "Endüstri Mühendisliği", 1661243520L },
                    { 16, 1661243520L, "Fizik", 1661243520L },
                    { 17, 1661243520L, "Fransız Dili ve Edebiyatı", 1661243520L },
                    { 18, 1661243520L, "Gıda Mühendisliği", 1661243520L },
                    { 19, 1661243520L, "Hemşirelik", 1661243520L },
                    { 20, 1661243520L, "Hukuk", 1661243520L },
                    { 21, 1661243520L, "İktisat", 1661243520L },
                    { 22, 1661243520L, "İlahiyat", 1661243520L },
                    { 23, 1661243520L, "İngiliz Dili ve Edebiyatı", 1661243520L },
                    { 24, 1661243520L, "İnşaat Mühendisliği", 1661243520L },
                    { 25, 1661243520L, "İşletme", 1661243520L },
                    { 26, 1661243520L, "Kimya", 1661243520L },
                    { 27, 1661243520L, "Makine Mühendisliği", 1661243520L },
                    { 28, 1661243520L, "Maliye", 1661243520L },
                    { 29, 1661243520L, "Matematik", 1661243520L },
                    { 30, 1661243520L, "Mimarlık", 1661243520L },
                    { 31, 1661243520L, "Peyzaj Mimarlığı", 1661243520L },
                    { 32, 1661243520L, "Psikoloji", 1661243520L },
                    { 33, 1661243520L, "Siyaset Bilimi ve Kamu Yönetimi", 1661243520L },
                    { 34, 1661243520L, "Sosyoloji", 1661243520L },
                    { 35, 1661243520L, "Tarım Ekonomisi", 1661243520L },
                    { 36, 1661243520L, "Tarımsal Biyoteknoloji", 1661243520L },
                    { 37, 1661243520L, "Tarih", 1661243520L },
                    { 38, 1661243520L, "Tarla Bitkileri", 1661243520L },
                    { 39, 1661243520L, "Tekstil Mühendisliği", 1661243520L },
                    { 40, 1661243520L, "Tıp", 1661243520L },
                    { 41, 1661243520L, "Toprak Bilimi ve Bitki Besleme", 1661243520L },
                    { 42, 1661243520L, "Türk Dili ve Edebiyatı", 1661243520L },
                    { 43, 1661243520L, "Uluslararası İlişkiler", 1661243520L },
                    { 44, 1661243520L, "Veterinerlik", 1661243520L },
                    { 45, 1661243520L, "Zootekni", 1661243520L }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 0L, "Student", 0L },
                    { 2, 0L, "Business", 0L },
                    { 3, 0L, "Manager", 0L },
                    { 4, 0L, "Admin", 0L }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Created", "Description", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 1661243520L, "Sadece goygoy. Ciddi olma!", "Goygoy", 1661243520L },
                    { 2, 1661243520L, "Kedini burada paylaşabilirsin.", "Hayvani", 1661243520L },
                    { 3, 1661243520L, "İkinci el ürününü hemen elinden çıkart.", "İkinci el", 1661243520L },
                    { 4, 1661243520L, "Hadi tanışalım.", "Tanışma", 1661243520L },
                    { 5, 1661243520L, "Nerelerde takılıyorsun?", "Mekanlar", 1661243520L }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "City", "Created", "FoundationYear", "Name", "Updated" },
                values: new object[] { 1, "29", 1661243520L, 2000, "Tekirdağ Namık Kemal Üniversitesi", 1661243520L });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "Created", "OperationClaimId", "Updated", "UserId" },
                values: new object[] { 1, 0L, 4, 0L, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DepartmentId", "Email", "FacultyId", "Name", "PasswordHash", "PasswordSalt", "Role", "Status", "UniversityId", "Updated", "Username" },
                values: new object[] { 1, 0L, null, "berkslv@gmail.com", null, "Berk Selvi", new byte[] { 138, 145, 244, 78, 131, 154, 216, 210, 118, 67, 54, 195, 108, 195, 136, 100, 184, 210, 242, 213, 192, 204, 35, 33, 227, 77, 250, 219, 130, 100, 66, 123, 96, 170, 53, 118, 176, 122, 179, 80, 129, 44, 3, 192, 92, 47, 57, 228, 252, 239, 129, 41, 222, 250, 6, 236, 26, 251, 248, 33, 188, 30, 110, 83 }, new byte[] { 251, 49, 240, 142, 75, 4, 97, 106, 13, 164, 182, 142, 212, 156, 236, 211, 126, 44, 82, 213, 72, 66, 33, 2, 50, 1, 41, 88, 14, 3, 57, 25, 204, 244, 220, 89, 94, 40, 75, 111, 185, 201, 202, 176, 6, 24, 200, 142, 68, 67, 15, 32, 174, 128, 17, 21, 106, 118, 80, 97, 107, 217, 60, 215, 199, 155, 199, 187, 17, 120, 130, 153, 225, 180, 35, 198, 21, 232, 179, 35, 39, 10, 23, 246, 139, 231, 166, 55, 17, 236, 87, 117, 39, 192, 39, 124, 77, 153, 229, 69, 209, 122, 237, 109, 197, 243, 24, 25, 254, 214, 190, 32, 177, 100, 21, 51, 26, 9, 4, 90, 159, 77, 21, 94, 46, 14, 201, 154 }, "Admin", true, null, 0L, "berkslv" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Address", "Altitude", "Created", "Latitude", "Name", "UniversityId", "Updated" },
                values: new object[,]
                {
                    { 1, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Çorlu Mühendislik Fakültesi", 1, 1661243520L },
                    { 2, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Fen-Edebiyat Fakültesi", 1, 1661243520L },
                    { 3, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Ziraat Fakültesi", 1, 1661243520L },
                    { 4, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Hukuk Fakültesi", 1, 1661243520L },
                    { 5, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "İktisadi ve İdari Bilimler Fakültesi", 1, 1661243520L },
                    { 6, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "İlahiyat Fakültesi", 1, 1661243520L },
                    { 7, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Güzel Sanatlar, Tasarım ve Mimarlık Fakültesi", 1, 1661243520L },
                    { 8, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Tıp Fakültesi", 1, 1661243520L },
                    { 9, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Veteriner Fakültesi", 1, 1661243520L },
                    { 10, "Çorlu, silahtarağa mah.", 21.213124000000001, 1661243520L, 43.213411999999998, "Sağlık Yüksekokulu", 1, 1661243520L }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "Created", "Updated" },
                values: new object[,]
                {
                    { 1, 1, "I used to live in my neighbor's fishpond, but the aesthetic wasn't to my taste.", 1661243520L, 1661243520L },
                    { 2, 1, "The waitress was not amused when he ordered green eggs and ham.", 1661243520L, 1661243520L },
                    { 3, 1, "I don’t respect anybody who can’t tell the difference between Pepsi and Coke.", 1661243520L, 1661243520L }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "Created", "PostId", "Updated" },
                values: new object[,]
                {
                    { 1, 1, "Güzel gönderi", 1661243520L, 1, 1661243520L },
                    { 2, 1, "Tanışmak ister misin?", 1661243520L, 1, 1661243520L }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Created", "DepartmentCodeId", "FacultyId", "Updated" },
                values: new object[,]
                {
                    { 1, 1661243520L, 1, 10, 1661243520L },
                    { 2, 1661243520L, 2, 2, 1661243520L },
                    { 3, 1661243520L, 3, 2, 1661243520L },
                    { 4, 1661243520L, 4, 3, 1661243520L },
                    { 5, 1661243520L, 5, 10, 1661243520L },
                    { 6, 1661243520L, 6, 1, 1661243520L },
                    { 7, 1661243520L, 7, 3, 1661243520L },
                    { 8, 1661243520L, 8, 2, 1661243520L },
                    { 9, 1661243520L, 9, 1, 1661243520L },
                    { 10, 1661243520L, 10, 3, 1661243520L },
                    { 11, 1661243520L, 11, 2, 1661243520L },
                    { 12, 1661243520L, 12, 5, 1661243520L },
                    { 13, 1661243520L, 13, 1, 1661243520L },
                    { 14, 1661243520L, 14, 1, 1661243520L },
                    { 15, 1661243520L, 15, 1, 1661243520L },
                    { 16, 1661243520L, 16, 2, 1661243520L },
                    { 17, 1661243520L, 17, 2, 1661243520L },
                    { 18, 1661243520L, 18, 3, 1661243520L },
                    { 19, 1661243520L, 19, 10, 1661243520L },
                    { 20, 1661243520L, 20, 4, 1661243520L },
                    { 21, 1661243520L, 21, 5, 1661243520L },
                    { 22, 1661243520L, 22, 6, 1661243520L },
                    { 23, 1661243520L, 23, 2, 1661243520L },
                    { 24, 1661243520L, 24, 1, 1661243520L },
                    { 25, 1661243520L, 25, 5, 1661243520L },
                    { 26, 1661243520L, 26, 2, 1661243520L },
                    { 27, 1661243520L, 27, 1, 1661243520L },
                    { 28, 1661243520L, 28, 5, 1661243520L },
                    { 29, 1661243520L, 29, 2, 1661243520L },
                    { 30, 1661243520L, 30, 7, 1661243520L },
                    { 31, 1661243520L, 31, 7, 1661243520L },
                    { 32, 1661243520L, 32, 2, 1661243520L },
                    { 33, 1661243520L, 33, 5, 1661243520L },
                    { 34, 1661243520L, 34, 2, 1661243520L },
                    { 35, 1661243520L, 35, 3, 1661243520L },
                    { 36, 1661243520L, 36, 3, 1661243520L },
                    { 37, 1661243520L, 37, 2, 1661243520L },
                    { 38, 1661243520L, 38, 3, 1661243520L },
                    { 39, 1661243520L, 39, 1, 1661243520L },
                    { 40, 1661243520L, 40, 8, 1661243520L },
                    { 41, 1661243520L, 41, 3, 1661243520L },
                    { 42, 1661243520L, 42, 2, 1661243520L },
                    { 43, 1661243520L, 43, 5, 1661243520L },
                    { 44, 1661243520L, 44, 9, 1661243520L },
                    { 45, 1661243520L, 45, 3, 1661243520L }
                });

            migrationBuilder.InsertData(
                table: "PostHasTag",
                columns: new[] { "PostId", "TagId", "Created", "Updated" },
                values: new object[,]
                {
                    { 1, 1, 0L, 0L },
                    { 1, 2, 0L, 0L },
                    { 2, 3, 0L, 0L },
                    { 2, 4, 0L, 0L },
                    { 3, 1, 0L, 0L },
                    { 3, 5, 0L, 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentCodeId",
                table: "Departments",
                column: "DepartmentCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHasTag_TagId",
                table: "PostHasTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCodes_UserId",
                table: "UserCodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikeComment_CommentId",
                table: "UserDislikeComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikePost_PostId",
                table: "UserDislikePost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikeComment_CommentId",
                table: "UserLikeComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikePost_PostId",
                table: "UserLikePost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyId",
                table: "Users",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityId",
                table: "Users",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "PostHasTag");

            migrationBuilder.DropTable(
                name: "UserCodes");

            migrationBuilder.DropTable(
                name: "UserDislikeComment");

            migrationBuilder.DropTable(
                name: "UserDislikePost");

            migrationBuilder.DropTable(
                name: "UserLikeComment");

            migrationBuilder.DropTable(
                name: "UserLikePost");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "DepartmentCodes");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
