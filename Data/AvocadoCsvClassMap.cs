using AvoApi.Data.Models;
using CsvHelper.Configuration;

namespace AvoApi.Data;

/// <summary>
/// Maps the Csv columns to the Avocado model properties
/// </summary>
public class AvocadoCsvClassMap : ClassMap<Avocado>
{
    public AvocadoCsvClassMap()
    {
        Map(m => m.Date).Name("Date");
        Map(m => m.AveragePrice).Name("AveragePrice");
        Map(m => m.TotalVolume).Name("Total Volume");
        Map(m => m.Plu4046).Name("4046");
        Map(m => m.Plu4225).Name("4225");
        Map(m => m.Plu4770).Name("4770");
        Map(m => m.TotalBags).Name("Total Bags");
        Map(m => m.SmallBags).Name("Small Bags");
        Map(m => m.LargeBags).Name("Large Bags");
        Map(m => m.ExtraLargeBags).Name("XLarge Bags");
        Map(m => m.Type).Name("type");
        Map(m => m.Year).Name("year");
        Map(m => m.Region).Name("region");

    }
}