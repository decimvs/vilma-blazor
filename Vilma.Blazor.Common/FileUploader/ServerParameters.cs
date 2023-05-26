using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    public class ServerParameters : IFileValidationRules
    {
        /// <summary>
        /// File validation rules
        /// </summary>
        public List<FileValidationRule> FileValidationRules { get; set; } = new();

        /// <summary>
        /// Sets the path to store the uploaded files before server validation
        /// </summary>
        public string TemporalFilesPath { get; set; } = string.Empty;

        /// <summary>
        /// Sets the path to store the validated files
        /// </summary>
        public string FilesStoragePath { get; set; } = string.Empty;
    }
}
