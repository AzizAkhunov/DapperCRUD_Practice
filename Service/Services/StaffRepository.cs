using Dapper;
using Domain.Entyties;
using Npgsql;
using Service.Dto;
using Service.Interfaces;

namespace Service.Services
{
    public class StaffRepository : IStaffRepository
    {
        public static string connectionString = "Server = localhost;Port=5432;User Id=postgres;Password = 56767655;Database=Companyyy";
        public async Task CreateAsync(CreateStaffDto staffDto)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"CREATE TABLE IF NOT EXISTS \"Staff\" (\"Id\" Serial PRIMARY KEY NOT NULL,\"Name\" TEXT NOT NULL,\"StaffId\" INTEGER);";
                await db.ExecuteAsync(sqlQuery);

                sqlQuery = $"INSERT INTO public.\"Staff\"(\"Name\")VALUES ('{staffDto.Name}');";
                await db.ExecuteAsync(sqlQuery);
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM public.\"Staff\" WHERE \"Id\" ={id};";
                var result = await db.QueryFirstOrDefaultAsync<Staff>(sqlQuery);
                return "Deleted";

            }
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Staff\";";
                var result = await db.QueryAsync<Staff>(sqlQuery);
                return result.ToList();
            }
        }

        public async Task<Staff> GetByIdAsync(int id)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"Select * FROM public.\"Staff\" WHERE \"Id\" = {id};";
                var result = await db.QueryFirstOrDefaultAsync<Staff>(sqlQuery);
                return result;
            }
        }

        public async Task<string> UpdateAsync(int id, CreateStaffDto staffDto)
        {
            using (var db = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"UPDATE public.\"Staff\" SET \"Name\"=@Name WHERE \"Id\" = {id};";
                var result = await db.QueryAsync<Employee>(sqlQuery, staffDto);
                if (result != null)
                {
                    return "Updated";
                }
                else { return "didn`t updated"; }
            }
        }
    }
}