using AutoMapper;
using Entity.Concrete;
using Entity.Dtos;

namespace Entity.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserDto>()
                .ForMember(pts => pts.University , opt => opt.MapFrom(ps => ps.University.Name))
                .ForMember(pts => pts.Faculty , opt => opt.MapFrom(ps => ps.Faculty.Name))
                .ForMember(pts => pts.Department , opt => opt.MapFrom(ps => ps.Department.DepartmentCode.Name));
            CreateMap<UserForUpdateDto, User>();


            CreateMap<University, UniversityDto>();
            CreateMap<UniversityForUpdateDto, University>();

            CreateMap<Faculty, FacultyDto>();
            CreateMap<FacultyForUpdateDto, Faculty>();

            CreateMap<Department, DepartmentDto>()
                .ForMember(pts => pts.Name, opt => opt.MapFrom(ps => ps.DepartmentCode.Name));
            CreateMap<DepartmentForUpdateDto, Department>();


            CreateMap<DepartmentCode, DepartmentCodeDto>();
            CreateMap<DepartmentCodeForUpdateDto, DepartmentCode>();

            CreateMap<Tag, TagDto>();
            CreateMap<TagForUpdateDto, Tag>();

            CreateMap<Post, PostDto>()
                .ForMember(pts => pts.Like , opt => opt.MapFrom(ps => ps.Likes.Count))
                .ForMember(pts => pts.Dislike , opt => opt.MapFrom(ps => ps.Dislikes.Count))
                .ForMember(pts => pts.TagId , opt => opt.MapFrom(ps => ps.Tags.Select(x => x.TagId).ToList()))
                .ForMember(pts => pts.Tags , opt => opt.MapFrom(ps => ps.Tags.Select(x => x.Tag.Name).ToList()))
                .ForMember(pts => pts.AuthorUniversity , opt => opt.MapFrom(ps => ps.Author.University.Name))
                .ForMember(pts => pts.AuthorFaculty , opt => opt.MapFrom(ps => ps.Author.Faculty.Name))
                .ForMember(pts => pts.AuthorDeparment , opt => opt.MapFrom(ps => ps.Author.Department.DepartmentCode.Name))
                .ForMember(pts => pts.Username , opt => opt.MapFrom(ps => ps.Author.Username));
            CreateMap<PostForUpdateDto, Post>();

            CreateMap<Comment, CommentDto>()
                .ForMember(pts => pts.Like , opt => opt.MapFrom(ps => ps.Likes.Count))
                .ForMember(pts => pts.Dislike , opt => opt.MapFrom(ps => ps.Dislikes.Count))
                .ForMember(pts => pts.Username , opt => opt.MapFrom(ps => ps.Author.Username));
            CreateMap<CommentForUpdateDto, Comment>();

        }
    }
}