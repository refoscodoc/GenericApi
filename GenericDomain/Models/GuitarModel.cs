using GenericAPI.Models.BaseModels;

namespace GenericAPI.Models;

public class GuitarModel : BaseEntity
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public SellerModel Seller { get; set; }
}