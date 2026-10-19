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

    public DevelopersController(Db db)
    {
        _db = db;
    }
    
    [HttpGet]
    public List<DeveloperResponse> GetAllDevs()
    {
        var developerResponseList = new List<DeveloperResponse>();

        foreach (var developer in _db.Developers)
        {
            developerResponseList.Add(new DeveloperResponse{
                Id = developer.Id,
                Name = developer.Name,
                Email = developer.Email
            });
        }
        return developerResponseList;
    }

    [HttpGet("{id}")]
    public DeveloperResponse? GetDeveloperById(int id)
    {
        var foundDeveloper = _db.Developers.Find(d => d.Id == id);

        if (foundDeveloper is null)
        {
            return null;
        }

        return new DeveloperResponse{
            Id = foundDeveloper.Id,
            Name = foundDeveloper.Name,
            Email = foundDeveloper.Email
        };
    }

    [HttpPost]
    public IActionResult CreateNewDeveloper(CreateDeveloperRequest request)
    {
        var nextId = _db.Developers.Count + 1;
        var developerToAdd = new Developer()
        {
            Id = nextId,
            Name = request.Name,
            Email = request.Email
        };
        
        _db.Developers.Add(developerToAdd);

        return CreatedAtAction(nameof(GetDeveloperById), new { id = nextId }, developerToAdd);
    }
}

public class CreateDeveloperRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

public class DeveloperResponse
{
    public int Id { get; set;}
    public string? Name { get; set; }
    public string? Email { get; set; }
}

public class Db
{
    public Db()
    {
        Developers = new List<Developer>()
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