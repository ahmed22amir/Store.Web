using Store.Repository.InterFaces;
using Store.Repository.UnitOfWork;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;

namespace Store.Web.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(ProductProfile));
            return services;
        }
    }
}
