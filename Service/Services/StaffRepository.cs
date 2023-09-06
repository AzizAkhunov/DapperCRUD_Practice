using Dapper;
using Domain.Entyties;
using Npgsql;


namespace Service.Services
{
    public class StaffRepository
    {
        public readonly string connectionString = "Server = localhost;Port=5432;User Id=postgres;Password = 56767655;Database=Companyy";
        public void Create(string firstName, string lastName, int staffId)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO public.\"Staffs\"(\"FirstName\", \"LastName\", \"StaffId\")VALUES ('{firstName}', '{lastName}', {staffId});";
                var result = db.Query<Employee>(sqlQuery);
            }
        }
        public string Update(int id, string firstName, string lastName, int staffId)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"UPDATE public.\"Staffs\" SET \"FirstName\"='{firstName}', \"LastName\"='{lastName}', \"StaffId\" = {staffId} WHERE \"Id\" = {id};";
                var result = db.Query<Employee>(sqlQuery);
                if (result != null)
                {
                    return "Updated";
                }
                else { return "Emlooyee not found"; }
            }
        }
        public string Delete(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM public.\"Staffs\" WHERE \"Id\" ={id};";
                var result = db.QueryFirstOrDefault<Employee>(sqlQuery);
                return "Emploee Deleted";
            }
        }
        public List<Employee> Get()
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Staffs\";";
                var result = db.Query<Employee>(sqlQuery).ToList();
                return result;
            }
        }
    }
}