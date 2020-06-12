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

    ///<summary>
    ///Create a rating for a specific park, using Park Id and UserId to associate in one-to-many data table
    ///</summary>
    [HttpPost]
    public void Post([FromBody] Rating rating)
    {
      _db.Ratings.Add(rating);
      _db.SaveChanges();
    }

    ///<summary>
    ///Search ratings by park, or all parks by cleanliness, accessibility, fun for kids and parents, or by ratings created by a specific user (by userId).
    ///</summary>
    [HttpGet]
    public ActionResult<IEnumerable<Rating>> Get(int parkId, int ratingId, int userId, int cleanliness, int accessibility, int fun4kids, int fun4parents)
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

      if (cleanliness != 0)
      {
        query = query.Where(entry => entry.Clean >= cleanliness);
      }

      if (accessibility != 0)
      {
        query = query.Where(entry => entry.Accessible >= accessibility);
      }

      if (fun4kids != 0)
      {
        query = query.Where(entry => entry.FunForKids >= fun4kids);
      }

      if (fun4parents != 0)
      {
        query = query.Where(entry => entry.FunForParents >= fun4parents);
      }
      return query.ToList();
    }

  }
}