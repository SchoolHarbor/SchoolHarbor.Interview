using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Data.Repositories.Instance;

public class InstanceRepository : IInstanceRepository
{
    private readonly ConnectionStringConfig _connectionStringConfig;

    public InstanceRepository(ConnectionStringConfig connectionStringConfig)
    {
        _connectionStringConfig = connectionStringConfig;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }
    
    public Task<IEnumerable<InstanceEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<InstanceEntity> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<InstanceEntity>> GetForSurvey(int surveyId)
    {
        throw new NotImplementedException();
    }

    public Task Add(InstanceEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}