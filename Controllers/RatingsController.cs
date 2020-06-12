using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkAPI.Models;


namespace ParkAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RatingsController : ControllerBase
  {
    private ParkAPIContext _db;

    public RatingsController(ParkAPIContext db)
    {
      _db = db;
    }

    [HttpPost]
    public void Post([FromBody] Rating rating)
    {
      _db.Ratings.Add(rating);
      _db.SaveChanges();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Rating>> Get(int parkId, int ratingId, int userId)
    {
      var query = _db.Ratings.AsQueryable();

      if (parkId != 0)
      {
        query = query.Where(entry => entry.ParkId == parkId);
      }

      if (ratingId != 0)
      {
        query = query.Where(entry => entry.RatingId == ratingId);
      }

      if (userId != 0)
      {
        query = query.Where(entry => entry.UserId == userId);
      }
      return query.ToList();
    }

  }
}