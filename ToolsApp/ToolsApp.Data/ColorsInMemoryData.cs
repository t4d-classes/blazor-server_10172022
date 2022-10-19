using ToolsApp.Core.Interfaces.Data;
using ToolsApp.Core.Interfaces.Models;
using ToolsApp.Models;

namespace ToolsApp.Data
{
  public class ColorsInMemoryData : IColorsData
  {
    private List<IColor> _colors { get; set; } = new List<IColor>() {
      new Color() { Id = 1, Name = "red", HexCode = "ff0000" },
      new Color() { Id = 2, Name = "green", HexCode = "00ff00" },
      new Color() { Id = 3, Name = "blue", HexCode = "0000ff" },
    };

    public IEnumerable<IColor> All()
    {
      return _colors;
    }

    public IColor Append(INewColor newColor)
    {
      var color = new Color()
      {
        Id = _colors.Any() ? _colors.Max(c => c.Id) + 1 : 1,
        Name = newColor.Name,
        HexCode = newColor.HexCode,
      };

      _colors.Add(color);
  
      return color;
    }

    public void Remove(int colorId)
    {
      _colors.Remove(_colors.Find(color => color.Id == colorId));
    }
  }
}