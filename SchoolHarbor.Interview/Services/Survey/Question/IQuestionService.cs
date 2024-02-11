using SchoolHarbor.Interview.Core.Identifier;

namespace SchoolHarbor.Interview.Services.Survey.Question;

public interface IQuestionService
{
    public Task<IEnumerable<Question>> GetForSurvey(IReferenceId surveyId);
}