using Home.Application.Queries;
using Home.Application.Response;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PostIQ.Core.BackgroundProcess.Example;
using PostIQ.Core.BackgroundProcess.Interfaces;
using PostIQ.Core.Database;
using PostIQ.Core.HttpClientService.Services;

namespace Home.Infrastructure.Jobs.PostSyncJob
{
    public class PostSyncJobProducer : IJobItemsProducer<LastBatchJobResponse>
    {
        private readonly ILogger<ExampleJobProducer> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IBaseHttpClientService _clientService;

        public PostSyncJobProducer(ILogger<ExampleJobProducer> logger, IServiceProvider serviceProvider, IBaseHttpClientService clientService)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _clientService = clientService;
        }
        public async Task<IReadOnlyList<LastBatchJobResponse>> GetItemsToProcessAsync(int maxItems, CancellationToken cancellationToken = default)
        {
            using var scope = _serviceProvider.CreateScope();
            var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var job = await _mediator.Send(new GetLastJobQuery(), cancellationToken);
            //var response = await _clientService.GetAsync<SingleResponse<LastBatchJobResponse>>("https://localhost:5001/api/v1/home/last-job", cancellationToken);
            return job.Data != null ? new List<LastBatchJobResponse> { job.Data } : new List<LastBatchJobResponse>();
        }
    }
}
