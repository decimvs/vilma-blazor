using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    public interface IFileUploader
    {
        ClientParameters? Parameters { get; }

        /// <summary>
        /// Loads the configuration from the referenced configuration
        /// section. Supports colon ':' notation.
        /// </summary>
        /// <param name="configurationPath"></param>
        void LoadParameters(string configurationPath);

        /// <summary>
        /// Performs a check of the files before they are uploaded
        /// </summary>
        /// <param name="files">List of files to check</param>
        FilesValidationResult CheckFilesOnClient(IReadOnlyList<IBrowserFile> files);

        /// <summary>
        /// Uploads a list of files to the server
        /// </summary>
        /// <param name="files">List of files to upload</param>
        /// <returns></returns>
        void UploadFiles(IReadOnlyList<IBrowserFile> files);
    }
}
