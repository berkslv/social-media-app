using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Client.Models;
using Client.Services;
using FluentValidation.Results;

namespace Client.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserForLoginModel model)
    {
        var validator = new UserForLoginModelValidator();
        ValidationResult validation = validator.Validate(model);
        
        if (validation.IsValid)
        {
            Console.WriteLine(model.Email);
            Console.WriteLine(model.Password);
            return RedirectToAction("Index");
        }

        foreach (var item in validation.Errors)
        {
            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }

        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
