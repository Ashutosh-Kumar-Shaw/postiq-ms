using MediatR;
using PostIQ.Core.Response;
using Published.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Published.Application.Queries
{
    public record GetBatchRepoDetailsQuery : IRequest<ListResponse<BatchRepoDetailsRes>>
    {
        public long AfterId { get; init; }
        public int BatchSize { get; init; }
    }
}
