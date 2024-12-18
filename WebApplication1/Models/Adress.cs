namespace WebApplication1.Models;

public class Adress
{
    protected string StreetName { get; set; }
    protected int StreetNumber { get; set; }
    protected string City { get; set; }
    protected int ZipCode { get; set; }

    public Adress(string streetName, int streetNumber, string city, int zipCode)
    {
        StreetName = streetName;
        StreetNumber = streetNumber;
        City = city;
        ZipCode = zipCode;
    }
}