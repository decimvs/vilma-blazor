using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Common
{
    public class UrlHelpers
    {
        /// <summary>
        /// Combines two url segments like Path.Combine does
        /// but specialized for URL.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CombineUrlSegments(string baseUrl, string path)
        {
            baseUrl = baseUrl.TrimEnd('/');
            path = path.TrimStart('/');
            return $"{baseUrl}/{path}";
        }
    }
}
