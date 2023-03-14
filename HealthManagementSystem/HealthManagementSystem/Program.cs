using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Application.Services;
using Management.Data.Context;
using Management.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Sql connection
builder.Services.AddDbContext<HealthManagementDbContext>(
        o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
    );


// Dependencies injection
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IMedicationService, MedicationService>();

builder.Services.AddScoped<IAllergyPersonRepository, AllergyPersonRepository>();
builder.Services.AddScoped<IAllergyPersonService, AllergyPersonService>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<IPhoneNumberCountryCodeRepository, PhoneNumberCountryCodeRepository>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IMedicalPracticeRepository, MedicalPracticeRepository>();

builder.Services.AddScoped<IFamilyDoctorRepository, FamilyDoctorRepository>();
builder.Services.AddScoped<IFamilyDoctorService, FamilyDoctorService>();

builder.Services.AddScoped<IMedicationPersonRepository, MedicationPersonRepository>();
builder.Services.AddScoped<IMedicationPersonService, MedicationPersonService>();

builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();

builder.Services.AddScoped<IIllnessPersonRepository, IllnessPersonRepository>();
builder.Services.AddScoped<IIllnessPersonService, IllnessPersonService>();

builder.Services.AddScoped<IIllnessRepository, IllnessRepository>();

builder.Services.AddScoped<IVaccinationPersonRepository, VaccinationPersonRepository>();
builder.Services.AddScoped<IVaccinationPersonService, VaccinationPersonService>();

builder.Services.AddScoped<IVaccinationRepository, VaccinationRepository>();

builder.Services.AddScoped<ILabResultRepository, LabResultRepository>();
builder.Services.AddScoped<ILabResultService, LabResultService>();

builder.Services.AddScoped<ILabResultStatusRepository, LabResultStatusRepository>();

builder.Services.AddScoped<ILabResultStatusLabResultsRepository, LabResultStatusLabResultsRepository>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
