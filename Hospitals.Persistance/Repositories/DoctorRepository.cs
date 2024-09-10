using Hospitals.Application.Interfaces.DoctorsIntrfaces;
using Hospitals.Application.Models.Doctors;
using Hospitals.Application.Models.Patients;
using Hospitals.Domain.Models;
using Hospitals.Persistance.Common.Exceptions;
using Hospitals.Persistance.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hospitals.Persistance.Repositories
{
    internal class DoctorRepository(HospitalsDbContext context) : IDoctorRepository
    {
        private readonly HospitalsDbContext context = context;

        public async Task<Guid> CreateDoctorAsync(CreateDoctorsViewModel model, CancellationToken token)
        {
            var specialisation = await context.Specialisations.
                FirstOrDefaultAsync(x => x.Name == model.Specialisation, token)
                ?? throw new NotFoundException("This specialisation was not found");

            var cabinet = await context.Cabinets.
                FirstOrDefaultAsync(x => x.Number == model.Cabinet, token)
                ?? throw new NotFoundException("This cabinet was not found");


            var doctor = new Doctor()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Cabinet = cabinet,
                Specialisation = specialisation
            };

            await context.Doctors.AddAsync(doctor, token);

            await context.SaveChangesAsync(token);

            return doctor.Id;
        }

        public async Task DeleteDoctorAsync(Guid id, CancellationToken token)
        {
            var result = await context.Doctors.
                Where(x => x.Id == id).
                ExecuteDeleteAsync(token);
            if(result == 0)
                throw new NotFoundException($"Doctor with Id: {id} not found");
        }

        public async Task<Doctor> GetDoctorAsync(Guid id, CancellationToken token)
        {
            var doctor = await context.Doctors.
                AsNoTracking().
                Include(d => d.Cabinet).
                Include(d => d.Specialisation).
                FirstOrDefaultAsync(d => d.Id == id, token) 
                ?? throw new NotFoundException($"Doctor with Id: {id} not found");                

            return doctor;
        }

        public async Task UpdateDoctorAsync(UpdateDoctorsViewModel model, CancellationToken token)
        {
            var doctor = await context.Doctors.
                FirstOrDefaultAsync(d => d.Id == model.Id, token) 
                ?? throw new NotFoundException($"Doctor with Id: {model.Id} not found");

            var specialisation = await context.Specialisations.
                 FirstOrDefaultAsync(x => x.Name == model.Specialisation)
                 ?? throw new NotFoundException("This specialisation was not found");

            var cabinet = await context.Cabinets.
                FirstOrDefaultAsync(x => x.Number == model.Cabinet)
                ?? throw new NotFoundException("This cabinet was not found");

            doctor.Cabinet = cabinet;
            doctor.Name = model.Name;
            doctor.Specialisation = specialisation;

            await context.SaveChangesAsync(token);
        }
        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(GetDoctorsViewModelQuery query, CancellationToken token)
        {
            ValidateQuery(query);

            var doctors = await context.Doctors.
                Skip(query.StartPosition).
                Take(query.Size).
                ToArrayAsync(token);

            var result = SortDoctors(doctors, query.PropertyName);

            return result;
        }
        private void ValidateQuery(GetDoctorsViewModelQuery query)
        {
            if (query.StartPosition + query.Size > context.Patients.Count())
                throw new WrongQueryException("Size or start position is very high");
            if (query.Size <= 0 || query.StartPosition < 0)
                throw new WrongQueryException("Size or start position can not be 0");
        }
        private Doctor[] SortDoctors(Doctor[] doctors, string property)
        {
            PropertyInfo propertyInfo = typeof(Doctor).GetProperty(property);
            if (propertyInfo == null)
                throw new WrongQueryException("There's no such thing");

            var result = doctors.OrderBy(p => propertyInfo.GetValue(p)).
                ToArray();

            return result;
        }
    }
}
