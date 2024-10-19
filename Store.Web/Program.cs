
using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Repository.InterFaces;
using Store.Repository.UnitOfWork;
using Store.Service.Services.Products;
using Store.Service.Services.Products.Dtos;
using Store.Web.Extensions;
using Store.Web.Helper;
using Store.Web.Middleware;

namespace Store.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            //builder.Services.AddScoped<IProductService,ProductService>();
            //builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.ApplicationServices();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExeptionMiddleware>();
            app.UseAuthorization();

            await ApplySeeding.ApplySeedingAsync(app);
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
