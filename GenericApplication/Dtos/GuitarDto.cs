namespace GenericAPI.Dtos;

public class GuitarDto
{
    public string Model { get; set; }
    public int Year { get; set; }
    public SellerDto Seller { get; set; }
}