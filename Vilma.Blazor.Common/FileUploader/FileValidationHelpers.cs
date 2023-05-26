using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Common.FileUploader;
using Vilma.Blazor.Common;
using System.Globalization;
using Vilma.Blazor.Common.Utilities;

namespace Vilma.Blazor.Common.FileUploader
{
    public class FileValidationHelpers
    {
        /// <summary>
        /// Validates a file on client's browser
        /// </summary>
        /// <param name="file"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static ValidatedFile ClientFileValidation(IBrowserFile file, ClientParameters parameters)
        {
            try
            {
                return FileValidation(file.Name, parameters, file.Size);
            }
            catch
            {
                throw;
            }
        }

        public static ValidatedFile FileValidation(string filePath, IFileValidationRules parameters, long fileSize = -1)
        {
            var fileExt = Path.GetExtension(filePath).Substring(1);
            var fileName = Path.GetFileName(filePath);
            bool hasCatchAllRule = false;
            FileValidationRule? catchAllRule = null;
            int extensionExplicitlyDisabled = 0;
            int extensionExplicitlyAllowed = 0;
            bool isFileSizeOk = false;
            var catchAllRules = parameters.FileValidationRules.Where(w => w.Extensions.Count == 0);

            // Get catch all files rule
            if (catchAllRules.Count() == 1)
            {
                catchAllRule = catchAllRules.First();
                hasCatchAllRule = true;
            }
            else if (catchAllRules.Count() > 1)
            {
                throw new ArgumentException("Only one catch all file validation can be defined");
            }

            if (fileSize < 0 && File.Exists(filePath))
            {
                var fi = new FileInfo(filePath);
                fileSize = fi.Length;
            }
            else
                throw new ArgumentException("No file size provided or wrong file path");

            foreach (var parameter in parameters.FileValidationRules)
            {
                foreach (var ext in parameter.Extensions)
                {
                    if (ext.ToUpper() == fileExt.ToUpper())
                    {
                        if (parameter.MaxFileSize == -1 || parameter.MaxFileSize > 0)
                        {
                            extensionExplicitlyAllowed++;

                            if (parameter.MaxFileSize > 0)
                                isFileSizeOk = FileSizeCheck(fileSize, parameter);
                            else
                                isFileSizeOk = true;
                        }
                        else if (parameter.MaxFileSize == 0)
                        {
                            extensionExplicitlyDisabled++;
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid MaxFileSize parameter value in file validation rules: {parameter.MaxFileSize}");
                        }
                    }
                }
            }

            if (extensionExplicitlyAllowed == 0 && extensionExplicitlyDisabled == 0 && hasCatchAllRule)
            {
                // Extension accepted, validate size
                if (catchAllRule.MaxFileSize == 0)
                {
                    // All extensions disallowed
                    return new ValidatedFile(fileName, "All file extensions are disallowed.");
                }
                else if (catchAllRule.MaxFileSize > 0)
                {
                    if (FileSizeCheck(fileSize, catchAllRule))
                        return new ValidatedFile(fileName);
                    else
                        return new ValidatedFile(fileName, "File too large");
                }
                else
                {
                    // All large files are allowed
                    return new ValidatedFile(fileName);
                }
            }
            else if (extensionExplicitlyAllowed == 1 && extensionExplicitlyDisabled == 0)
            {
                // Extension accepted, validate size
                if (isFileSizeOk)
                    return new ValidatedFile(fileName);
                else
                    return new ValidatedFile(fileName, "File too large");
            }
            else if (extensionExplicitlyAllowed == 0 && extensionExplicitlyDisabled == 1)
            {
                // Extension not accepted, invalidate file
                return new ValidatedFile(fileName, $"The file extension {fileExt} is not allowed for uploads.");
            }
            else if (extensionExplicitlyAllowed == 0 && extensionExplicitlyDisabled == 0 && !hasCatchAllRule)
            {
                // Extension not accepted, invalidate file
                return new ValidatedFile(fileName, $"The file extension {fileExt} is not allowed for uploads.");
            }
            else
            {
                if (extensionExplicitlyDisabled > 1 || extensionExplicitlyAllowed > 1 ||
                   (extensionExplicitlyDisabled == 1 && extensionExplicitlyAllowed == 1))
                    throw new Exception($"File validation failed: file extension {fileExt} is defined more than once in the file validation rules.");
                else
                    throw new Exception($"File validation failed for file extension {fileExt}: no validation rule applicable for this extension");
            }
        }

        /// <summary>
        /// Checks the file size on client's browser.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool FileSizeCheck(long fileSize, FileValidationRule parameters)
        {
            var allowedSize = Utilities.ParametersHelpers.GetMaxFileSize(parameters);

            if (fileSize <= allowedSize)
                return true;

            return false;
        }
    }
}
