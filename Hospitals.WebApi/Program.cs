using Hospitals.Application.Common;
using Hospitals.Persistance.Common;
using Hospitals.WebApi.Common.Interfaces;
using Hospitals.WebApi.Common.Mapping;
using Hospitals.WebApi.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);

builder.Services.AddScoped<IDoctorMapper, DoctorMapper>();
builder.Services.AddScoped<IPatientMapper, PatientMapper>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
