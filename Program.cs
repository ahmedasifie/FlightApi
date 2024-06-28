
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using FlightApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FlightApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers()
                  .AddJsonOptions(options =>
                  {
                      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                  });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<FlightContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FlightPortal")));
            var app = builder.Build();

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
