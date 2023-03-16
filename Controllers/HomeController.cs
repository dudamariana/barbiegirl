using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Barbiegirl.Models;
using barbiegirl.Services;
namespace barbiegirl.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBarbService _barbService;
    public HomeController(ILogger<HomeController> logger, IBarbService barbService)
    {
        _logger = logger;
        _barbService = barbService;
    }
    public IActionResult Index(string tipo)
    {
        var barb = _barbService.GetBarbiegirlDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(barb);
    }
    public IActionResult Details(int Numero)
    {
        var barbie = _barbService.GetDetailedBarbie(Numero);
        return View(barbie);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id
        ?? HttpContext.TraceIdentifier
        });
    }
}