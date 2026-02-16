using AutoMapper;
using Published.Application.Response;
using Published.Core.Entities;

namespace Published.Application.Mappers
{
    public class RepoDetailsMapper : Profile
    {
        public RepoDetailsMapper()
        {
            CreateMap<RepoDetail, BatchRepoDetailsRes>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Repo != null ? src.Repo.Job.UserId : 0L))
                .ForMember(dest => dest.RepoDetailsId, opt => opt.MapFrom(src => src.RepoDetailsId))
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Repo != null ? src.Repo.Source : null))
                .ForMember(dest => dest.RepoUrl, opt => opt.MapFrom(src => src.Repo != null ? src.Repo.RepoUrl : null))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Ordered, opt => opt.MapFrom(src => src.Ordered))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.PostedOn, opt => opt.MapFrom(src => src.Repo != null ? src.Repo.PostedOn : src.CreatedOn));
        }
    }
}
