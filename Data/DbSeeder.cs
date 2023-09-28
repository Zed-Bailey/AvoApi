using System.Globalization;
using AvoApi.Data.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore;

namespace AvoApi.Data;

public class DbSeeder
{
    /// <summary>
    /// Seeds the Db
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static async Task SeedDb(AvocadoContext context, string dataFilePath)
    {
        // records already exist in the db so dont seed
        if (await context.Avocados.AnyAsync())
        {
            return;
        }

        // load
        using var reader = new StreamReader(dataFilePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        
        csv.Context.RegisterClassMap<AvocadoCsvClassMap>();
        
        var records = csv.GetRecords<Avocado>();
        // throw if no records loaded
        if (records == null || !records.Any()) throw new Exception("No records read from the csv file!");

        await context.Avocados.AddRangeAsync(records);
        await context.SaveChangesAsync();

    }
}