using PostIQ.Core.BackgroundProcess.Interfaces;
using Published.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Published.Infrastructure.Jobs.RepoJobs
{
    public class RepoJobProcessor : IJobItemProcessor<Job>
    {
        public async Task ProcessItemAsync(Job item, CancellationToken cancellationToken = default)
        {
            //do your work
            //call the medium service
            //insert or update repo table
            //update next execution time of job table

            await Task.Delay(TimeSpan.FromMilliseconds(200), cancellationToken);
        }
    }
}
