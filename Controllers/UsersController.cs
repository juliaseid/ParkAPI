using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ParkAPI.Services;
using ParkAPI.Models;
using System;

namespace ParkAPI.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {

    private ParkAPIContext _db;
    private IUserService _userService;

    public UsersController(ParkAPIContext db, IUserService userService)
    {
      _db = db;
      _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] User userParam)
    {
      Console.WriteLine($"Console Attempt: {userParam.Username}, {userParam.Password}");
      var user = _userService.Authenticate(userParam.Username, userParam.Password);

      if (user == null)
      {
        return BadRequest(new { message = "Username or password is incorrect" });
      }
      return Ok(user);
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
      var users = _userService.GetAll();
      return Ok(users);
    }
  }
}
