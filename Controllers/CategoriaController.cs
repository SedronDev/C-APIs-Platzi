using Microsoft.AspNetCore.Mvc;
using webapi.Models;
namespace APIs_Platzi.Controllers;


[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase {
    private readonly ILogger<CategoriaController> _logger;
    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService service, ILogger<CategoriaController> logger){
        _logger = logger;
        categoriaService = service;
    }

    [HttpGet]
    public IActionResult Get() 
    {
        _logger.LogInformation("Devolviendo el mensaje de Get");
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Post(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }
}