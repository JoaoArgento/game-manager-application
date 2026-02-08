using System.Data.Common;
using System.Data;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Respawn.Graph;
using Respawn;

namespace Tests.Integration.Infrastructure;

public interface IDatabaseResetService
{
    public Task ResetAsync(CancellationToken cancellationToken = default); 
}

public class DatabaseResetService : IDatabaseResetService
{
    private readonly DbConnection dbConnection;
    private Respawner dbRespawner;
    public DatabaseResetService(PostgresContext postgresContext)
    {
        dbConnection = postgresContext.Database.GetDbConnection();
        
    }
    public async Task ResetAsync(CancellationToken cancellationToken = default)
    {
        if (dbConnection.State != ConnectionState.Open)
        {
            await dbConnection.OpenAsync(cancellationToken);
        }
        
        dbRespawner ??= await Respawner.CreateAsync(dbConnection, new RespawnerOptions
        {
            DbAdapter = DbAdapter.Postgres,
            SchemasToInclude = ["public"],
            TablesToIgnore = [new Table("__EFMigrationsHistory")]
        });

        await dbRespawner.ResetAsync(dbConnection);
    }
}