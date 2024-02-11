using SchoolHarbor.Interview.Core.Identifier;
using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Services.Survey.Question;

public static class Extensions
{
    public static IEnumerable<Question> ToDomain(
        this IEnumerable<QuestionEntity> questionEntities,
        IReferenceId instanceDbId,
        DateTime instanceStartDate,
        DateTime instanceEndDate)
    {
        var result = new List<Question>();
        
        foreach (var questionEntity in questionEntities)
        {
            result.Add(questionEntity.ToDomain(
                instanceDbId,
                instanceStartDate,
                instanceEndDate));
        }

        return result;
    }

    public static Question ToDomain(
        this QuestionEntity questionEntity,
        IReferenceId instanceDbId,
        DateTime instanceStartDate,
        DateTime instanceEndDate)
    {
        if (instanceDbId.SourceKind == ReferenceIdSourceKind.SchoolHarbor && 
            instanceDbId.Kind == ReferenceIdKind.Database)
        {
            return new Question(
                instanceDbId,
                instanceStartDate,
                instanceEndDate,
                questionEntity.ToDbReferenceId(),
                questionEntity.Name,
                questionEntity.Text,
                questionEntity.Kind);
        }

        throw new InvalidDataException("InstanceId for question needs to come from school harbor database");
    }

    public static ReferenceId ToDbReferenceId(this QuestionEntity entity)
    {
        return new ReferenceId(
            ReferenceIdKind.Database,
            ReferenceIdSourceKind.SchoolHarbor,
            entity.Id.ToString());
    }
    
    public static ReferenceId ToDbReferenceId(this InstanceEntity entity)
    {
        return new ReferenceId(
            ReferenceIdKind.Database,
            ReferenceIdSourceKind.SchoolHarbor,
            entity.Id.ToString());
    }
}