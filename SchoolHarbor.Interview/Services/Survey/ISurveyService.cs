namespace SchoolHarbor.Interview.Services.Survey;

public interface ISurveyService
{
    public Task<IEnumerable<Survey>> GetAll();
}