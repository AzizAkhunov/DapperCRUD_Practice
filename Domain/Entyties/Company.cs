namespace Domain.Entyties
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
