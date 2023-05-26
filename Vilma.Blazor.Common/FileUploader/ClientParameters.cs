using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    public class ClientParameters : IFileValidationRules
    {
        /// <summary>
        /// File validation rules
        /// </summary>
        public List<FileValidationRule> FileValidationRules { get; set; } = new();

        public string ApiEndPoint { get; set; } = string.Empty;
    }
}
