using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ParkAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private ParkAPIContext _db;

    public ParksController(ParkAPIContext db)
    {
      _db = db;
    }

    ///<summary>
    ///Creates a new Park entry in data table.
    ///</summary>
    [HttpPost]
    public void Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      _db.SaveChanges();
    }

    ///<summary>
    ///Finds parks in database using flexible search parameters.  Enter "yes" for required features (playground, beach, etc.).
    ///</summary>
    [HttpGet]
    public ActionResult<Dictionary<string, object>> Get(string name, string location, string type, string entranceFee, string parkingPermit, string playgroundReq, string beachReq, string picnicAreaReq, string realBathroomsReq, string visitorCenterReq, int userId)
    {
      var query = _db.Parks.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }

      if (location != null)
      {
        query = query.Where(entry => entry.Location.Contains(location));
      }

      if (type != null)
      {
        query = query.Where(entry => entry.Type.Contains(type));
      }

      if (entranceFee != null)
      {
        query = query.Where(entry => entry.EntranceFee <= int.Parse(entranceFee));
      }

      if (parkingPermit != null)
      {
        query = query.Where(entry => (entry.ParkingPermit == parkingPermit) || (entry.ParkingPermit == null));
      }

      if (playgroundReq == "yes")
      {
        query = query.Where(entry => entry.Playground == true);
      }

      if (beachReq == "yes")
      {
        query = query.Where(entry => entry.Beach == true);
      }

      if (picnicAreaReq == "yes")
      {
        query = query.Where(entry => entry.PicnicArea == true);
      }

      if (realBathroomsReq == "yes")
      {
        query = query.Where(entry => entry.RealBathrooms == true);
      }

      if (visitorCenterReq == "yes")
      {
        query = query.Where(entry => entry.VisitorCenter == true);
      }

      if (userId != 0)
      {
        query = query.Where(entry => entry.UserId == userId);
      }
      Dictionary<string, object> response = new Dictionary<string, object>();
      response.Add("Allowed Park Types", EnvironmentVariables.Types);
      response.Add("Allowed Parking Permit Types", EnvironmentVariables.ParkingPermits);
      response.Add("ParkList", query);
      return response;
    }

    ///<summary>
    ///Look up Parks by ParkId
    ///</summary>
    [HttpGet("{id}")]
    public ActionResult<Park> Get(int id)
    {
      return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
    }

    ///<summary>
    ///Editing parks only possible when userId input matches Park's UserId in database.
    ///</summary>
    [HttpPut("{userId}/{id}")]
    public IActionResult Put(int userId, int id, [FromBody] Park park)
    {
      park.ParkId = id;
      if (park.UserId == userId)
      {
        _db.Entry(park).State = EntityState.Modified;
        _db.SaveChanges();
        return Ok();
      }
      else
      {
        return BadRequest(new { message = "This user is not permitted to edit this Park entry." });
      }
    }

    ///<summary>
    ///Deleting parks only possible when userId input matches Park's UserId in database.
    ///</summary>
    [HttpDelete("{userId}/{id}")]
    public IActionResult Delete(int id, int userId)
    {
      var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
      if (parkToDelete.UserId == userId)
      {
        _db.Parks.Remove(parkToDelete);
        _db.SaveChanges();
        return Ok();
      }
      else
      {
        return BadRequest(new { message = "This user is not permitted to delete this Park entry." });
      }
    }
  }
}
