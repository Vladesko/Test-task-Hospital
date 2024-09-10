using Hospitals.Application.Interfaces.DoctorsIntrfaces;
using Hospitals.WebApi.Common.Interfaces;
using Hospitals.WebApi.Models.Doctors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospitals.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController(IDoctorService service,
                                    IDoctorMapper mapper) : ControllerBase
    {
        private readonly IDoctorService service = service;
        private readonly IDoctorMapper mapper = mapper;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(Guid id, CancellationToken token)
        {
            var result = await service.GetDoctorAsync(id, token);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors([FromQuery] GetDoctorsDto dto, CancellationToken token)
        {
            var result = await service.GetDoctorsAsync(mapper.MapWith(dto), token);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto dto, CancellationToken token)
        {
            var result = await service.CreateDoctorAsync(mapper.MapWith(dto), token);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            await service.DeleteDoctorAsync(id, token);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorDto dto, CancellationToken token)
        {
            await service.UpdateDoctorAsync(mapper.MapWith(dto), token);
            return NoContent();
        }
    }
}
