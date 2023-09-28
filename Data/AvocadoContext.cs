using AvoApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AvoApi.Data;

public class AvocadoContext : DbContext
{
    public DbSet<Avocado> Avocados { get; set; }
    public AvocadoContext(DbContextOptions<AvocadoContext> options) : base(options)
    { }

}