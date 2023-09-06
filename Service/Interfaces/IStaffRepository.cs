using Domain.Entyties;
using Service.Dto;

namespace Service.Interfaces
{
    public interface IStaffRepository
    {
        public Task CreateAsync(CreateStaffDto staffDto);
        public Task<string> UpdateAsync(int id, CreateStaffDto staffDto);
        public Task<string> DeleteAsync(int id);
        public Task<List<Staff>> GetAllAsync();
        public Task<Staff> GetByIdAsync(int id);
    }
}
