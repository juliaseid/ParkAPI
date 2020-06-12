using System.Collections.Generic;

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
      if (!EnvironmentVariables.Categories.Contains(Category))
      {
        yield return new ValidationResult(
            $"Category is not contained in Categories",
            new[] { "Category" });
      }
    }
  }
}