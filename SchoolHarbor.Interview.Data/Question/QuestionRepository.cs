using System.Data.SqlClient;
using Dapper;

namespace SchoolHarbor.Interview.Data.Question;

public class QuestionRepository : IQuestionRepository
{
    private readonly ConnectionStringConfig _connectionStringConfig;

    public QuestionRepository(ConnectionStringConfig connectionStringConfig)
    {
        _connectionStringConfig = connectionStringConfig;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<IEnumerable<QuestionEntity>> GetAll()
    {
        var sql = @"
SELECT * 
FROM diagnostic.[question]";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<QuestionEntity>(sql);
        }
    }

    public async Task<QuestionEntity> Get(int id)
    {
        var sql = @"
SELECT * 
FROM diagnostic.[question] 
WHERE id = @id";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<QuestionEntity>(sql, new { Id = id });
        }
    }

    public async Task<QuestionEntity> Get(string name)
    {
        var sql = @"
SELECT * 
FROM diagnostic.[question] 
WHERE Name = @name";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<QuestionEntity>(sql, new { Name = name });
        }
    }

    public async Task Add(QuestionEntity questionEntity)
    {
        var sql = @"
INSERT INTO diagnostic.[question] (
    name,
    text,
    kind,
    created_on, 
    created_by,
    updated_on,
    updated_by)
VALUES (
    @Name,
    @Text,
    @Kind,
    @CreatedOn,
    @CreatedBy,
    @UpdatedOn,
    @UpdatedBy)";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            await connection.ExecuteAsync(sql, questionEntity);
        }
    }

    public async Task Delete(int id)
    {
        var sql = @"
DELETE 
FROM diagnostic.[question] 
WHERE id = @id";

        using (var connection = new SqlConnection(_connectionStringConfig.ConnectionString))
        {
            await connection.OpenAsync();
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}