using Microsoft.AspNetCore.Mvc;
using webapiDotNetTrainingGround.Models;

namespace webapiDotNetTrainingGround.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DevelopersController : ControllerBase
{
    private List<Developer> _db;

    public DevelopersController()
    {
        _db = new List<Developer>();
    }
    
    [HttpGet]
    public List<Developer> GetAllDevs()
    {
        return _db;
    }
}