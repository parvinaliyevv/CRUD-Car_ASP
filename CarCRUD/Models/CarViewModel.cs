namespace CarCRUD.Models;

public class CarViewModel
{
    public string Vin { get; set; } = new Vehicle().Vin();
    public string? Model { get; set; } = null;
    public string? Vendor { get; set; } = null;
}
