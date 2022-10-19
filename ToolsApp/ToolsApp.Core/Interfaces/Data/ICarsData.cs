using ToolsApp.Core.Interfaces.Models;

namespace ToolsApp.Core.Interfaces.Data;

public interface ICarsData
{
  IEnumerable<ICar> All();
  ICar Append(INewCar newCar);
  void Replace(ICar car);
  void Remove(int carId);
}