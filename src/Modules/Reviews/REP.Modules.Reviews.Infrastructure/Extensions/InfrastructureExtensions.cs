using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REP.Modules.Reviews.Application;
using REP.Modules.Reviews.Infrastructure.Persistence;
using REP.Modules.Reviews.Infrastructure.Persistence.Repositories;

namespace REP.Modules.Reviews.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddReviewsInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // Example of using the configuration
        var connectionString = config["Modules:Reviews:Database:ConnectionString"];
        services.AddDbContext<ReviewsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IReviewsRepository, ReviewsRepository>();

        return services;
    }
}