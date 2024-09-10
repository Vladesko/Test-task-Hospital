using Hospitals.Application.Interfaces.PatientsInterface;
using Hospitals.WebApi.Common.Interfaces;
using Hospitals.WebApi.Models.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospitals.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController(IPatientService service,
                                    IPatientMapper mapper) : ControllerBase
    {
        private readonly IPatientService service = service;
        private readonly IPatientMapper mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] GetPatientsDto dto, CancellationToken token)
        {
            var result = await service.GetPatientsAsync(mapper.MapWith(dto), token);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id, CancellationToken token)
        {
            var result = await service.GetPatientAsync(id, token);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientsDto dto, CancellationToken token)
        {
            var result = await service.CreatePatientAsync(mapper.MapWith(dto), token);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePatientDto dto, CancellationToken token)
        {
            await service.UpdatePatientAsync(mapper.MapWith(dto), token);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            await service.DeletePatientAsync(id, token);
            return NoContent();
        }
    }
}
