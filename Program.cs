
using AFI.Data;
using AFI.Repositories.IRepository;
using AFI.Repositories;
using AFI.UoW;
using Microsoft.EntityFrameworkCore;
using AFI.Dtos;

namespace AFI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<ApiContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                    sqlServerOptions => sqlServerOptions.CommandTimeout(300));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            }, ServiceLifetime.Scoped);

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<CustomerForCreationDtoValidator>();


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
