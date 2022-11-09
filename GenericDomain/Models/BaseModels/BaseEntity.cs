namespace GenericAPI.Models.BaseModels;

public class BaseEntity
{
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModified { get; set; }
    public string LastModifiedBy { get; set; }
    public bool IsActive { get; set; }
}