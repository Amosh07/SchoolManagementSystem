using SMS.Application.Common.Service;

namespace SMS.Infrastructure.Persistence.Seed
{
    public interface IDbInitilizer : IScopeService
    {
        Task InitializeIdentityData(CancellationToken cancellationToken = default);

    }
}
