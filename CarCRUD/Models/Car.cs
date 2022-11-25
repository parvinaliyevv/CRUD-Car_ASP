namespace CarCRUD.Models;

[PrimaryKey(nameof(Vin))]
public class Car
{
    public string Vin { get; set; }
    public string? Vendor { get; set; } = null;
    public string? Model { get; set; } = null;

}
