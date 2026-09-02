using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using dotnet.Models;

namespace dotnet.Controllers;

[Route("register")]
public class RegisterController : Controller
{
    private readonly IMongoCollection<User> _users;

    public RegisterController(IMongoClient client)
    {
        var database = client.GetDatabase("YourDatabaseName");
        _users = database.GetCollection<User>("Users");
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Index(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var existingUser = await _users.Find(u => u.Email == model.Email).FirstOrDefaultAsync();
        if (existingUser != null)
        {
            ModelState.AddModelError("", "User with this email already exists.");
            return View(model);
        }

        var user = new User
        {
            Name = model.Name,
            Age = model.Age,
            Email = model.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
        };

        await _users.InsertOneAsync(user);

        return RedirectToAction("Index", "Login");
    }
}