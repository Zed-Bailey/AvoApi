using AvoApi.Data;
using AvoApi.Data.Dto;
using AvoApi.Data.Models;
using AvoApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AvoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceController: ControllerBase
{
    private AvocadoContext _context { get; set; }
    public PriceController(AvocadoContext context)
    {
        _context = context;
    }

    [HttpGet("range")]
    [SwaggerOperation(Description = "returns all days where the average price is between the two values")]
    public async Task<IActionResult> GetAllInRange(decimal lowerBound, decimal upperBound, int page)
    {
        var items = await _context.Avocados
            .Where(x => x.AveragePrice >= lowerBound)
            .Where(x => x.AveragePrice <= upperBound)
            .Pageable(page)
            .ToListAsync();

        return Ok(GenericResponse.Success(items));
    }
    
    [HttpGet("gt")]
    [SwaggerOperation(Description = "returns all the days where the average price is above the value")]
    public async Task<IActionResult> GreaterThen(decimal value, int page)
    {
        var items = await _context.Avocados
            .Where(x => x.AveragePrice >= value)
            .Pageable(page)
            .ToListAsync();
        return Ok(GenericResponse.Success(items));
    }
    
    [HttpGet("lt")]
    [SwaggerOperation(Description = "returns all the days where the average price is less than the value")]
    public async Task<IActionResult> LessThen(decimal value, int page)
    {
        var items = await _context.Avocados
            .Where(x => x.AveragePrice <= value)
            .Pageable(page)
            .ToListAsync();
        
        return Ok(GenericResponse.Success(items));
    }

}