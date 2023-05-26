using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Runtime.CompilerServices;
using Vilma.Blazor.Components.FileUploader.LocalStorage.Server.Controllers;

namespace Vilma.Blazor.Components.FileUploader.LocalStorage.Server
{
    public static class DIExtensions
    {
        /// <summary>
        /// Registers the needed controlers and resources for the FileUploader component.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddVilmaBlazorFileUploadControllers(this IServiceCollection services)
        {
            var assembly = typeof(UploadController).Assembly;
            var part = new AssemblyPart(assembly);

            services.AddControllersWithViews()
                .ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(part));

            return services;
        }

        /// <summary>
        /// Configures middleware to use Vilma Blazor file uploader.
        /// </summary>
        /// <param name="app"></param>
        public static void UseVilmaBlazorFileUploader(this WebApplication app)
        {
            app.MapControllers();
        }
    }
}
