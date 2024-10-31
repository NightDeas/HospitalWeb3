using DataBase.Entities;
using DataBase.Operations;
using DataBase;
using HospitalWeb.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Radzen;
using MudBlazor;
using HospitalWeb.Components.Services;
using HospitalWeb.Components.Interfaces;
using HospitalWeb.Components.Services.Api;
using DataBase.Repositories.Interfaces;
using Domain.Services;
using Api.Controllers.Interfaces;
using Domain.DTOModels.Hospitalization;
using Api.Controllers;

namespace HospitalWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMudServices();
            builder.Services.AddRadzenComponents();
            builder.Services.AddScoped<IDialogService, MudBlazor.DialogService>();
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("spek"));
            });
            //builder.Services.AddScoped<Context>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<HttpContextAccessor>();
            builder.Services.AddScoped<CookiesService>();
            builder.Services.AddScoped<PatientOperationService>();
            builder.Services.AddScoped<DataBase.Operations.IDefaultOperationDbEntity<Patient>, PatientOperationService>();
            builder.Services.AddScoped<DataBase.Operations.IDefaultOperationDbEntity<MedCard>, MedCardOperationService>();
            builder.Services.AddScoped<DataBase.Operations.IDefaultOperationDbEntity<Genre>, GenreOperationService>();
            builder.Services.AddScoped<DataBase.Operations.IDefaultOperationDbEntity<InsurancePolicy>, InsuranceOperationService>();
            builder.Services.AddScoped<DataBase.Operations.IPatientDataOperation<InsurancePolicy>, InsuranceOperationService>();
            builder.Services.AddScoped<DataBase.Operations.IPatientDataOperation<MedCard>, MedCardOperationService>();
            builder.Services.AddScoped<IPhotoService, PhotoService>();


            

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<PatientApiService>();
            builder.Services.AddScoped<MedCardApiService>();
            builder.Services.AddScoped<InsurancePolicyApiService>();
            builder.Services.AddScoped<HospitalizationApiService>();

            //builder.Services.AddSingleton<HospitalWeb.Components.Services.Notification.NotificationService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
