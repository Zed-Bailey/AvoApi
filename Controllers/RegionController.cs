using AvoApi.Data;
using AvoApi.Data.Dto;
using AvoApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AvoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController : ControllerBase
{
    private AvocadoContext _context { get; }

    public RegionController(AvocadoContext context)
    {
        _context = context;
    }

    [HttpGet("regions")]
    [SwaggerOperation(Description = "returns all the distinct regions in the dataset")]
    public async Task<IActionResult> GetAllRegions()
    {
        var regionsDistinct = await _context.Avocados
            .Select(x => x.Region)
            .Distinct()
            .ToListAsync();

        return Ok(GenericResponse.Success(regionsDistinct));
    }

    [HttpGet("regions/{region}")]
    [SwaggerOperation(Description = "returns all results in the specified region")]
    public async Task<IActionResult> GetByRegionName(string region, int page)
    {
        var items = await _context.Avocados
            .Where(x => x.Region == region)
            .Pageable(page)
            .ToListAsync();
        
        return Ok(GenericResponse.Success(items));
    }
    
}