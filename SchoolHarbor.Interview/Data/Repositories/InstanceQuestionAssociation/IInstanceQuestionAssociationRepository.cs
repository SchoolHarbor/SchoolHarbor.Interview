using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Data.Repositories.InstanceQuestionAssociation;

public interface IInstanceQuestionAssociationRepository
{
    public Task<IEnumerable<InstanceQuestionAssociationEntity>> GetAll();

    public Task<InstanceQuestionAssociationEntity> Get(int id);

    public Task<IEnumerable<InstanceQuestionAssociationEntity>> GetForInstance(int instanceId);

    public Task Add(InstanceQuestionAssociationEntity entity);

    public Task Delete(int id);
}