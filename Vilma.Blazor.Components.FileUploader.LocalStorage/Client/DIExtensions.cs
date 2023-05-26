using Vilma.Blazor.Common.FileUploader;

namespace Vilma.Blazor.Components.FileUploader.LocalStorage.Client
{
    public static class DIExtensions
    {
        /// <summary>
        /// Registers all the necessary components for the file uploader API client.
        /// This method requires a configuration section called "VilmaBlazorFileUploader"
        /// in appsettings.json.
        /// </summary>
        /// <param name="services">Services collection</param>
        /// <returns>Services collection</returns>
        public static IServiceCollection AddVilmaBlazorFileUploaderClient(this IServiceCollection services)
        {
            return AddVilmaBlazorFileUploaderClient(services, FileUploaderConstants.APPCONFIG_CLIENT_MAIN_SECTION_NAME);
        }

        /// <summary>
        /// Registers all the necessary components for the file uploader API client.
        /// This method allows you to specify a different configuration section in appsettings.json.
        /// </summary>
        /// <param name="services">Services collection</param>
        /// <param name="configurationSection">Appsettings.json configuration section name</param>
        /// <returns>Services collection</returns>
        /// <exception cref="Exception">Throws execption on configuration errors</exception>
        public static IServiceCollection AddVilmaBlazorFileUploaderClient(this IServiceCollection services, string configurationSection)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var vilmaBlazor = configuration.GetSection(configurationSection);

            if (vilmaBlazor == null) throw new Exception($"Vilma Blazor Uploder: unable to find a configuration section called: {configurationSection}");

            var uploaders = from value in vilmaBlazor.AsEnumerable()
                            where value.Key.Split(':').Length == 2
                            select value.Key.Split(':')[1];

            if (!uploaders.Any()) throw new Exception($"Vilma file uploader: unable to find uploader configurations in section {configurationSection}");

            foreach (var uploader in uploaders)
            {
                var uConfig = new ClientParameters();
                configuration.Bind($"{configurationSection}:{uploader}", uConfig);

                if (string.IsNullOrWhiteSpace(uConfig.ApiEndPoint)) throw new Exception($"Vilma file uploader: ApiEndPoint is manatory for {configurationSection}.{uploader}");

                services.AddHttpClient(uploader, opts => {
                    opts.BaseAddress = new Uri(uConfig.ApiEndPoint);
                    opts.DefaultRequestHeaders.Add("ClientName", uploader);
                });
            }

            services.AddScoped<IFileUploader, LocalStorageClient>();

            return services;
        }
    }
}
