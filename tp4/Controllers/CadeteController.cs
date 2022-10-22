global using tp4.Models;
using Microsoft.AspNetCore.Mvc;

namespace tp4.Controllers{

public class CadeteController : Controller{

    private readonly ILogger<CadeteController> _logger;
    
    private readonly List<Cadete> _cadetes = new ();
    private static int _id = 0;


    public CadeteController(ILogger<CadeteController> logger){
        _logger = logger;
    }

    [HttpGet]
    public IActionResult RegistroCadete(){
        return View();
    }
    
    [HttpPost]
    public IActionResult AltaCadete(Cadete cadete){
        cadete.Id = ++_id;
        Console.WriteLine(cadete.Nombre);
        _cadetes.Add(cadete);
        return View("ListadoCadetes", _cadetes);
    }

    [HttpGet]
    public IActionResult BajaCadete(Cadete cadete){
        _cadetes.Remove(cadete);
        return View(cadete);
    }

    [HttpGet]
    public IActionResult ListadoCadetes(List<Cadete> cadetes){
        return View(cadetes);
    }
}
}
