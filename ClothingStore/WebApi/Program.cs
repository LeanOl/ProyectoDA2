using WebApi.Filters;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<AuthenticationFilter>();
            var servicesFactory = new ServicesFactory.ServicesFactory();
            servicesFactory.RegistrateServices(builder.Services);
            

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}