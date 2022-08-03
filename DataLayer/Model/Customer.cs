namespace DataLayer.Model
{
    public class CustomerData
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }

    public sealed class Customer : CustomerData
    {
        public int Id { get; set; }
    }
}