using System.Data;
using SchoolHarbor.Interview.Data.Repositories.Survey;

namespace SchoolHarbor.Interview.Services.Survey;

public sealed class SurveyService : ISurveyService
{
    private readonly ISurveyRepository _surveyRepository;

    public SurveyService(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public async Task<IEnumerable<Survey>> GetAll()
    {
        var result = await _surveyRepository.GetAll();

        if (result.Any())
        {
            return result.ToDomain();
        }

        throw new DataException("No survey data found.");
    }
}