using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ElectronicSafari.Models;

namespace ElectronicSafari.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
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

    public IActionResult Produtos()
    {
        return View();
    }

    public IActionResult SafariBox()
    {
        return View();
    }

    public IActionResult NossasLojas()
    {
        return View();
    }

    public IActionResult SobreNos()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
