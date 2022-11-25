namespace CarCRUD.ViewModels;

public class CarViewModel
{
    public string Vin { get; set; } = new Vehicle().Vin();
    public string? Vendor { get; set; } = null;
    public string? Model { get; set; } = null;


    public override string ToString() => string.Format("[{0}]: {1} - {2}", Vin, Vendor, Model);
}
