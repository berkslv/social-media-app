using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Client.Models;
using Client.Services;
using Newtonsoft.Json;

namespace Client.Controllers;

public class FeedController : Controller
{
    private readonly ILogger<FeedController> _logger;

    public FeedController(ILogger<FeedController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var httpService = new HttpService();
        var res = await httpService.Get("/posts/1","eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MDg0NDI5NCwiZXhwIjoxNjYxNDQ0MjkzLCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.XKIWoEwCiCHc86ajY4kt-5U4B9QAdXcUfqrOqIFTIHU");
    
        var data = JsonConvert.DeserializeObject<PostModel>(res.Data.ToString());

        Console.WriteLine(data.Content);

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
