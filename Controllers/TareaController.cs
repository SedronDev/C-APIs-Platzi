using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using webapi.Models;
namespace APIs_Platzi.Controllers;


[ApiController]
[ValidateNever]
[Route("[controller]")]
public class TareaController : ControllerBase {
    ITareaService tareaService;

    public TareaController(ITareaService service){
        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get() 
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Post(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}