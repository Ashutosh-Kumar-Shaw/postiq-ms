using Home.Application.Response;
using PostIQ.Core.BackgroundProcess.Interfaces;


namespace Home.Infrastructure.Jobs.PostSyncJob
{
    public class PostSyncJobProcessor : IJobItemProcessor<LastBatchJobResponse>
    {
        public async Task ProcessItemAsync(LastBatchJobResponse item, CancellationToken cancellationToken = default)
        {
            //do your work
            //call the medium service
            //insert or update repo table
            //update next execution time of job table

            await Task.Delay(TimeSpan.FromMilliseconds(200), cancellationToken);
        }
    }
}
