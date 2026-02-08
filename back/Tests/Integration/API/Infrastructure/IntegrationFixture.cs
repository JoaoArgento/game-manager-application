using Xunit;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Tests.Integration.Infrastructure;
public sealed class IntegrationFixture : IAsyncLifetime
{
    public HttpClient Client {get; private set;}
    public APIFactory ApiFactory {get; private set;}

    public async Task ResetDbAsync()
    {
        using var scope = ApiFactory.Services.CreateScope();
        var resetService = scope.ServiceProvider.GetRequiredService<IDatabaseResetService>();
        await resetService.ResetAsync();
    }
    public Task DisposeAsync()
    {
        Client.Dispose();
        ApiFactory.Dispose();
        return Task.CompletedTask;
    }

    public Task InitializeAsync()
    {
        ApiFactory = new APIFactory();
        Client = ApiFactory.CreateClient();
        return Task.CompletedTask;
    }
}