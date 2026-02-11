using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PostIQ.Core.BackgroundProcess.Configuration;
using PostIQ.Core.BackgroundProcess.Interfaces;
using PostIQ.Core.BackgroundProcess.Services;
using Published.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Published.Infrastructure.Jobs.RepoJobs
{
    public class RepoHostedJobService : BaseBackgroundJobHostedService<Job>
    {
        public new const string JobName = "RepoJob";
        public RepoHostedJobService(
            IOptions<BackgroundJobsConfiguration> configuration, 
            ILogger<RepoHostedJobService> logger, 
            IJobItemsProducer<Job> producer, 
            IJobItemProcessor<Job> processor, 
            IBackgroundJobRegistry registry) : 
            base(JobName, configuration, logger, producer, processor, registry)
        {
        }
    }
}
