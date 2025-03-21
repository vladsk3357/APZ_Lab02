using Bnn.Data.Database;
using Bnn.Data.Entities;
using Dapper;
using LazyCache;

namespace Bnn.Data.Repositories;

public class BananasRepository(IDbConnectionFactory connectionFactory, IAppCache cache) : IBananasRepository
{
    public async Task<IEnumerable<Banana>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        const string sql = "SELECT * FROM Bananas";
        var command = new CommandDefinition(sql, null, cancellationToken: cancellationToken);
        return await connection.QueryAsync<Banana>(command);
    }

    public async Task<Banana?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        const string sql = "SELECT * FROM Bananas WHERE Id = @Id";
        var command = new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken);
        return await connection.QuerySingleOrDefaultAsync<Banana>(sql, command);
    }

    public async Task<int> CreateAsync(Banana banana, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(banana);
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        const string sql = "INSERT INTO Bananas (Name, Weight) VALUES (@Name, @Weight) RETURNING Id";
        var command = new CommandDefinition(sql, banana, cancellationToken: cancellationToken);
        var result = await connection.ExecuteScalarAsync(command);
        return (int)result!;
    }

    public async Task<bool> UpdateAsync(Banana banana, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(banana);
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        const string sql = "UPDATE Bananas SET Name = @Name, Weight = @Weight WHERE Id = @Id";
        var command = new CommandDefinition(sql, banana, cancellationToken: cancellationToken);
        var result = await connection.ExecuteAsync(command);
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        const string sql = "DELETE FROM Bananas WHERE Id = @Id";
        var command = new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken);
        var result = await connection.ExecuteAsync(command);
        return result > 0;
    }
}