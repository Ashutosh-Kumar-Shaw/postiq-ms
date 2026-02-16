using AutoMapper;
using Home.Application.Queries;
using Home.Application.Response;
using Home.Core.Entities;
using MediatR;
using PostIQ.Core.Database;
using PostIQ.Core.Response;
using PostIQ.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Home.Application.Handlers
{
    public class GetLastJobHandler : IRequestHandler<GetLastJobQuery, SingleResponse<LastBatchJobResponse>>
    {
        private readonly IRepositoryAsync<BatchJobStatus> _batchJob;
        private readonly IMapper _mapper;

        public GetLastJobHandler(IUnitOfWork<HomeDbContext> uow, IMapper mapper)
        {
            _batchJob = uow.GetRepositoryAsync<BatchJobStatus>();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SingleResponse<LastBatchJobResponse>> Handle(GetLastJobQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //we are handling two state Succeed or Failed
                var response = new SingleResponse<LastBatchJobResponse>(new LastBatchJobResponse
                {
                    LastId = 0,
                    StatusId = 0
                });

                // failed job
                var failedJob = await _batchJob.SingleOrDefaultAsync(x => x.Status != StatusEnum.Succeeded.ToString());
                if (failedJob is not null)
                {
                    response.Data = new LastBatchJobResponse
                    {
                        LastId = failedJob.LastId,
                        StatusId = failedJob.StatusId
                    };
                    return response;
                }

                // Succeed job
                var latest = await _batchJob.SingleOrDefaultAsync(orderBy: o => o.OrderByDescending(x => x.StatusId));
                if (latest is not null)
                {
                    response.Data = new LastBatchJobResponse
                    {
                        LastId = latest.LastId,
                        StatusId = latest.StatusId
                    };
                }
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
            
    }
}
