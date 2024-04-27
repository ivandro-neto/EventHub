using EventHub.API.Filters;
using EventHub.Application.Repositories;
using EventHub.Application.UseCases;
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
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<ICheckInRepository, CheckInRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Add Use Cases
            //Events Use Cases
            builder.Services.AddScoped<GetAllEventsUseCase>();
            builder.Services.AddScoped<GetEventByIdUseCase>();
            builder.Services.AddScoped<RegisterEventUseCase>();
            builder.Services.AddScoped<UpdateEventUseCase>();
            builder.Services.AddScoped<DeleteEventUseCase>();
            builder.Services.AddScoped<AttendeeRegisterUseCase>();
            builder.Services.AddScoped<AddCategoryToEventUseCase>();
            builder.Services.AddScoped<RemoveCategoryFromEventUseCase>();
            //Accounts Use Cases
            builder.Services.AddScoped<GetAllAccountsUseCase>();
            builder.Services.AddScoped<AccountRegisterUseCase>();

            //Checkins Use Cases
            builder.Services.AddScoped<GetCheckInByIdUseCase>();
            builder.Services.AddScoped<RemoveCheckInUseCase>();


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("EventHubDBConnectionString");

            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
            /*builder.Services.AddDbContext<EventHubDBContext>(option => option.UseSqlServer(connectionString, options =>
            {
                options.CommandTimeout(120); // Define o tempo limite para 120 segundos (2 minutos)
            }));*/
            builder.Services.AddDbContext<EventHubDBContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(c => {
                    c.RouteTemplate = "api-docs/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/api-docs/v1/swagger.json", "EventHub API V1");
                    c.RoutePrefix = "api-docs";
                });

            }

            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapGet("/", () => Results.File("index.html", "text/html"));

            app.MapControllers();

            app.Run();
        }
    }
}
