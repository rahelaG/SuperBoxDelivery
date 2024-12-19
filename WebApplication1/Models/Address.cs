namespace WebApplication1.Models;

public class Address
{
    protected string StreetName { get; set; }
    protected int StreetNumber { get; set; }
    protected string City { get; set; }
    protected int ZipCode { get; set; }

    public Address(string streetName, int streetNumber, string city, int zipCode)
    {
        StreetName = streetName;
        StreetNumber = streetNumber;
        City = city;
        ZipCode = zipCode;
    }
}