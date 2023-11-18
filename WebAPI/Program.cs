using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<InstallationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
                options.EnableSensitiveDataLogging();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                seed(services);
            }


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

        private static void seed(IServiceProvider serviceProvider)
        {
            using var context = new InstallationContext(serviceProvider.GetRequiredService<
                DbContextOptions<InstallationContext>>());

            var created = context.Database.EnsureCreated();
            if (created)
            {

                var installation1 = new Installation() { Description = "La super éolienne de Damien", Image = "hi", Street = "Route de Verbier", No = "128", PostCode = 1936, City = "Verbier", CoordinateX = 583006.9, CoordinateY = 104677.4, AzimutOrientation = 30, TiltOrientation = 40, EnergyType = "eolien", IntegrationType = "ajoutee", CellsType = "mono", Length = 24, Width = 145 };
                var installation2 = new Installation() { Description = "La super centrale solaire de Rebecca", Image = "yo", Street = "Chemin des Noyerets", No = "17", PostCode = 1960, City = "Sierre", CoordinateX = 607402.5, CoordinateY = 127248.5, AzimutOrientation = 40, TiltOrientation = 30, EnergyType = "solaire", IntegrationType = "ajoutee", CellsType = "mono", Length = 246, Width = 2 };
                var installation3 = new Installation() { Description = "La super gazetière de Jean-Gilbert", Image = "hello", Street = "Rue de Lausanne", No = "37", PostCode = 1950, City = "Sion", CoordinateX = 593679.0, CoordinateY = 120034.1, AzimutOrientation = 25, TiltOrientation = 22, EnergyType = "bioGaz", IntegrationType = "ajoutee", CellsType = "mono", Length = 246, Width = 2 };
                var installation4 = new Installation() { Description = "Le super barrage de Tatiana", Image = "myLord", Street = "Rue de Gravelone", No = "28", PostCode = 1950, City = "Sion", CoordinateX = 593529.9, CoordinateY = 120538.8, AzimutOrientation = 40, TiltOrientation = 30, EnergyType = "hydro", IntegrationType = "ajoutee", CellsType = "mono", Length = 246, Width = 2 };

                context.Installations.AddRange(installation1, installation2, installation3, installation4);

                context.SaveChanges();
            }
        }
    }
}