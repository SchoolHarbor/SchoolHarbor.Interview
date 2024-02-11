namespace SchoolHarbor.Interview.Data.Question;

public interface IQuestionRepository
{
    public Task<IEnumerable<QuestionEntity>> GetAll();

    public Task<QuestionEntity> Get(int id);

    public Task Add(QuestionEntity questionEntity);

    public Task Delete(int id);
}