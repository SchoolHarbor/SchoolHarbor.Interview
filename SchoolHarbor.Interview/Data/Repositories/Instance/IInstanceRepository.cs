using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Data.Repositories.Instance;

public interface IInstanceRepository
{
    public Task<IEnumerable<InstanceEntity>> GetAll();

    public Task<InstanceEntity> Get(int id);
    
    public Task<IEnumerable<InstanceEntity>> GetForSurvey(int surveyId);

    public Task Add(InstanceEntity entity);

    public Task Delete(int id);
}