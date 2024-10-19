
using Api.Controllers;
using DataBase.Entities;
using DataBase.Repositories;
using Domain.DTOModels.Insurance;
using Domain.DTOModels.MedCard;
using Domain.DTOModels.Patient;
using Domain.Services;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataBase.Context>();



            builder.Services.AddScoped<DataBase.Repositories.Interfaces.IDefaultRepository<MedCard>, MedCardRepository>();
            builder.Services.AddScoped<DataBase.Repositories.Interfaces.IMedCardRepository, MedCardRepository>();
            builder.Services.AddScoped<MedCardRepository>();
            builder.Services.AddScoped<Domain.Services.Interfaces.IDefaultService<MedCardDTORequestPost, MedCardDTOResponse>, MedCardService>();
            builder.Services.AddScoped<Domain.Services.Interfaces.IMedCardService, MedCardService>();
            builder.Services.AddScoped<MedCardService>();

            builder.Services.AddScoped<DataBase.Repositories.Interfaces.IDefaultRepository<InsurancePolicy>, InsurancePolicyRepository>();
            builder.Services.AddScoped<DataBase.Repositories.Interfaces.IInsuraceRepository, InsurancePolicyRepository>();
            builder.Services.AddScoped<InsurancePolicyRepository>();
            builder.Services.AddScoped<Domain.Services.Interfaces.IDefaultService<InsurancePolicyDTORequest, InsurancePolicyDTOResponse>, InsurancePolicyService>();
            builder.Services.AddScoped<Domain.Services.Interfaces.IInsurancePolicyService, InsurancePolicyService>();
            builder.Services.AddScoped<InsurancePolicyService>();

            builder.Services.AddScoped<DataBase.Repositories.Interfaces.IDefaultRepository<Patient>, PatientRepostiory>();
            builder.Services.AddScoped<DataBase.Repositories.Interfaces.IPatientRepository, PatientRepostiory>();
            builder.Services.AddScoped<PatientRepostiory>();
            builder.Services.AddScoped<Domain.Services.Interfaces.IDefaultService<PatientDTORequest, PatientDTOResponse>, PatientService>();
            builder.Services.AddScoped<Domain.Services.Interfaces.IPatientService, PatientService>();
            builder.Services.AddScoped<PatientService>();

            //builder.Services.AddScoped<Controllers.Interfaces.IDefaultController<PatientDTORequest>, PatientController>();


            var app = builder.Build();

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
        }
    }
}
