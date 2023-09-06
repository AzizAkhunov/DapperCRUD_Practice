using Domain.Entyties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;

namespace Companyyy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        public IStaffRepository staffRepository { get; set; }

        public StaffController(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateStaffDto staffDto)
        {
            await staffRepository.CreateAsync(staffDto);
            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await staffRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{staffId}")]
        public async Task<IActionResult> GetById(int staffId)
        {
            var result = await staffRepository.GetByIdAsync(staffId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany([FromForm] int staffId)
        {
            var result = await staffRepository.DeleteAsync(staffId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromForm] int staffId, [FromForm] CreateStaffDto staffDto)
        {
            var result = await staffRepository.UpdateAsync(staffId, staffDto);
            return Ok(result);
        }
    }
}
