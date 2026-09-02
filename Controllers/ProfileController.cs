using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using dotnet.Models;

namespace dotnet.Controllers;

[Authorize]
[Route("profile")]
public class ProfileController : Controller
{
    private readonly IMongoCollection<User> _users;

    public ProfileController(IMongoClient client)
    {
        var database = client.GetDatabase("YourDatabaseName");
        _users = database.GetCollection<User>("Users");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _users.Find(u => u.Id == userId).FirstOrDefaultAsync();

        if (user == null) return NotFound();

        return View(user);
    }
}