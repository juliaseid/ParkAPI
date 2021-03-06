using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ParkAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }
    [Required]
    [StringLength(200)]
    public string Location { get; set; }
    public string Type { get; set; }
    public int EntranceFee { get; set; }
    public string ParkingPermit { get; set; }
    public bool Playground { get; set; }
    public bool Beach { get; set; }
    public bool PicnicArea { get; set; }
    public bool RealBathrooms { get; set; }
    public bool VisitorCenter { get; set; }
    [Required]
    public int UserId { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (!EnvironmentVariables.Types.Contains(Type))
      {
        yield return new ValidationResult(
            $"That is not a valid type of park.  Accepted park types are in the header of all GET requests.",
            new[] { "Type" });
      }

      if (!EnvironmentVariables.ParkingPermits.Contains(ParkingPermit))
      {
        yield return new ValidationResult(
            $"That is not a valid type of parking permit.  Accepted parking permit types are in the header of all GET requests.",
            new[] { "ParkingPermit" });
      }

    }
  }
}