using System.Collections.Immutable;
using SchoolHarbor.Interview.Core.Identifier;
using SchoolHarbor.Interview.Data.Entities;
using SchoolHarbor.Interview.Data.EntityResolvers.Question;
using SchoolHarbor.Interview.Data.Repositories.Instance;

namespace SchoolHarbor.Interview.Services.Survey.Question;

public sealed class QuestionService : IQuestionService
{
    private readonly IQuestionEntityResolver _questionEntityResolver;
    private readonly IInstanceRepository _instanceRepository;

    public QuestionService(
        IQuestionEntityResolver questionEntityResolver,
        IInstanceRepository instanceRepository)
    {
        _questionEntityResolver = questionEntityResolver;
        _instanceRepository = instanceRepository;
    }
    
    public async Task<IEnumerable<Question>> GetForSurvey(IReferenceId surveyId)
    {
        if (surveyId.SourceKind == ReferenceIdSourceKind.SchoolHarbor)
        {
            var instances = (await _instanceRepository
                .GetForSurvey(int.Parse(surveyId.Value)))
                .ToImmutableArray();

            if (instances.Any())
            {
                return await ResolveQuestionsInternal(instances);
            }
        }

        throw new InvalidDataException("Survey Id must be source of school harbor database");
    }

    private async Task<IEnumerable<Question>> ResolveQuestionsInternal(IEnumerable<InstanceEntity> instances)
    {
        var result = new List<Question>();
        
        foreach (var instanceEntity in instances)
        {
            var questionEntities = await _questionEntityResolver
                .GetForSurveyInstance(instanceEntity.Id);

            result.AddRange(questionEntities.ToDomain(
                instanceEntity.ToDbReferenceId(),
                instanceEntity.StartDate,
                instanceEntity.EndDate));
        }

        return result;
    }
}