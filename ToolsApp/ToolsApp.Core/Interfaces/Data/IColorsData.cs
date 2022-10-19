using ToolsApp.Core.Interfaces.Models;

namespace ToolsApp.Core.Interfaces.Data;

public interface IColorsData
{
  IEnumerable<IColor> All();
  IColor Append(INewColor newColor);
  void Remove(int colorId);
}