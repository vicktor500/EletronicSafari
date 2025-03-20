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
        var login = new List<string>();

        while(reader.Read()){

            nomes.Add(reader.GetString(0));
            login.Add(reader.GetString(1));
            cont++;
        
        }

        ViewData["nomes"] = nomes;
        ViewData["login"] = login;
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

    public IActionResult Register(){

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User user, IFormFile Foto){
        if (ModelState.IsValid)
        {
            await _userRepository.InsertUser(user,Foto);
            return RedirectToAction("index");
        }
        return View(user);
    }

    public IActionResult ListUser(){
        
        var users = _userRepository.ListUser();

        return View(users);
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
