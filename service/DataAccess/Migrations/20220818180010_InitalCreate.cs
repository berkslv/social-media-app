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
                    { 1, 0L, "Acil Yardım ve Afet Yönetimi", 0L },
                    { 2, 0L, "Alman Dili ve Edebiyatı", 0L },
                    { 3, 0L, "Arkeoloji", 0L },
                    { 4, 0L, "Bahçe Bitkileri", 0L },
                    { 5, 0L, "Beslenme ve Diyetetik", 0L },
                    { 6, 0L, "Bilgisayar Mühendisliği", 0L },
                    { 7, 0L, "Bitki Koruma", 0L },
                    { 8, 0L, "Biyoloji", 0L },
                    { 9, 0L, "Biyomedikal Mühendisliği", 0L },
                    { 10, 0L, "Biyosistem Mühendisliği", 0L },
                    { 11, 0L, "Coğrafya", 0L },
                    { 12, 0L, "Çalışma Ekonomisi ve Endüstri İlişkileri", 0L },
                    { 13, 0L, "Çevre Mühendisliği", 0L },
                    { 14, 0L, "Elektrik-Elektronik Mühendisliği", 0L },
                    { 15, 0L, "Endüstri Mühendisliği", 0L },
                    { 16, 0L, "Fizik", 0L },
                    { 17, 0L, "Fransız Dili ve Edebiyatı", 0L },
                    { 18, 0L, "Gıda Mühendisliği", 0L },
                    { 19, 0L, "Hemşirelik", 0L },
                    { 20, 0L, "Hukuk", 0L },
                    { 21, 0L, "İktisat", 0L },
                    { 22, 0L, "İlahiyat", 0L },
                    { 23, 0L, "İngiliz Dili ve Edebiyatı", 0L },
                    { 24, 0L, "İnşaat Mühendisliği", 0L },
                    { 25, 0L, "İşletme", 0L },
                    { 26, 0L, "Kimya", 0L },
                    { 27, 0L, "Makine Mühendisliği", 0L },
                    { 28, 0L, "Maliye", 0L },
                    { 29, 0L, "Matematik", 0L },
                    { 30, 0L, "Mimarlık", 0L },
                    { 31, 0L, "Peyzaj Mimarlığı", 0L },
                    { 32, 0L, "Psikoloji", 0L },
                    { 33, 0L, "Siyaset Bilimi ve Kamu Yönetimi", 0L },
                    { 34, 0L, "Sosyoloji", 0L },
                    { 35, 0L, "Tarım Ekonomisi", 0L },
                    { 36, 0L, "Tarımsal Biyoteknoloji", 0L },
                    { 37, 0L, "Tarih", 0L },
                    { 38, 0L, "Tarla Bitkileri", 0L },
                    { 39, 0L, "Tekstil Mühendisliği", 0L },
                    { 40, 0L, "Tıp", 0L },
                    { 41, 0L, "Toprak Bilimi ve Bitki Besleme", 0L },
                    { 42, 0L, "Türk Dili ve Edebiyatı", 0L },
                    { 43, 0L, "Uluslararası İlişkiler", 0L },
                    { 44, 0L, "Veterinerlik", 0L },
                    { 45, 0L, "Zootekni", 0L }
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
                    { 1, 0L, "Sadece goygoy. Ciddi olma!", "Goygoy", 0L },
                    { 2, 0L, "Kedini burada paylaşabilirsin.", "Hayvani", 0L },
                    { 3, 0L, "İkinci el ürününü hemen elinden çıkart.", "İkinci el", 0L },
                    { 4, 0L, "Hadi tanışalım.", "Tanışma", 0L },
                    { 5, 0L, "Nerelerde takılıyorsun?", "Mekanlar", 0L }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "City", "Created", "FoundationYear", "Name", "Updated" },
                values: new object[] { 1, "29", 0L, 2000, "Tekirdağ Namık Kemal Üniversitesi", 0L });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "Created", "OperationClaimId", "Updated", "UserId" },
                values: new object[] { 1, 0L, 4, 0L, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "DepartmentId", "Email", "FacultyId", "Name", "PasswordHash", "PasswordSalt", "Role", "Status", "UniversityId", "Updated", "Username" },
                values: new object[] { 1, 0L, null, "berkslv@gmail.com", null, "Berk Selvi", new byte[] { 136, 28, 171, 5, 161, 12, 180, 202, 42, 51, 27, 241, 82, 3, 115, 165, 121, 157, 162, 241, 160, 48, 63, 228, 44, 235, 87, 246, 192, 78, 177, 222, 252, 148, 138, 39, 144, 251, 94, 119, 49, 142, 34, 98, 52, 248, 100, 147, 69, 141, 180, 159, 251, 160, 198, 87, 56, 10, 244, 15, 131, 164, 42, 114 }, new byte[] { 40, 204, 156, 179, 196, 235, 124, 191, 134, 166, 200, 22, 138, 129, 246, 100, 123, 82, 250, 22, 101, 149, 165, 243, 70, 30, 212, 10, 99, 4, 231, 67, 203, 135, 169, 127, 164, 153, 64, 46, 171, 79, 34, 108, 112, 174, 59, 255, 25, 251, 153, 178, 65, 250, 77, 164, 49, 179, 158, 121, 43, 53, 117, 95, 16, 34, 163, 71, 131, 251, 35, 21, 226, 143, 41, 104, 112, 7, 103, 232, 68, 106, 166, 169, 247, 255, 101, 0, 242, 159, 210, 20, 32, 122, 81, 162, 235, 253, 161, 52, 163, 165, 137, 124, 141, 129, 85, 208, 79, 195, 207, 138, 171, 88, 63, 138, 235, 121, 90, 120, 182, 83, 175, 3, 131, 115, 92, 54 }, "Admin", true, null, 0L, "berkslv" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Address", "Altitude", "Created", "Latitude", "Name", "UniversityId", "Updated" },
                values: new object[,]
                {
                    { 1, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Çorlu Mühendislik Fakültesi", 1, 0L },
                    { 2, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Fen-Edebiyat Fakültesi", 1, 0L },
                    { 3, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Ziraat Fakültesi", 1, 0L },
                    { 4, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Hukuk Fakültesi", 1, 0L },
                    { 5, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "İktisadi ve İdari Bilimler Fakültesi", 1, 0L },
                    { 6, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "İlahiyat Fakültesi", 1, 0L },
                    { 7, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Güzel Sanatlar, Tasarım ve Mimarlık Fakültesi", 1, 0L },
                    { 8, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Tıp Fakültesi", 1, 0L },
                    { 9, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Veteriner Fakültesi", 1, 0L },
                    { 10, "Çorlu, silahtarağa mah.", 21.213124000000001, 0L, 43.213411999999998, "Sağlık Yüksekokulu", 1, 0L }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "Created", "Updated" },
                values: new object[,]
                {
                    { 1, 1, "I used to live in my neighbor's fishpond, but the aesthetic wasn't to my taste.", 0L, 0L },
                    { 2, 1, "The waitress was not amused when he ordered green eggs and ham.", 0L, 0L },
                    { 3, 1, "I don’t respect anybody who can’t tell the difference between Pepsi and Coke.", 0L, 0L }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "Created", "PostId", "Updated" },
                values: new object[,]
                {
                    { 1, 1, "Güzel gönderi", 0L, 1, 0L },
                    { 2, 1, "Tanışmak ister misin?", 0L, 1, 0L }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Created", "DepartmentCodeId", "FacultyId", "Updated" },
                values: new object[,]
                {
                    { 1, 0L, 1, 10, 0L },
                    { 2, 0L, 2, 2, 0L },
                    { 3, 0L, 3, 2, 0L },
                    { 4, 0L, 4, 3, 0L },
                    { 5, 0L, 5, 10, 0L },
                    { 6, 0L, 6, 1, 0L },
                    { 7, 0L, 7, 3, 0L },
                    { 8, 0L, 8, 2, 0L },
                    { 9, 0L, 9, 1, 0L },
                    { 10, 0L, 10, 3, 0L },
                    { 11, 0L, 11, 2, 0L },
                    { 12, 0L, 12, 5, 0L },
                    { 13, 0L, 13, 1, 0L },
                    { 14, 0L, 14, 1, 0L },
                    { 15, 0L, 15, 1, 0L },
                    { 16, 0L, 16, 2, 0L },
                    { 17, 0L, 17, 2, 0L },
                    { 18, 0L, 18, 3, 0L },
                    { 19, 0L, 19, 10, 0L },
                    { 20, 0L, 20, 4, 0L },
                    { 21, 0L, 21, 5, 0L },
                    { 22, 0L, 22, 6, 0L },
                    { 23, 0L, 23, 2, 0L },
                    { 24, 0L, 24, 1, 0L },
                    { 25, 0L, 25, 5, 0L },
                    { 26, 0L, 26, 2, 0L },
                    { 27, 0L, 27, 1, 0L },
                    { 28, 0L, 28, 5, 0L },
                    { 29, 0L, 29, 2, 0L },
                    { 30, 0L, 30, 7, 0L },
                    { 31, 0L, 31, 7, 0L },
                    { 32, 0L, 32, 2, 0L },
                    { 33, 0L, 33, 5, 0L },
                    { 34, 0L, 34, 2, 0L },
                    { 35, 0L, 35, 3, 0L },
                    { 36, 0L, 36, 3, 0L },
                    { 37, 0L, 37, 2, 0L },
                    { 38, 0L, 38, 3, 0L },
                    { 39, 0L, 39, 1, 0L },
                    { 40, 0L, 40, 8, 0L },
                    { 41, 0L, 41, 3, 0L },
                    { 42, 0L, 42, 2, 0L },
                    { 43, 0L, 43, 5, 0L },
                    { 44, 0L, 44, 9, 0L },
                    { 45, 0L, 45, 3, 0L }
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
