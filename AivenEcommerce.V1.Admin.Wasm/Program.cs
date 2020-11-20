using System;
using System.Net.Http;
using System.Threading.Tasks;

using AivenEcommerce.V1.Admin.Wasm.Http;
using AivenEcommerce.V1.Admin.Wasm.Options;
using AivenEcommerce.V1.Admin.Wasm.Services;
using AivenEcommerce.V1.Admin.Wasm.Services.ComponentServices;
using AivenEcommerce.V1.Admin.Wasm.Services.Interfaces;
using AivenEcommerce.V1.WebApi.Startup;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AivenEcommerce.V1.Admin.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            builder.Services.AddScoped<SpinnerComponentService>();
            builder.Services.AddScoped<AlertComponentService>();
            builder.Services.AddOptions<IApiOptions, ApiOptions>(builder.Configuration);
            builder.Services.AddScoped<AivenHttpMessageHandler>();

            builder.Services.AddScoped<IApiClientService, ApiClientService>();

            builder.Services.AddScoped(sp =>
            {
                var accessTokenHandler = sp.GetRequiredService<AivenHttpMessageHandler>();

                return new HttpClient(accessTokenHandler)
                {
                    BaseAddress = new Uri(builder.Configuration["ApiOptions:BaseAddress"])
                };
            });

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductImageService, ProductImageService>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddScoped<IProductOverviewService, ProductOverviewService>();
            builder.Services.AddScoped<IProductBadgeService, ProductBadgeService>();
            builder.Services.AddScoped<IProductVariantService, ProductVariantService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            await builder.Build().RunAsync();
        }
    }
}
