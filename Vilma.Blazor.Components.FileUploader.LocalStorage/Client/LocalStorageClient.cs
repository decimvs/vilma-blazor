using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Common;
using Vilma.Blazor.Common.FileUploader;
using Vilma.Blazor.Common.Utilities;

namespace Vilma.Blazor.Components.FileUploader.LocalStorage.Client
{
    public class LocalStorageClient : IFileUploader
    {
        public ClientParameters? Parameters { get => _parameters; }

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private ClientParameters? _parameters = null;
        private string _uploaderName = string.Empty;

        public LocalStorageClient (IHttpClientFactory httpFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpFactory;
            _configuration = configuration;
        }

        public void LoadParameters(string configurationPath)
        {
            _parameters = Common.FileUploader.ParametersHelpers.GetClientParameters(_configuration, configurationPath);
            var uname = Common.FileUploader.ParametersHelpers.GetClientParametersSectionName(configurationPath);

            if (uname == null) throw new Exception($"Unable to find the uploader name from configuration path {configurationPath}");

            _uploaderName = uname;
        }

        /// <inheritdoc/>
        public FilesValidationResult CheckFilesOnClient(IReadOnlyList<IBrowserFile> files)
        {
            if (_parameters == null) throw new Exception("Parameters are not loaded. You should call LoadParameters before calling other methods");

            var validationResult = new FilesValidationResult();

            try
            {
                foreach (var file in files)
                {
                    var result = FileValidationHelpers.ClientFileValidation(file, _parameters);
                    validationResult.Files.Add(result);
                }

                return validationResult;
            }
            catch (Exception ex)
            {
                throw new FileValidationException("File Validation Error: see inner exception for more details.", validationResult, ex);
            }
        }

        /// <inheritdoc/>
        public async void UploadFiles(IReadOnlyList<IBrowserFile> files)
        {
            if (_parameters == null) throw new Exception("Parameters are not loaded. You should call LoadParameters before calling other methods");

            using var content = new MultipartFormDataContent();

            foreach (var file in files)
            {
                try
                {
                    var maxFileSize = Common.Utilities.ParametersHelpers.GetMaxFileSizeForFileExtension(_parameters, Path.GetExtension(file.Name).Substring(1));
                    var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                    content.Add(content: fileContent, name: "\"files\"", fileName: file.Name);
                }
                catch
                {
                    throw;
                }
            }

            var httpClient = _httpClientFactory.CreateClient(_uploaderName);
            var url = UrlHelpers.CombineUrlSegments(_parameters.ApiEndPoint, "api/vb/Upload/Store");

            var response = await httpClient.PostAsync(url, content);
        }
    }
}
