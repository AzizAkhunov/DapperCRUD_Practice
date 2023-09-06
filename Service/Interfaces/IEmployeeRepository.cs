using Domain.Entyties;
using Service.Dto;

namespace Service.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task CreateAsync(CreateEmployeeDto employeeDto);
        public Task<string> UpdateAsync(int id, CreateEmployeeDto employeeDto);
        public Task<string> DeleteAsync(int id);
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(int id);
    }
}
