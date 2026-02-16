using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PostIQ.Core.Database;
using PostIQ.Core.Response;
using Published.Application.Queries;
using Published.Application.Response;
using Published.Core.Entities;
using Published.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Published.Application.Handlers
{
    public class GetBatchRepoDetailsHandler : IRequestHandler<GetBatchRepoDetailsQuery, ListResponse<BatchRepoDetailsRes>>
    {
        private readonly IRepositoryAsync<RepoDetail> _repoDetails;
        private readonly IMapper _mapper;

        public GetBatchRepoDetailsHandler(IUnitOfWork<PublishDbContext> uow, IMapper mapper)
        {
            _repoDetails = uow.GetRepositoryAsync<RepoDetail>();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ListResponse<BatchRepoDetailsRes>> Handle(GetBatchRepoDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repoDetails.GetListAsync(x => x.RepoDetailsId > request.AfterId,
                                                        orderBy: o => o.OrderBy(x => x.RepoDetailsId),
                                                        include: i => i.Include(r => r.Repo).ThenInclude(j => j.Job),
                                                        index: -1, size: request.BatchSize);
            var response = _mapper.Map<ListResponse<BatchRepoDetailsRes>>(result);
            return response;
        }
    }
}
