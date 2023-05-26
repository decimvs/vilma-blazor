using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    /// <summary>
    /// Result of the validation of the files.
    /// </summary>
    public class FilesValidationResult
    {
        /// <summary>
        /// List of validated files.
        /// </summary>
        public List<ValidatedFile> Files { get; set; } = new();

        /// <summary>
        /// Check if one or more files had validation errors.
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return Files.Where(w => w.Status == ValidationStatus.Invalid).Any();
            }
        }
    }
}
