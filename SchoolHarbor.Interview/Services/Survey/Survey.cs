using SchoolHarbor.Interview.Core.Identifier;

namespace SchoolHarbor.Interview.Services.Survey;

public sealed class Survey
{
    public Survey(
        IReferenceId id,
        string name)
    {
        Id = id;
        Name = name;
    }
    
    public IReferenceId Id { get; }
    
    public string Name { get; }
}