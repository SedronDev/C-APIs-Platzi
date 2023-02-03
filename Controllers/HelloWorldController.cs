using Microsoft.AspNetCore.Mvc;
using webapi;

namespace APIs_Platzi.Controllers;


[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase {
    private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldService;

    TareasContext dbContext;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger, TareasContext db){
        _logger = logger;
        dbContext = db;
        helloWorldService = helloWorld;
    }

    [HttpGet]
    public IActionResult Get() {
        _logger.LogInformation("Devolviendo el mensaje de HelloWorld");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();

        return Ok();
    }
}