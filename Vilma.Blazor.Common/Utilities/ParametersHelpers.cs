using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Common.FileUploader;

namespace Vilma.Blazor.Common.Utilities
{
    public class ParametersHelpers
    {
        /// <summary>
        /// Returns the max file size defined in the file validation rule expressed in bytes.
        /// </summary>
        /// <param name="parameters">File validation rule to get the size for</param>
        /// <returns>Max file size in bytes</returns>
        public static long GetMaxFileSize(FileValidationRule parameters)
        {
            var power = CommonConstants.FILE_SIZE_UNITS.ToList().IndexOf(parameters.FileSizeUnit.ToUpper());
            var multiplier = Math.Floor(Math.Pow(1024, power));
            return parameters.MaxFileSize * (long)multiplier;
        }

        /// <summary>
        /// Finds a rule for a given file extension in the given parameters
        /// </summary>
        /// <param name="parameters">Uploader parameters containing a list of rules</param>
        /// <param name="fileExtension">Extension to find</param>
        /// <returns>FileValidationRule if found or null otherwise.</returns>
        public static FileValidationRule? GetFileValidationRuleForFileExtension(ClientParameters parameters, string fileExtension)
        {
            var catchAllNOk = from rule in parameters.FileValidationRules
                              where rule.MaxFileSize == 0 && rule.Extensions.Count == 0
                              select rule;

            if (catchAllNOk.Any()) return null;


            var explicitlyNOk = from rule in parameters.FileValidationRules
                                where rule.MaxFileSize == 0
                                      && rule.Extensions.SingleOrDefault(s => s.ToUpper() == fileExtension.ToUpper()) != null
                                select rule;

            if (explicitlyNOk.Any()) return null;

            var explicitlyOk = from rule in parameters.FileValidationRules
                               where (rule.MaxFileSize > 0 || rule.MaxFileSize == -1) 
                                    && rule.Extensions.SingleOrDefault(s => s.ToUpper()  == fileExtension.ToUpper()) != null
                               select rule;

            if (explicitlyOk.Count() == 1) return explicitlyOk.First();

            var catchAllOk = from rule in parameters.FileValidationRules
                             where (rule.MaxFileSize > 0 || rule.MaxFileSize == -1) && rule.Extensions.Count == 0
                             select rule;

            if (catchAllOk.Count() == 1) return explicitlyOk.First();

            return null;
        }

        /// <summary>
        /// Gets the max file size for a given file extension and an upload parameters expressed in bytes.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="fileExtension"></param>
        /// <returns>Max file size in bytes</returns>
        public static long GetMaxFileSizeForFileExtension(ClientParameters parameters, string fileExtension)
        {
            var fileValidationRule = GetFileValidationRuleForFileExtension(parameters, fileExtension);

            if (fileValidationRule == null) return 0;

            return GetMaxFileSize(fileValidationRule);
        }
    }
}
