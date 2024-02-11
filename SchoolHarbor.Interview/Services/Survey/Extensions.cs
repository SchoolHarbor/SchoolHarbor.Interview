using SchoolHarbor.Interview.Core.Identifier;
using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Services.Survey;

public static class Extensions
{
    public static IEnumerable<Survey> ToDomain(this IEnumerable<SurveyEntity> entities)
    {
        var result = new List<Survey>();

        foreach (var surveyEntity in entities)
        {
            result.Add(surveyEntity.ToDomain());
        }

        return result;
    }

    public static Survey ToDomain(this SurveyEntity entity)
    {
        if (entity.Id <= 0)
        {
            throw new InvalidDataException("Entity does not have a valid id");
        }

        if (string.IsNullOrWhiteSpace(entity.Name))
        {
            throw new InvalidDataException("Entity does not have a name");
        }
        
        return new Survey(
            new ReferenceId(ReferenceIdKind.Database, ReferenceIdSourceKind.SchoolHarbor, entity.Id.ToString()),
            entity.Name);
    }
}