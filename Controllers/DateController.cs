using AvoApi.Data;
using AvoApi.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AvoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DateController: ControllerBase
{
    private AvocadoContext _context { get; }
    
    public DateController(AvocadoContext context)
    {
        _context = context;
    }
    
    [HttpGet("year")]
    [SwaggerOperation(Description = "returns all results in the year")]
    public async Task<IActionResult> GetAllInYear(int year)
    {
        var items = await _context.Avocados
            .Where(x => x.Year == year)
            .ToListAsync();
        
        return Ok(GenericResponse.Success(items));
    }

    [HttpGet("after")]
    [SwaggerOperation(Description = "returns all results after the specified date")]
    public async Task<IActionResult> GetAllAfterDate(DateTime date)
    {
        var items = await _context.Avocados
            .Where(x => x.Date > date)
            .ToListAsync();

        return Ok(GenericResponse.Success(items));
    }
    
    [HttpGet("before")]
    [SwaggerOperation(Description = "returns all results before the specified date")]
    public async Task<IActionResult> GetAllBeforeDate(DateTime date)
    {
        var items = await _context.Avocados
            .Where(x => x.Date < date)
            .ToListAsync();

        return Ok(GenericResponse.Success(items));
    }
    
}