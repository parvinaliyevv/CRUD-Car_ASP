namespace CarCRUD.Controllers;

public class CarController : Controller
{
    private AppDbContext _dbContext;


    public CarController(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        if (dbContext.Cars.Count() == 0)
        {
            dbContext.Cars.AddRange(new Faker<Car>()
            .RuleFor("Vin", faker => faker.Vehicle.Vin())
            .RuleFor("Model", faker => faker.Vehicle.Model())
            .RuleFor("Vendor", faker => faker.Vehicle.Manufacturer())
            .Generate(7));

            dbContext.SaveChanges();
        }
    }


    public IActionResult Home() => View();

    public IActionResult Create() => View(new CarViewModel());

    public IActionResult Read()
    {
        var cars = _dbContext.Cars.Select(car => TypeConverter.Convert<CarViewModel, Car>(car)).ToList();

        return View(cars);
    }

    public IActionResult Update()
    {
        var items = new List<SelectListItem>();
        var cars = _dbContext.Cars.Select(car => TypeConverter.Convert<CarViewModel, Car>(car)).ToList();

        foreach (var item in cars)
        {
            var selectItem = new SelectListItem(item.ToString(), item.Vin);

            items.Add(selectItem);
        }

        ViewBag.Cars = items;

        return View();
    }

    public IActionResult Delete()
    {
        var items = new List<SelectListItem>();
        var cars = _dbContext.Cars.Select(car => TypeConverter.Convert<CarViewModel, Car>(car)).ToList();

        foreach (var item in cars)
        {
            var selectItem = new SelectListItem(item.ToString(), item.Vin);

            items.Add(selectItem);
        }

        ViewBag.Cars = items;

        return View();
    }


    [HttpPost]
    public IActionResult Create(CarViewModel carViewModel)
    {
        if (!ModelState.IsValid) return View();

        var car = TypeConverter.Convert<Car, CarViewModel>(carViewModel);

        _dbContext.Cars.Add(car);
        _dbContext.SaveChanges();

        return RedirectToAction("Read");
    }

    [HttpPost]
    public IActionResult Update(UpdateCarViewModel carViewModel)
    {
        var updatedCar = TypeConverter.Convert<Car, UpdateCarViewModel>(carViewModel);

        var cars = _dbContext.Cars.ToList();

        var car = cars.Find(car => car.Vin == updatedCar.Vin);

        if (car is null) return View();

        if (updatedCar.Vendor is null) updatedCar.Vendor = car.Vendor;
        if (updatedCar.Model is null) updatedCar.Model = car.Model;

        _dbContext.Remove(car);
        _dbContext.Add(updatedCar);

        _dbContext.SaveChanges();

        return RedirectToAction("Read");
    }

    [HttpPost]
    public IActionResult Delete(string vinValue)
    {
        var cars = _dbContext.Cars.ToList();
        var car = cars.Find(car => car.Vin == vinValue);

        if (car is null) return View();

        _dbContext.Cars.Remove(car);
        _dbContext.SaveChanges();

        return RedirectToAction("Read");
    }
}
