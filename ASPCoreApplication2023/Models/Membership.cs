namespace ASPCoreApplication2023.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public bool SignUpFree { get; set; }
        public int DurationInMonths { get; set; }
        public decimal DiscountRate { get; set; }

        // Propriété de navigation avec la table Customer
        public ICollection<Customer>? Customers { get; set; }
        public Membership() { }
    }
}
