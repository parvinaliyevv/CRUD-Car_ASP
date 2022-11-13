namespace CarCRUD.Controllers;

public class CarController : Controller
{
    private static List<CarViewModel> _cars;


    static CarController()
    {
        _cars = new Faker<CarViewModel>()
            .RuleFor("Model", (faker) => faker.Vehicle.Model())
            .RuleFor("Vendor", (faker) => faker.Vehicle.Manufacturer())
            .Generate(7);
    }


    public IActionResult Home() => View();

    public IActionResult Create() => View(new CarViewModel());

    public IActionResult Read() => View(_cars);

    public IActionResult Update() => View();

    public IActionResult Delete() => View();


    [HttpPost]
    public IActionResult Create(CarViewModel carViewModel)
    {
        _cars.Add(carViewModel);

        return RedirectToAction("Read");
    }

    [HttpPost]
    public IActionResult Update(CarViewModel carViewModel)
    {
        int index = _cars.FindIndex(car => car.Vin == carViewModel.Vin);

        if (index == -1) return View();

        _cars.RemoveAt(index);
        _cars.Insert(index, carViewModel);

        return RedirectToAction("Read");
    }

    [HttpPost]
    public IActionResult Delete(string vinValue)
    {
        var count = _cars.RemoveAll(car => car.Vin == vinValue);

        return (count == 0) ? View() : RedirectToAction("Read");
    }
}
