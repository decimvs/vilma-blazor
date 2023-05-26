using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    public interface IFileValidationRules
    {
        List<FileValidationRule> FileValidationRules { get; set; }
    }
}
