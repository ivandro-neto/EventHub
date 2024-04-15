
using EventHub.Application.Repositories.Accounts;
using EventHub.Application.Repositories.Events;
using EventHub.Application.UseCases.Accounts;
using EventHub.Application.UseCases.Accounts.Register;
using EventHub.Application.UseCases.Events;
using EventHub.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EventHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configuring Repositories and Database context dependency
            builder.Services.AddScoped<IEventRepository, EventRepository>();

            //Add Use Cases
            builder.Services.AddScoped<RegisterEventUseCase>();
            builder.Services.AddScoped<GetAllEventsUseCase>();
            builder.Services.AddScoped<GetEventByIdUseCase>();
            builder.Services.AddScoped<RegisterAttendeeUseCase>();

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<GetAllAccountsUseCase>();
            builder.Services.AddScoped<AccountRegisterUseCase>();


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("EventHubDBConnectionString");
            
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            
            
            builder.Services.AddDbContext<EventHubDBContext>(option => option.UseSqlServer(connectionString, options =>
            {
                options.CommandTimeout(120); // Define o tempo limite para 120 segundos (2 minutos)
            }));
            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
