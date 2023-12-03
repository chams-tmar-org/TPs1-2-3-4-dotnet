using ASPCoreApplication2023.Models;

public class Movie
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Genre? Genre { get; set; }
    public DateTime DateAdded { get; set; }
    public string? ImagePath { get; set; }

    // Propriétés de navigation
    public ICollection<Customer>? Customers { get; set; }
}

