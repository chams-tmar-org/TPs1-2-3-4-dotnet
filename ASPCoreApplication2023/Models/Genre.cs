namespace ASPCoreApplication2023.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? GenreName { get; set; }

        // On ajoute la propriété de navigation pour représenter la relation
        public ICollection<Movie>? Movies { get; set; }

    }
}
