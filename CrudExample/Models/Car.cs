namespace CrudExample.Models;

public class Car
{
    public string Guid { get; set; } = new Guid().ToString();
    public int year { get; set; }
    public string Name { get; set; }
    public double Mpg { get; set; }
}