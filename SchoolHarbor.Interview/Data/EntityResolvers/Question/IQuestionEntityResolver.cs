using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Data.EntityResolvers.Question;

public interface IQuestionEntityResolver
{
    public Task<IEnumerable<QuestionEntity>> GetForSurveyInstance(int instanceId);
}