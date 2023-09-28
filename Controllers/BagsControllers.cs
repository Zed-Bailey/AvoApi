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
public class BagsController: ControllerBase
{
    private AvocadoContext _context;

    public BagsController(AvocadoContext context)
    {
        _context = context;
    }

    [HttpGet("types")]
    [SwaggerOperation(Description = "Returns a string array of the supported bag types")]
    public string[] GetBagTypes()
    {
        return new string[]
        {
            "all", "sm",  "lg", "xl"
        };
    }

    [HttpGet("filter/{type}")]
    [SwaggerOperation(Description = "Filters all days by type of bag, min number of bags sold, and an optional max number of bags sold.")]
    public async Task<IActionResult> FilterByBagsSold(string type, decimal minValue, decimal? maxValue, int page = 0)
    {
        if (!GetBagTypes().Contains(type)) return BadRequest(GenericResponse.Error($"Invalid type '{type}'"));

        var items = _context.Avocados;
        
        var filtered = type switch
        { 
                "all" => items.Where(x => x.TotalBags >= minValue),
                "sm" => items.Where(x => x.SmallBags >= minValue),
                "lg" => items.Where(x => x.LargeBags >= minValue),
                "xl" => items.Where(x => x.ExtraLargeBags >= minValue),
        };

        if (maxValue != null)
        {
            filtered = type switch
            {
                "all" => filtered.Where(x => x.TotalBags <= maxValue),
                "sm" => filtered.Where(x => x.SmallBags <= maxValue),
                "lg" => filtered.Where(x => x.LargeBags <= maxValue),
                "xl" => filtered.Where(x => x.ExtraLargeBags <= maxValue),
            };
        }

        var list = await filtered.Pageable(page).ToListAsync();
        return Ok(GenericResponse.Success(list));

    }
    
}