using Home.Application.Response;
using MediatR;
using PostIQ.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Application.Queries
{
    public record GetLastJobQuery : IRequest<SingleResponse<LastBatchJobResponse>>
    {
    }
}
