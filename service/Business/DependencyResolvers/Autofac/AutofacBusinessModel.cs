using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Mail.Abstract;
using Core.Utilities.Mail.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // University
            builder.RegisterType<UniversityManager>().As<IUniversityService>();
            builder.RegisterType<EfUniversityDal>().As<IUniversityDal>();

            // Department
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>();

            // Faculty
            builder.RegisterType<FacultyManager>().As<IFacultyService>();
            builder.RegisterType<EfFacultyDal>().As<IFacultyDal>();

            // DepartmentCode
            builder.RegisterType<DepartmentCodeManager>().As<IDepartmentCodeService>();
            builder.RegisterType<EfDepartmentCodeDal>().As<IDepartmentCodeDal>();

            // Post
            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();

            // Comment
            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            // Tag
            builder.RegisterType<TagManager>().As<ITagService>();
            builder.RegisterType<EfTagDal>().As<ITagDal>();

            // Post Has Tag
            builder.RegisterType<EfPostHasTagDal>().As<IPostHasTagDal>();

            // User like post
            builder.RegisterType<EfUserLikePostDal>().As<IUserLikePostDal>();

            // User dislike post
            builder.RegisterType<EfUserDislikePostDal>().As<IUserDislikePostDal>();

            // User like comment
            builder.RegisterType<EfUserLikeCommentDal>().As<IUserLikeCommentDal>();

            // User dislike comment
            builder.RegisterType<EfUserDislikeCommentDal>().As<IUserDislikeCommentDal>();

            // User
            builder.RegisterType<AuthUserManager>().As<IAuthUserService>();

            // User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            // User code
            builder.RegisterType<EfUserCodeDal>().As<IUserCodeDal>();

            // Claim
            builder.RegisterType<EfClaimDal>().As<IClaimDal>();

            // Auth
            builder.RegisterType<AuthManager>().As<IAuthService>();

            // Jwt
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            // Mail
            builder.RegisterType<MailManager>().As<IMailService>();
        }
    }
}
