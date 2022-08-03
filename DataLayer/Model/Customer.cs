namespace DataLayer.Model
{
    public class CustomerData
    {
        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Phone { get; set; } = default!;
    }

    public sealed class Customer : CustomerData
    {
        public int Id { get; set; }
    }
}