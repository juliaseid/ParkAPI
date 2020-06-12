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

    [HttpGet]
    public ActionResult<IEnumerable<Park>> Get()
    {
      return _db.Parks.ToList();
    }

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

    //http://localhost:5000/api/remedies/1/9
    [HttpDelete("{userId}/{id}")]
    public void Delete(int id, int userId)
    {
      var remedyToDelete = _db.Remedies.FirstOrDefault(entry => entry.RemedyId == id);
      if (remedyToDelete.UserId == userId)
      {
        _db.Remedies.Remove(remedyToDelete);
        _db.SaveChanges();
      }
    }

    // GET api/Remedies
    [HttpGet]
    // public ActionResult<IEnumerable<Remedy>> Get(string name, string details, string ailment, string category, string ingredients, int userId)
    public ActionResult<Dictionary<string, object>> Get(string name, string details, string ailment, string category, string ingredients, int userId)
    {
      var query = _db.Remedies.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (details != null)
      {
        query = query.Where(entry => entry.Details.Contains(details));
      }

      if (ingredients != null)
      {
        query = query.Where(entry => entry.Ingredients.Contains(ingredients));
      }

      if (ailment != null)
      {
        query = query.Where(entry => entry.Ailment == ailment);
      }

      if (category != null)
      {
        query = query.Where(entry => entry.Category == category);
      }

      if (userId != 0)
      {
        query = query.Where(entry => entry.UserId == userId);
      }
      Dictionary<string, object> response = new Dictionary<string, object>();
      response.Add("categories", EnvironmentVariables.Categories);
      response.Add("remedies", query);
      return response;
    }
  }
}
