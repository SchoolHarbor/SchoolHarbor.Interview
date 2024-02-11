using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Data.Repositories.Survey;

public interface ISurveyRepository
{
    public Task<IEnumerable<SurveyEntity>> GetAll();

    public Task<SurveyEntity> Get(int id);

    public Task<SurveyEntity> Get(string name);

    public Task Add(SurveyEntity surveyEntity);

    public Task Delete(int id);
}