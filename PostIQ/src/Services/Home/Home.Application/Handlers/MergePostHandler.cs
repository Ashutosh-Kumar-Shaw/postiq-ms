using AutoMapper;
using Home.Application.Commands;
using Home.Core.Entities;
using MediatR;
using PostIQ.Core.Database;
using PostIQ.Core.Response;

namespace Home.Application.Handlers
{
    public class MergePostHandler : IRequestHandler<MergePostCommand, SingleResponse<bool>>
    {
        private readonly IRepositoryAsync<Post> _postAsync;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<HomeDbContext> _uow;

        public MergePostHandler(IUnitOfWork<HomeDbContext> uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _postAsync = _uow.GetRepositoryAsync<Post>();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SingleResponse<bool>> Handle(MergePostCommand request, CancellationToken cancellationToken)
        {            
            var response = new SingleResponse<bool>(false);
            if (request.Models.Any())
            {
                var entity = _mapper.Map<List<Post>>(request.Models);
                var repoDetailIds = entity.Select(x => x.RepoDetailsId).Distinct();
                var posts = await _postAsync.GetListAsync(x => repoDetailIds.Contains(x.RepoDetailsId), index: -1, size: -1);
                if (posts.Count > 0)
                {
                    posts.Data.ToList().ForEach(x => { x.IsActive = false; x.UpdatedOn = DateTime.UtcNow; x.UpdatedBy = x.CreatedBy; });
                    _uow.GetRepository<Post>().Update(posts.Data);
                    var saved = await _uow.CommitAsync().ConfigureAwait(false);
                    response.Data = saved > 0;
                }
                await _postAsync.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
                await _uow.CommitAsync();
            }
            return response;
        }
    }
}
