using ToolsApp.Core.Interfaces.Data;
using ToolsApp.Core.Interfaces.Models;
using ToolsApp.Models;

namespace ToolsApp.Data
{
  public class CarsInMemoryData : ICarsData
  {
    private List<ICar> _cars { get; set; } = new List<ICar>() {
      new Car() { Id = 1, Make="Ford", Model="Fusion Hybrid", Year=2020, Color="Blue", Price=45000 },
      new Car() { Id = 2, Make="Tesla", Model="S", Year=2022, Color="Red", Price=115000 },
    };

    public IEnumerable<ICar> All()
    {
      return _cars;
    }

    public ICar Append(INewCar newCar)
    {
      var car = new Car()
      {
        Id = _cars.Any() ? _cars.Max(c => c.Id) + 1 : 1,
        Make = newCar.Make,
        Model = newCar.Model,
        Year = newCar.Year,
        Color = newCar.Color,
        Price = newCar.Price,
      };

      _cars.Add(car);
  
      return car;
    }

    public void Replace(ICar car)
    {
      var carIndex = _cars.FindIndex(c => c.Id == car.Id);
      _cars[carIndex] = car;
    }

    public void Remove(int carId)
    {
      _cars.Remove(_cars.Find(car => car.Id == carId));
    }
  }
}