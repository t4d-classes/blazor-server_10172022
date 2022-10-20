using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsApp.Data.Models
{
  [Table("Color")]  
  public class Color
  {
    public int Id {  get; set ; }
    public string Name { get; set ; } 
    public string HexCode { get; set ; }  
  }
}
