namespace CarCRUD.ViewModels;

public class CarViewModel
{
    public string Vin { get; set; } = new Vehicle().Vin();

    [Required(ErrorMessage = "Vendor cannot be empty!")]
    public string? Vendor { get; set; } = null;

    [Required(ErrorMessage = "Model cannot be empty!")]
    public string? Model { get; set; } = null;

    public override string ToString() => string.Format("[{0}]: {1} - {2}", Vin, Vendor, Model);
}

public class UpdateCarViewModel
{
    public string Vin { get; set; }
    public string? Vendor { get; set; } = null;
    public string? Model { get; set; } = null;
}
