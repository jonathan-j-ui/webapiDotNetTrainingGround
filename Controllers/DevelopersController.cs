using Microsoft.AspNetCore.Mvc;
using webapiDotNetTrainingGround.Models;

namespace webapiDotNetTrainingGround.Controllers;

public class DevelopersController : ControllerBase
{
    private List<Developer> _db;

    public DevelopersController()
    {
        _db = new List<Developer>();
    }
}