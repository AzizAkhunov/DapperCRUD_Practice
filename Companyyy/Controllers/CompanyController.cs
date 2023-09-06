using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;

namespace H_M_4_sep__2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public ICompanyRepository companyRepository { get; set; }

        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyDto companyDto)
        {
            await companyRepository.CreateAsync(companyDto);
            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await companyRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetById(int companyId)
        {
            var result = await companyRepository.GetByIdAsync(companyId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany([FromForm] int companyId)
        {
            var result = await companyRepository.DeleteAsync(companyId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromForm] int companyId, [FromForm] CreateCompanyDto companyDto)
        {
            var result = await companyRepository.UpdateAsync(companyId, companyDto);
            return Ok(result);
        }
    }
}
