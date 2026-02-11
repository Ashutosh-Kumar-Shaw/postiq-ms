using Microsoft.Extensions.Logging;
using PostIQ.Core.BackgroundProcess.Example;
using PostIQ.Core.BackgroundProcess.Interfaces;
using PostIQ.Core.Database;
using Published.Core.Entities;
using Published.Core.Persistence;

namespace Published.Infrastructure.Jobs.RepoJobs
{
    public class RepoJobProducer : IJobItemsProducer<Job>
    {
        private readonly ILogger<ExampleJobProducer> _logger;

        public RepoJobProducer(ILogger<ExampleJobProducer> logger)
        {
            _logger = logger;
        }
        public Task<IReadOnlyList<Job>> GetItemsToProcessAsync(int maxItems, CancellationToken cancellationToken = default)
        {
            //return list of pending jobs

            return Task.FromResult<IReadOnlyList<Job>>(new List<Job>
            {
                //temporary hardcoded data, replace with actual database call
                //used Job model from db entity, please change as per your actual model in all 3 job files
                new Job
                {
                    JobId = 1,
                    PublishedId = 1,
                    UserId = 1,
                    Source = "GitHub",
                    BaseUrl = "https://api.github.com/repos/owner/repo",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = 1
                },
                new Job
                {
                    JobId = 2,
                    PublishedId = 2,
                    UserId = 2,
                    Source = "GitLab",
                    BaseUrl = "https://gitlab.com/api/v4/projects/owner%2Frepo",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = 2
                }
            });
        }
    }
}
