using PostIQ.Core.BackgroundProcess.Interfaces;
using Published.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Published.Infrastructure.Services.RepoJobs
{
    public class RepoJobProcessor : IJobItemProcessor<Job>
    {
        public async Task ProcessItemAsync(Job item, CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(200), cancellationToken);
        }
    }
}
