using Microsoft.AspNetCore.Mvc;

namespace APIs_Platzi.Controllers;


[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase {
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld){
        helloWorldService = helloWorld;
    }

    public IActionResult Get() {
        return Ok(helloWorldService.GetHelloWorld());
    }
}