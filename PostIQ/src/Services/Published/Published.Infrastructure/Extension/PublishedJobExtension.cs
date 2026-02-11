using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostIQ.Core.BackgroundProcess;
using PostIQ.Core.BackgroundProcess.Interfaces;
using Published.Core.Entities;
using Published.Infrastructure.Jobs.RepoJobs;

namespace Published.Infrastructure.Extension
{
    public static class PublishedJobExtension
    {
        public static IServiceCollection AddJobExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBackgroundJob(configuration);

            services.AddSingleton<IJobItemProcessor<Job>, RepoJobProcessor>();
            services.AddSingleton<IJobItemsProducer<Job>, RepoJobProducer>();
            services.AddHostedService<RepoHostedJob>();

            return services;
        }
    }
}
