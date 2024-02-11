using SchoolHarbor.Interview.Data.Entities;
using SchoolHarbor.Interview.Data.EntityResolvers.Question;
using SchoolHarbor.Interview.Data.Repositories.InstanceQuestionAssociation;
using SchoolHarbor.Interview.Data.Repositories.Question;

namespace SchoolHarbor.Interview.Data.EntityResolvers.Question;

public sealed class QuestionEntityResolver : IQuestionEntityResolver
{
    private readonly IInstanceQuestionAssociationRepository _instanceQuestionAssociationRepository;
    private readonly IQuestionRepository _questionRepository;

    public QuestionEntityResolver(
        IInstanceQuestionAssociationRepository instanceQuestionAssociationRepository,
        IQuestionRepository questionRepository)
    {
        _instanceQuestionAssociationRepository = instanceQuestionAssociationRepository;
        _questionRepository = questionRepository;
    }
    public async Task<IEnumerable<QuestionEntity>> GetForSurveyInstance(int instanceId)
    {
        var instanceQuestionAssociations = await _instanceQuestionAssociationRepository.GetForInstance(instanceId);
        return await ResolveInternal(instanceQuestionAssociations);
    }

    private async Task<IEnumerable<QuestionEntity>> ResolveInternal(
        IEnumerable<InstanceQuestionAssociationEntity> instanceQuestionAssociationEntities)
    {
        var tasks = new List<Task<QuestionEntity>>();
        
        var semaphore = new SemaphoreSlim(10, 10);
        
        foreach (var instanceQuestionAssociationEntity in instanceQuestionAssociationEntities)
        {
            tasks.Add(ResolveLocal(instanceQuestionAssociationEntity));
        }

        return await Task.WhenAll(tasks);

        async Task<QuestionEntity> ResolveLocal(InstanceQuestionAssociationEntity entity)
        {
            try
            {
                await semaphore.WaitAsync();
                return await _questionRepository.Get(entity.QuestionId);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}