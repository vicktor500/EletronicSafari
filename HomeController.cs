using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ElectronicSafari.Models;
using Npgsql;
using System.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ElectronicSafari.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly DatabaseConnection _dbConnection;

    public HomeController(ILogger<HomeController> logger, DatabaseConnection databaseConnection)
    {
        _logger = logger;
        _dbConnection = databaseConnection;
    }

    public IActionResult Index()
    {
        
 using var conn = _dbConnection.GetConnection();
        using var cmd = new NpgsqlCommand("SELECT a.nome, a.email from usuario a", conn);
        using var reader = cmd.ExecuteReader();

        int cont = 0;
        var nomes = new List<string>();
        var emails = new List<string>();

        while(reader.Read()){

            nomes.Add(reader.GetString(0));
            emails.Add(reader.GetString(1));
            cont++;
        
        }

        ViewData["nomes"] = nomes;
        ViewData["emails"] = emails;
        ViewData["cont"] = cont;
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
