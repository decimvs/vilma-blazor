using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Common;

namespace Vilma.Blazor.Common.FileUploader
{
    public class ParametersChecker
    {
        /// <summary>
        /// Validates the client parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateClientParameters (ClientParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.ApiEndPoint))
                throw new ArgumentException("Uploader parameters validation: ApiEndPoint is mandatory.");

            // Validation of the file validation rules
            try
            {
                ValidateFileValidationRules(parameters);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Validates the server parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateServerParameters(ServerParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.TemporalFilesPath))
                throw new ArgumentException("Uploader parameters validation: TemporalFilesPath is mandatory.");

            if (string.IsNullOrWhiteSpace(parameters.FilesStoragePath))
                throw new ArgumentException("Uploader parameters validation: FilesStoragePath is mandatory.");

            // Validation of the file validation rules
            try
            {
                ValidateFileValidationRules(parameters);
            }
            catch
            {
                throw;
            }
        }

        private static void ValidateFileValidationRules(IFileValidationRules parameters)
        {
            // Validation of the file validation rules
            if (parameters.FileValidationRules == null || parameters.FileValidationRules.Count == 0)
                throw new ArgumentException("Uploader parameters validation: At least one FileValidationRule should be provided.");

            foreach (var parameter in parameters.FileValidationRules)
            {
                if (!CommonConstants.FILE_SIZE_UNITS.Contains(parameter.FileSizeUnit.ToUpper()))
                    throw new ArgumentException($"Uploader parameters validation: Unknown file size unit: {parameter.FileSizeUnit}");

                if (parameter.MaxFileSize <= -1)
                    throw new ArgumentException("Uploader parameters validation: Max file size should be greater than -1");
            }
        }
    }
}
