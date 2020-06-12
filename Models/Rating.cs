namespace ParkAPI.Models
{
  public class Rating
  {
    public int RatingId { get; set; }
    public int Clean { get; set; }
    public int Accessible { get; set; }
    public int FunForKids { get; set; }
    public int FunForParents { get; set; }
    public int ParkId { get; set; }
    public int UserId { get; set; }
    public string Comments { get; set; }

  }
}
