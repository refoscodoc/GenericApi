using GenericAPI.Models.BaseModels;

namespace GenericAPI.Models;

public class SellerModel : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}