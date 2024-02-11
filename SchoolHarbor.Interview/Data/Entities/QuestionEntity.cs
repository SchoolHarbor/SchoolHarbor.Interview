namespace SchoolHarbor.Interview.Data.Entities;

public class QuestionEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Text { get; set; }

    public int Kind { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime UpdatedOn { get; set; }
    
    public string UpdatedBy { get; set; }
}