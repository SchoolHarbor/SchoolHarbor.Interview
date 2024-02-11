namespace SchoolHarbor.Interview.Data.Entities;

public class InstanceEntity
{
    public int Id { get; set; }

    public int SurveyId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime UpdatedOn { get; set; }
    
    public string UpdatedBy { get; set; }
}