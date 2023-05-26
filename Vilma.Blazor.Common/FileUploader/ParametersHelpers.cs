using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common.FileUploader
{
    public class ParametersHelpers
    {
        /// <summary>
        /// Returns an uploader configuration section.
        /// Supports colon ':' notation.
        /// </summary>
        /// <param name="configuration">Configuration collection</param>
        /// <param name="sectionPath">Relative or full configuration section path</param>
        /// <returns></returns>
        public static ClientParameters GetClientParameters(IConfiguration configuration, string sectionPath)
        {
            string configPath = string.Empty;

            if (sectionPath.Contains(':'))
                configPath = sectionPath;
            else
                configPath = $"{FileUploaderConstants.APPCONFIG_CLIENT_MAIN_SECTION_NAME}:{sectionPath}";

            var parameters = new ClientParameters();
            configuration.Bind(configPath, parameters);

            return parameters;
        }

        /// <summary>
        /// Finds the uploader name on a section path.
        /// </summary>
        /// <param name="sectionPath"></param>
        /// <returns></returns>
        public static string? GetClientParametersSectionName(string sectionPath)
        {
            if (!sectionPath.Contains(":")) return sectionPath;

            var parts = sectionPath.Split(':');

            if (parts.ElementAtOrDefault(1) == null) return null;

            return parts[1];
        }
    }
}
