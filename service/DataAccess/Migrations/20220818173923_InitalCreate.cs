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
                values: new object[] { 1, 0L, null, "berkslv@gmail.com", null, "Berk Selvi", new byte[] { 17, 246, 222, 19, 201, 129, 90, 142, 254, 110, 223, 243, 163, 127, 145, 171, 24, 52, 116, 93, 60, 199, 19, 36, 167, 163, 9, 131, 170, 184, 63, 151, 146, 174, 51, 234, 1, 96, 237, 138, 27, 12, 146, 96, 160, 190, 159, 78, 15, 250, 220, 115, 45, 162, 237, 73, 212, 108, 28, 168, 14, 119, 28, 161 }, new byte[] { 229, 151, 213, 208, 78, 84, 74, 6, 226, 61, 79, 120, 79, 110, 47, 42, 123, 25, 218, 121, 163, 173, 212, 203, 117, 65, 163, 145, 24, 9, 39, 124, 0, 209, 100, 26, 12, 235, 236, 50, 209, 144, 134, 19, 197, 26, 79, 254, 138, 221, 90, 27, 136, 107, 145, 48, 73, 247, 184, 166, 217, 130, 38, 48, 41, 95, 196, 110, 49, 236, 120, 29, 112, 110, 189, 19, 129, 79, 190, 215, 98, 36, 50, 251, 236, 252, 8, 143, 97, 175, 66, 154, 132, 27, 202, 117, 222, 125, 94, 191, 220, 61, 254, 186, 193, 58, 109, 24, 250, 164, 87, 207, 149, 200, 57, 137, 91, 153, 250, 37, 22, 23, 161, 77, 11, 52, 122, 77 }, "Admin", true, null, 0L, "berkslv" });

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
