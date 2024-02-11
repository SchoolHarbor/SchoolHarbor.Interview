using System.Data.SqlClient;
using Dapper;
using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Data.Repositories.Survey;

public class SurveyRepository : ISurveyRepository
{
    private readonly ConnectionStringConfig _connectionStringConfig;

    public SurveyRepository(ConnectionStringConfig connectionStringConfig)
    {
        _connectionStringConfig = connectionStringConfig;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<IEnumerable<SurveyEntity>> GetAll()
    {
        var sql = @"
SELECT * 
FROM diagnostic.[survey]";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<SurveyEntity>(sql);
        }
    }

    public async Task<SurveyEntity> Get(int id)
    {
        var sql = @"
SELECT * 
FROM diagnostic.[survey] 
WHERE id = @id";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<SurveyEntity>(sql, new { Id = id });
        }
    }

    public async Task<SurveyEntity> Get(string name)
    {
        var sql = @"
SELECT * FROM diagnostic.[survey] 
WHERE Name = @name";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<SurveyEntity>(sql, new { Name = name });
        }
    }

    public async Task Add(SurveyEntity surveyEntity)
    {
        var sql = @"
INSERT INTO diagnostic.[survey] (
    name,
    created_on, 
    created_by,
    updated_on,
    updated_by)
VALUES (
    @Name,
    @CreatedOn,
    @CreatedBy,
    @UpdatedOn,
    @UpdatedBy)";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            await connection.ExecuteAsync(sql, surveyEntity);
        }
    }

    public async Task Delete(int id)
    {
        var sql = @"
DELETE 
FROM diagnostic.[survey] 
WHERE id = @id";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
