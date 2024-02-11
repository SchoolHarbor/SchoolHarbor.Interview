namespace SchoolHarbor.Interview.Data.Entities;

public class InstanceQuestionAssociationEntity
{
    public int Id { get; set; }

    public int InstanceId { get; set; }
    public int QuestionId { get; set; }

    public int WeightDetailId { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime UpdatedOn { get; set; }
    
    public string UpdatedBy { get; set; }
}