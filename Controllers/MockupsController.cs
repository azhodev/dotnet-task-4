using Microsoft.AspNetCore.Mvc;
using Task4.Models;

namespace Task4.Controllers;

public class MockupsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult UserManagement()
    {
        var users = new List<MockUserViewModel>
        {
            new() { Name = "Olivia Roberts", Email = "olivia.roberts@example.com", LastActivity = "2026-02-12 09:10", Status = "active", IsSelected = true },
            new() { Name = "Liam Johnson", Email = "liam.johnson@example.com", LastActivity = "2026-02-12 08:43", Status = "blocked", IsSelected = false },
            new() { Name = "Emma Wilson", Email = "emma.wilson@example.com", LastActivity = "2026-02-12 08:11", Status = "unverified", IsSelected = false },
            new() { Name = "Noah Brown", Email = "noah.brown@example.com", LastActivity = "2026-02-12 07:50", Status = "active", IsSelected = true },
            new() { Name = "Sophia Davis", Email = "sophia.davis@example.com", LastActivity = "2026-02-11 21:05", Status = "active", IsSelected = false },
            new() { Name = "Mason Miller", Email = "mason.miller@example.com", LastActivity = "2026-02-11 19:36", Status = "blocked", IsSelected = false }
        };

        var model = new UserManagementMockViewModel
        {
            Users = users,
            TotalUsers = users.Count,
            ActiveUsers = users.Count(u => u.Status == "active"),
            BlockedUsers = users.Count(u => u.Status == "blocked"),
            UnverifiedUsers = users.Count(u => u.Status == "unverified")
        };

        return View(model);
    }

    public IActionResult RegistrationSuccess()
    {
        return View();
    }

    public IActionResult Blocked()
    {
        return View();
    }
}
