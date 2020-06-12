using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ParkAPI.Models
{
  public static class EnvironmentVariables
  {
    public static List<string> Types = new List<string> { "Washington State Park", "National Park", "County Park", "Tacoma Power Park", "City Park" };
    public static List<string> ParkingPermit = new List<string> { "Discover Pass", "SnoPark Permit", "Northwest Forest Pass" }
  }
}
