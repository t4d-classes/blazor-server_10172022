# Exercise 9

## Requirements

**Requirement 1.** Move the color list management logic to a service named `ColorsData`.

**Requirement 2.** Code the new service class according to an interface named `IColorsData` stored in the `ToolsApp\Core\Interfaces\Data` folder.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;

using ToolsApp.Core.Interfaces.Models;

namespace ToolsApp.Core.Interfaces.Data;

public interface IColorsData
{
    IEnumerable<IColor> All();
    IColor Append(INewColor newColor);
    void Remove(int colorId);
}
```
**Requirement 3.** Register the service as a singleton.

**Requirement 4.** Update the code in `ColorTool.cs` to use the new service to manage the list of colors.

**Requirement 5.** Ensure it works!
