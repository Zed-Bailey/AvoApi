using System.ComponentModel.DataAnnotations;

namespace AvoApi.Data.Models;

public class Avocado
{
    [Key]
    public int AvocadoId { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    [DataType(DataType.Currency)]
    public decimal AveragePrice { get; set; }

    public decimal TotalVolume { get; set; }

    /// <summary>
    /// Total number of avocados sold with price lookup code for small hass
    /// </summary>
    public decimal Plu4046 { get; set; }
    
    /// <summary>
    /// Total number of avocados sold with price lookup code for large hass
    /// </summary>
    public decimal Plu4225 { get; set; }
    
    /// <summary>
    /// Total number of avocados sold with price lookup code for extra large hass
    /// </summary>
    public decimal Plu4770 { get; set; }

    public decimal TotalBags { get; set; }
    public decimal SmallBags { get; set; }
    public decimal LargeBags { get; set; }
    public decimal ExtraLargeBags { get; set; }

    public string Type { get; set; }
    public int Year { get; set; }
    public string Region { get; set; }
    
}