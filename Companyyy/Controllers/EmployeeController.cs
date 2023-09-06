using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;

namespace Companyyy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeRepository employeeRepository { get; set; }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDto companyDto)
        {
            await employeeRepository.CreateAsync(companyDto);
            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await employeeRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await employeeRepository.GetByIdAsync(employeeId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany([FromForm] int employeeId)
        {
            var result = await employeeRepository.DeleteAsync(employeeId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromForm] int employeeId, [FromForm] CreateEmployeeDto employeeDto)
        {
            var result = await employeeRepository.UpdateAsync(employeeId, employeeDto);
            return Ok(result);
        }
    }
}
