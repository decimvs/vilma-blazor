using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor
{
    internal static class InternalExtensions
    {
        /// <summary>
        /// Returns the text-bg class associated to this ComponentStyle
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetTextBgClass(this ComponentStyle style)
        {
            switch(style)
            {
                case ComponentStyle.Danger:
                    return "text-bg-danger";
                case ComponentStyle.Warning:
                    return "text-bg-warning";
                case ComponentStyle.Dark:
                    return "text-bg-dark";
                case ComponentStyle.Primary:
                    return "text-bg-primary";
                case ComponentStyle.Secondary:
                    return "text-bg-secondary";
                case ComponentStyle.Success:
                    return "text-bg-success";
                case ComponentStyle.Info:
                    return "text-bg-info";
                case ComponentStyle.Light:
                    return "text-bg-light";
                case ComponentStyle.None:
                default:
                    return "";
            }
        }

        public static string GetAlertClass(this ComponentStyle style)
        {
            switch (style)
            {
                case ComponentStyle.Danger:
                    return "alert-danger";
                case ComponentStyle.Warning:
                    return "alert-warning";
                case ComponentStyle.Dark:
                    return "alert-dark";
                case ComponentStyle.Primary:
                    return "alert-primary";
                case ComponentStyle.Secondary:
                    return "alert-secondary";
                case ComponentStyle.Success:
                    return "alert-success";
                case ComponentStyle.Info:
                    return "alert-info";
                case ComponentStyle.Light:
                case ComponentStyle.None:
                default:
                    return "alert-light";
            }
        }
    }
}
