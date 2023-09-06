namespace Domain.Entyties
{
    public class Staff
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
