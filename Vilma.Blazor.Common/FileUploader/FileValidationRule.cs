using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    /// <summary>
    /// File validation group.
    /// Allows to define a group of parameters to validate files.
    /// A list of extensions can be enabled or disabled and limit
    /// their size.
    /// </summary>
    public class FileValidationRule
    {
        /// <summary>
        /// Extensions that are enabled or disabled.
        /// If value of MaxFileSize = 0: extensions listed here are disabled.
        /// If value of MaxFileSize = -1 or > 0: extensions listed here are enabled.
        /// </summary>
        public List<string> Extensions { get; set; } = new();

        /// <summary>
        /// File size unit.
        /// Posible units are: B (byte), KB (kilobyte), MB (megabyte),
        /// GB (gigabyte) or TB (terabyte).
        /// Default is MB.
        /// </summary>
        public string FileSizeUnit { get; set; } = "MB";

        /// <summary>
        /// Maximum file size.
        /// Values over 0 are related to <code>FileSizeUnit</code> 
        /// to calculate the effective size in bytes internally.
        /// A value of 0 disables this extensions (cannot be uploaded).
        /// A value of -1 enables unlimited size (not recommended).
        /// </summary>
        public int MaxFileSize { get; set; }

        /// <summary>
        /// Optional comment for the rule.
        /// </summary>
        public string? Comment { get; set; }
    }
}
