using System.ComponentModel;
using AvoApi.Data;
using AvoApi.Data.Dto;
using AvoApi.Data.Models;
using AvoApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AvoApi.Controllers;

[ApiController]
[Route("/")]
public class AvocadoController: ControllerBase
{
    private AvocadoContext _context { get; set; }

    public AvocadoController(AvocadoContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Returns the avocado with the corresponding id
    /// </summary>
    [HttpGet("{id}")]
    [SwaggerOperation(Description = "Returns the avocado model with the corresponding id")]
    public async Task<IActionResult> GetById(int id)
    {
        var avo = await _context.Avocados.FindAsync(id);
        return avo != null ? Ok(avo) : BadRequest(GenericResponse.Error("Id does not exist"));
    }

    [HttpGet("page")]
    [SwaggerOperation(Description = "Gets a page of results")]
    public async Task<IActionResult> GetPage(int page = 0)
    {
        if (page < 0) return BadRequest(GenericResponse.Error("page has to be greater than 0"));
        
        var items = await _context.Avocados
            .Pageable(page)
            .ToListAsync();
        
        return Ok(GenericResponse.Success(items));
    }
    
}