using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    /// <summary>
    /// Information about the validation of a file
    /// </summary>
    public class ValidatedFile
    {
        /// <summary>
        /// Creates a new instance without arguments.
        /// </summary>
        public ValidatedFile() { }

        /// <summary>
        /// Default constructor for valid files.
        /// Internally sets Status to ValidationStatus.Valid
        /// </summary>
        /// <param name="path">Full path of the file</param>
        public ValidatedFile(string path)
        {
            Path = path;
            Status = ValidationStatus.Valid;
        }

        /// <summary>
        /// Default constructor for invalid files.
        /// Internally sets the Status to ValidationStatus.Invalid.
        /// </summary>
        /// <param name="path">Full path of the file</param>
        /// <param name="error">Validation error message</param>
        public ValidatedFile(string path, string error)
        {
            Path = path;
            Status = ValidationStatus.Invalid;
            ValidationError = error;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="path">Full path of the file</param>
        /// <param name="status">Validation status of the file</param>
        /// <param name="error">Validation error message</param>
        public ValidatedFile(string path, ValidationStatus status, string error)
        {
            Path = path;
            Status = status;
            ValidationError = error;
        }

        /// <summary>
        /// Full file path
        /// </summary>
        public string Path { get; set; } = "";

        /// <summary>
        /// Validation status
        /// </summary>
        public ValidationStatus Status { get; set; } = ValidationStatus.NotValidated;

        /// <summary>
        /// Validation error text
        /// </summary>
        public string? ValidationError { get; set; }
    }
}
