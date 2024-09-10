using Hospitals.Application.Interfaces.PatientsInterface;
using Hospitals.Application.Models.Patients;
using Hospitals.Domain.Models;
using Hospitals.Persistance.Common.Exceptions;
using Hospitals.Persistance.Database;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;

namespace Hospitals.Persistance.Repositories
{
    internal class PatientRepository(HospitalsDbContext context) : IPatientRepository
    {
        private readonly HospitalsDbContext context = context;
        public async Task<Guid> CreatePatientAsync(CreatePatientsViewModel model, CancellationToken token)
        {
            var section = await context.Sections.
                FirstOrDefaultAsync(s => s.Number == model.Section, token) ??
                throw new NotFoundException("Section with this number was not found");

            var patient = new Patient() 
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Section = section,
                Adress = model.Adress,
                BirthDay = model.BirthDay,
                Gender = model.Gender
            };

            await context.Patients.AddAsync(patient, token);
            await context.SaveChangesAsync(token);

            return patient.Id;
        }

        public async Task DeletePatientAsync(Guid id, CancellationToken token)
        {
            var result = await context.Patients.
                Where(x => x.Id == id).
                ExecuteDeleteAsync(token);

            if (result == 0)
                throw new NotFoundException($"Patients with Id: {id} not found");
        }

        public async Task<Patient> GetPatientAsync(Guid id, CancellationToken token)
        {
            var patient = await context.Patients.
                AsNoTracking().
                Include(p => p.Section).
                FirstOrDefaultAsync(p => p.Id == id, token)
                ?? throw new NotFoundException("Doctor with this Id: {id} was not found");

            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(GetPatientsViewModelQuery query, CancellationToken token)
        {
            ValidateQuery(query);

            var patients = await context.Patients.
                Skip(query.StartPosition).
                Take(query.Size).
                ToArrayAsync(token);

            var result = SortPatients(patients, query.PropertyName);

            return result;
        }

        public async Task UpdatePatientAsync(UpdatePatientsViewModel model, CancellationToken token)
        {
            var patinet = await context.Patients.FirstOrDefaultAsync(p => p.Id == model.Id, token) ??
                throw new NotFoundException($"Patient with Id: {model.Id} was not found");

            var section = await context.Sections.FirstOrDefaultAsync(s => s.Number == model.Section, token) ??
                throw new NotFoundException("Section with this number was not found");

            patinet.BirthDay = model.BirthDay;
            patinet.Adress = model.Adress;
            patinet.Gender = model.Gender;
            patinet.Name = model.Name;
            patinet.Section = section;

            await context.SaveChangesAsync(token);
        }
        private void ValidateQuery(GetPatientsViewModelQuery query)
        {
            if (query.StartPosition + query.Size > context.Patients.Count())
                throw new WrongQueryException("Size or start position is very high");
            if (query.Size <= 0 || query.StartPosition < 0)
                throw new WrongQueryException("Size or start position can not be 0");
        }
        private Patient[] SortPatients(Patient[] patients, string property)
        {
            PropertyInfo propertyInfo = typeof(Patient).GetProperty(property);
            if (propertyInfo == null)
                throw new WrongQueryException("There's no such thing");

            var result = patients.OrderBy(p => propertyInfo.GetValue(p)).
                ToArray();

            return result;
        }
    }
}
