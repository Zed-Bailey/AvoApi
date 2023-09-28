using AvoApi.Data;
using AvoApi.Data.Dto;
using AvoApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AvoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TypeController : ControllerBase
{
    
    private AvocadoContext _context { get; }

    public TypeController(AvocadoContext context)
    {
        _context = context;
    }

    [HttpGet("types")]
    [SwaggerOperation(Description = "Returns the supported types of avocados")]
    public string[] GetTypes()
    {
        return new[]
        {
            "conventional",
            "organic"
        };
    }

    [HttpGet("types/{type}")]
    [SwaggerOperation(Description = "returns all days with the supported type")]
    public async Task<IActionResult> GetAllWithType(string type, int page = 0)
    {
        
        var items = await _context.Avocados
            .Where(x => x.Type == type)
            .Pageable(page)
            .ToListAsync();
        
        return Ok(GenericResponse.Success(items));
    }
}