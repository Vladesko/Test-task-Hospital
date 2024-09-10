using Hospitals.Application.Interfaces.PatientsInterface;
using Hospitals.Application.Models.Doctors;
using Hospitals.Application.Models.Patients;

namespace Hospitals.Application.Services
{
    internal class PatientService(IPatientRepository repository) : IPatientService
    {
        private readonly IPatientRepository repository = repository;
        public async Task<Guid> CreatePatientAsync(CreatePatientsViewModel model, CancellationToken token)
        {
            var result = await repository.CreatePatientAsync(model, token);
            return result;
        }

        public async Task DeletePatientAsync(Guid id, CancellationToken token)
        {
            await repository.DeletePatientAsync(id, token);
        }

        public async Task<GetPatientViewModelResult> GetPatientAsync(Guid id, CancellationToken token)
        {
            var patient = await repository.GetPatientAsync(id, token);
            var model = new GetPatientViewModelResult()
            {
                Id = patient.Id,
                Adress = patient.Adress,
                Birthday = patient.BirthDay,
                Gender = patient.Gender,
                Name = patient.Name,
                NumberOfSection = patient.Section.Number,
            };
            return model;
        }

        public async Task<IEnumerable<GetPatientsViewModelResult>> GetPatientsAsync(GetPatientsViewModelQuery query, CancellationToken token)
        {
            var patients = await repository.GetPatientsAsync(query, token);
            var models = patients.
                Select(x => 
                new GetPatientsViewModelResult() 
                {
                    Id = x.Id,
                    Name = x.Name
                }).
                ToArray();

            return models;
        }

        public async Task UpdatePatientAsync(UpdatePatientsViewModel model, CancellationToken token)
        {
            await repository.UpdatePatientAsync(model, token);
        }
    }
}
