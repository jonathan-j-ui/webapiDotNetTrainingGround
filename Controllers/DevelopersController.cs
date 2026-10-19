using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using webapiDotNetTrainingGround.Models;

namespace webapiDotNetTrainingGround.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DevelopersController : ControllerBase
{
    private Db _db;

    public DevelopersController()
    {
        _db = new Db();
    }
    
    [HttpGet]
    public List<Developer> GetAllDevs()
    {
        return _db.Developers;
    }

    [HttpGet("{id}")]
    public Developer? GetDeveloperById(int id)
    {
        return _db.Developers.Find(d => d.Id == id);
    }

    [HttpPost]
    public IActionResult CreateNewDeveloper(Developer developerToAdd)
    {
        var nextId = _db.Developers.Count + 1;
        developerToAdd.Id = nextId;
        _db.Developers.Add(developerToAdd);

        return CreatedAtAction(nameof(GetDeveloperById), new { id = nextId }, developerToAdd);
    }
}

public class Db
{
    public Db()
    {
        DevelopersController = new List<Developer>()
        {
            new Developer{
            Id = 1, 
            Name = "Stefan",
            Email = "Stefan@gmail.com"
            },
            new Developer{
            Id = 2, 
            Name = "Malin",
            Email = "Malin123@gmail.com"
            }
        };
    }

    public List<Developer> Developers { get; set; }
}