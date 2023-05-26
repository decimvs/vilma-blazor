using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    public class FileValidationException : Exception
    {
        public FilesValidationResult ValidationResult { get; set; }

        public FileValidationException(string message, FilesValidationResult result) : base(message) 
        {
            ValidationResult = result;
        }

        public FileValidationException(string message, FilesValidationResult result, Exception innerException) : base(message, innerException)
        {
            ValidationResult = result;
        }
    }
}
