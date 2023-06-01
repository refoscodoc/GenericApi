namespace GenericAPI.Dtos;

public class GuitarDto
{
    private Guid Id { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public SellerDto Seller { get; set; }
}