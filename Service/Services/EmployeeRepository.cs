using Dapper;
using Domain.Entyties;
using Npgsql;


namespace Service.Services
{
    public class EmployeeRepository
    {
        public static string connectionString = "Server = localhost;Port=5432;User Id=postgres;Password = password;Database=DapperPractics";
        public void Create(string firstName, string lastName, int employeeId)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO public.\"Employees\"(\"FirstName\", \"LastName\", \"StaffId\")VALUES ('{firstName}', '{lastName}', {employeeId});";
                var result = db.Query<Employee>(sqlQuery);
            }
        }
        public string Update(int id, string firstName, string lastName, int employeeId)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"UPDATE public.\"Employees\" SET \"FirstName\"='{firstName}', \"LastName\"='{lastName}', \"StaffId\" = {employeeId} WHERE \"Id\" = {id};";
                var result = db.Query<Employee>(sqlQuery);
                if (result != null)
                {
                    return "Emploee Updated";
                }
                else { return "Sommeting wrong\nEmploee didn`t updated"; }
            }
        }
        public string Delete(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM public.\"Employees\" WHERE \"Id\" ={id};";
                var result = db.QueryFirstOrDefault<Employee>(sqlQuery);
                return "Emploee Deleted";
            }
        }
        public List<Employee> Get()
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Employees\";";
                var result = db.Query<Employee>(sqlQuery).ToList();
                return result;
            }
        }
    }
}