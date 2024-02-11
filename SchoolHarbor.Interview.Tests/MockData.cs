using SchoolHarbor.Interview.Core.Identifier;
using SchoolHarbor.Interview.Data.Entities;

namespace SchoolHarbor.Interview.Tests;

public static class MockData
{
    public static ReferenceId MockDataReferenceId()
    {
        return new ReferenceId(
            ReferenceIdKind.Database,
            ReferenceIdSourceKind.SchoolHarbor,
            Guid.NewGuid().ToString());
    }
    public static ReferenceId MockDataReferenceId(string value)
    {
        return new ReferenceId(
            ReferenceIdKind.Database,
            ReferenceIdSourceKind.SchoolHarbor,
            value);
    }

    public static SurveyEntity MockSurveyEntity(int? id = null)
    {
        return new SurveyEntity()
        {
            Id = id ?? new Random().Next(1, 9999),
            Name =Guid.NewGuid().ToString(),
            CreatedOn = DateTime.Today,
            CreatedBy = Guid.NewGuid().ToString(),
            UpdatedOn = DateTime.Today,
            UpdatedBy = Guid.NewGuid().ToString()
        };
    }
    
    public static SurveyEntity MockInvalidSurveyEntityWithoutName()
    {
        return new SurveyEntity()
        {
            Id = new Random().Next(1, 9999),
            CreatedOn = DateTime.Today,
            CreatedBy = Guid.NewGuid().ToString(),
            UpdatedOn = DateTime.Today,
            UpdatedBy = Guid.NewGuid().ToString()
        };
    }
}