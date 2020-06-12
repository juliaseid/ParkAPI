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

    // [HttpGet]
    // public ActionResult<IEnumerable<Park>> Get()
    // {
    //   return _db.Parks.ToList();
    // }

    [HttpPost]
    public void Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Park> Get(int id)
    {
      return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
    }

    [HttpPut("{userId}/{id}")]
    public void Put(int userId, int id, [FromBody] Park park)
    {
      park.ParkId = id;
      if (park.UserId == userId)
      {
        _db.Entry(park).State = EntityState.Modified;
        _db.SaveChanges();
      }
    }

    [HttpDelete("{userId}/{id}")]
    public void Delete(int id, int userId)
    {
      var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
      if (parkToDelete.UserId == userId)
      {
        _db.Parks.Remove(parkToDelete);
        _db.SaveChanges();
      }
    }

    [HttpGet]
    public ActionResult<Dictionary<string, object>> Get(string name, string location, string type, string entranceFee, string parkingPermit, string playground, string beach, string picnicArea, string realBathrooms, string visitorCenter, int userId)
    {
      var query = _db.Parks.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
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
        query = query.Where(entry => (entry.ParkingPermit == parkingPermit || null));
      }

      if (playground != null)
      {
        query = query.Where(entry => entry.Playground == true);
      }

      if (beach != null)
      {
        query = query.Where(entry => entry.Beach == true);
      }

      if (picnicArea != null)
      {
        query = query.Where(entry => entry.PicnicArea == true);
      }

      if (realBathrooms != null)
      {
        query = query.Where(entry => entry.RealBathrooms == true);
      }

      if (visitorCenter != null)
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
  }
}
