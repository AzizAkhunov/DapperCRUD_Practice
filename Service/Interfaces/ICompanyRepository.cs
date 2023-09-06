using Domain.Entyties;
using Service.Dto;

namespace Service.Interfaces
{
    public interface ICompanyRepository
    {
        public Task CreateAsync(CreateCompanyDto companyDto);
        public Task<string> UpdateAsync(int id, CreateCompanyDto companyDto);
        public Task<string> DeleteAsync(int id);
        public Task<List<Company>> GetAllAsync();
        public Task<Company> GetByIdAsync(int id);

    }
}