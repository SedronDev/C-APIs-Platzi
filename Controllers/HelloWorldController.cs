using Microsoft.AspNetCore.Mvc;

namespace APIs_Platzi.Controllers;


[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase {
    private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger){
        _logger = logger;
        helloWorldService = helloWorld;
    }

    [HttpGet]
    public IActionResult Get() {
        _logger.LogInformation("Devolviendo el mensaje de HelloWorld");
        return Ok(helloWorldService.GetHelloWorld());
    }
}