using Npgsql;

namespace TCB.G1Group.DataService;

public class DataProvider
{
    private readonly string _connectionString;

    public DataProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<NpgsqlConnection> CreateNewConnection()
    {
        return new NpgsqlConnection(this._connectionString);
    }

    public async Task<NpgsqlDataReader>ExecuteWithResult(string query, NpgsqlParameter[]? parameters)
    {
        var connection = await this.CreateNewConnection();
        await connection.OpenAsync();

        var command = new NpgsqlCommand(query, connection);
        if (parameters is not null)
            command.Parameters.AddRange(parameters);

        var reader = await command.ExecuteReaderAsync();

        return reader;
    }
    
    public async Task<int> ExecuteNonResult(string query, NpgsqlParameter[]? parameters)
    {
        var connection =await this.CreateNewConnection();
        await connection.OpenAsync();

        var command = new NpgsqlCommand(query, connection);
        if (parameters is not null)
            command.Parameters.AddRange(parameters);

        var result = await command.ExecuteNonQueryAsync();

        return result;
    }
}