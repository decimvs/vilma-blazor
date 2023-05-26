using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    /// <summary>
    /// Different statuses of validation of a file
    /// </summary>
    public enum ValidationStatus
    {
        /// <summary>
        /// File is valid
        /// </summary>
        Valid,

        /// <summary>
        /// File is not valid
        /// </summary>
        Invalid,

        /// <summary>
        /// File not validated yet
        /// </summary>
        NotValidated
    }
}
