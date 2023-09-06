using Dapper;
using Domain.Entyties;
using Npgsql;
using Service.Dto;
using Service.Interfaces;

namespace Service.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static string connectionString = "Server = localhost;Port=5432;User Id=postgres;Password = 56767655;Database=Companyyy";
        public async Task CreateAsync(CreateEmployeeDto employeeDto)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"CREATE TABLE IF NOT EXISTS \"Employee\" (\"Id\" Serial PRIMARY KEY NOT NULL,\"Name\" TEXT NOT NULL,\"StaffId\" INTEGER);";
                await db.ExecuteAsync(sqlQuery);

                sqlQuery = $"INSERT INTO public.\"Employee\"(\"Name\")VALUES ('{employeeDto.FirstName},{employeeDto.LastName},{employeeDto.Phone},{employeeDto.Email}');";
                await db.ExecuteAsync(sqlQuery);
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM public.\"Employee\" WHERE \"Id\" ={id};";
                var result = await db.QueryFirstOrDefaultAsync<Employee>(sqlQuery);
                return "Deleted";

            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Employee\";";
                var result = await db.QueryAsync<Employee>(sqlQuery);
                return result.ToList();
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Employee\" WHERE \"Id\" = {id};";
                var result = await db.QueryFirstOrDefaultAsync<Employee>(sqlQuery);
                return result;
            }
        }

        public async Task<string> UpdateAsync(int id, CreateEmployeeDto employeeDto)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"UPDATE public.\"Employee\" SET \"Name\"=@Name WHERE \"Id\" = {id};";
                var result = await db.QueryAsync<Employee>(sqlQuery, employeeDto);
                if (result != null)
                {
                    return "Updated";
                }
                else { return "didn`t updated"; }
            }
        }
    }
}