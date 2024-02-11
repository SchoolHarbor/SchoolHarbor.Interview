using SchoolHarbor.Interview.Core.Identifier;

namespace SchoolHarbor.Interview.Services.Survey.Question;

public sealed class Question
{
    public Question(
        IReferenceId instanceDbId,
        DateTime instanceStartDate,
        DateTime instanceEndDate,
        IReferenceId questionDbId,
        string name,
        string text,
        int kind)
    {
        InstanceDbId = instanceDbId;
        InstanceStartDate = instanceStartDate;
        InstanceEndDate = instanceEndDate;
        QuestionDbId = questionDbId;
        Name = name;
        Text = text;
        Kind = kind;
    }
    
    public IReferenceId InstanceDbId { get; }
    public DateTime InstanceStartDate { get; }
    public DateTime InstanceEndDate { get; }
    public IReferenceId QuestionDbId { get; }
    public string Name { get; }
    public string Text { get; }
    public int Kind { get; }
}