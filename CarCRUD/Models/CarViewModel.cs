namespace CarCRUD.Models;

public class CarViewModel
{
    public string Vin { get; set; } = new Vehicle().Vin();
    public string? Model { get; set; } = null;
    public string? Vendor { get; set; } = null;


    public CarViewModel() { }

    public CarViewModel(ref CarViewModel model)
    {
        if (Vendor is null) Vendor = model.Vendor;
        if (Model is null) Model = model.Model;
    }
}
