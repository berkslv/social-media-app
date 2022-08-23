using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Client.Models;

namespace Client.Controllers;

public class FeedController : Controller
{
    private readonly ILogger<FeedController> _logger;

    public FeedController(ILogger<FeedController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
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
