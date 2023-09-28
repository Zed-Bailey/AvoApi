using AvoApi.Data;
using AvoApi.Data.Dto;
using AvoApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AvoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VolumeController : ControllerBase
{

    private AvocadoContext _context;

    public VolumeController(AvocadoContext context)
    {
        _context = context;
    }

    [HttpGet("types")]
    [SwaggerOperation(Description = "returns the supported PLU types for avocado and an 'all' option to filter by all types")]
    public string[] GetTypes()
    {
        return new[]
        {
            "all", "4046", "4225", "4770"
        };
    }

    [HttpGet("filter/{type}")]
    [SwaggerOperation(Description = "return all days where the volume sold is above the specified value for the PLU type." +
                                    " if all is passed in then it will select all days where the total volume sold is above the value")
    ]
    public async Task<IActionResult> FilterByVolume(string type, decimal vol, int page = 0)
    {
        if (!GetTypes().Contains(type))
        {
            return BadRequest(GenericResponse.Error($"invalid type {type}"));
        }

        var items = _context.Avocados;

        var filtered = type switch
        {
            "all" => items.Where(x => x.TotalVolume > vol),
            "4046" => items.Where(x => x.Plu4046 > vol),
            "4225" => items.Where(x => x.Plu4225 > vol),
            "4770" => items.Where(x => x.Plu4770 > vol),
        };
        var list = await filtered.Pageable(page).ToListAsync();

        return Ok(GenericResponse.Success(list));
    }
}