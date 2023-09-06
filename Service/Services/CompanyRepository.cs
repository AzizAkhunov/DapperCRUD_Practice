using Dapper;
using Domain.Entyties;
using Npgsql;
using Service.Dto;

namespace Service.Services
{
    public class CompanyRepository
    {
        public static string connectionString = "Server = localhost;Port=5432;User Id=postgres;Password = password;Database=DapperPractics";
        public async Task CreateAsync(CreateCompanyDto companyDto)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"CREATE TABLE IF NOT EXISTS \"Company\" (\"Id\" Serial PRIMARY KEY NOT NULL,\"Name\" TEXT NOT NULL,\"StaffId\" INTEGER);";
                await db.ExecuteAsync(sqlQuery);

                sqlQuery = $"INSERT INTO public.\"Company\"(\"Name\")VALUES ('{companyDto.Name}');";
                await db.ExecuteAsync(sqlQuery);
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM public.\"Company\" WHERE \"Id\" ={id};";
                var result = await db.QueryFirstOrDefaultAsync<Employee>(sqlQuery);
                return "Deleted";

            }
        }

        public async Task<List<Company>> GetAllAsync()
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Company\";";
                var result = await db.QueryAsync<Company>(sqlQuery);
                return result.ToList();
            }
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Company\" WHERE \"Id\" = {id};";
                var result = await db.QueryFirstOrDefaultAsync<Company>(sqlQuery);
                return result;
            }
        }

        public async Task<string> UpdateAsync(int id, CreateCompanyDto companyDto)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"UPDATE public.\"Company\" SET \"Name\"=@Name WHERE \"Id\" = {id};";
                var result = await db.QueryAsync<Employee>(sqlQuery, companyDto);
                if (result != null)
                {
                    return "Updated";
                }
                else { return "didn`t updated"; }
            }
        }
    }
}
