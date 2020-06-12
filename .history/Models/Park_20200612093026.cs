using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace ParkAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Type { get; set; }
    public int EntranceFee { get; set; }
    public string ParkingPermit { get; set; }
    public bool Playground { get; set; }
    public bool Beach { get; set; }
    public bool PicnicArea { get; set; }
    public bool RealBathrooms { get; set; }
    public bool VisitorCenter { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (!EnvironmentVariables.Types.Contains(Type))
      {
        yield return new ValidationResult(
            $"That is not a valid type of park",
            new[] { "Type" });
      }

      if (!EnvironmentVariables.Types.Contains(Type))
      {
        yield return new ValidationResult(
            $"That is not a valid type of park",
            new[] { "Type" });
      }
    }
  }
}