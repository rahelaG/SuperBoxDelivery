namespace WebApplication1.Models;

public class Address
{
    public int Id { get; set; } 
    public string StreetName { get; private set; }
    public int StreetNumber { get; private set; }
    public string City { get; private set; }
    public int ZipCode { get; private set; }
    public ICollection<SuperBox> SuperBoxes { get; set; }
    public Address(string streetName, int streetNumber, string city, int zipCode)
    {
        StreetName = streetName;
        StreetNumber = streetNumber;
        City = city;
        ZipCode = zipCode;
    }
}