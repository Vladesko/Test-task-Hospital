using Hospitals.Application.Interfaces.DoctorsIntrfaces;
using Hospitals.Application.Models.Doctors;
using Hospitals.Domain.Models;

namespace Hospitals.Application.Services
{
    internal class DoctorService(IDoctorRepository repository) : IDoctorService
    {
        private readonly IDoctorRepository repository = repository;

        public Task<Guid> CreateDoctorAsync(CreateDoctorsViewModel model, CancellationToken token)
        {
            var result = repository.CreateDoctorAsync(model, token);
            return result;
        }

        public async Task DeleteDoctorAsync(Guid id, CancellationToken token)
        {
            await repository.DeleteDoctorAsync(id, token);
        }

        public async Task<GetDoctorViewModelResult> GetDoctorAsync(Guid id, CancellationToken token)
        {
            var doctor = await repository.GetDoctorAsync(id, token);

            var model = new GetDoctorViewModelResult()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                NameOfSpecialisation = doctor.Specialisation.Name,
                NumberOfCabinet = doctor.Cabinet.Number,
            };

            return model;
        }

        public async Task UpdateDoctorAsync(UpdateDoctorsViewModel model, CancellationToken token)
        {
            await repository.UpdateDoctorAsync(model, token);
        }
        public async Task<IEnumerable<GetDoctorsViewModelResult>> GetDoctorsAsync(GetDoctorsViewModelQuery query, CancellationToken token)
        {
            var doctors = await repository.GetDoctorsAsync(query, token);

            var models = doctors.Select(x =>
                new GetDoctorsViewModelResult()
                {
                    Id = x.Id,
                    Name = x.Name,
                }
                ).
                ToArray();
            
            return models;
        }
    }
}
