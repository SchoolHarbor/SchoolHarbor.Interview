using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Data.Repositories.Question;

public interface IQuestionRepository
{
    public Task<IEnumerable<QuestionEntity>> GetAll();

    public Task<QuestionEntity> Get(int id);

    public Task Add(QuestionEntity questionEntity);

    public Task Delete(int id);
}