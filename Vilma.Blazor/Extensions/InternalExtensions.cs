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
        #region ColorScheme

        /// <summary>
        /// Returns the text-bg class associated to the ColorScheme
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetTextBgClass(this ColorScheme style)
        {
            switch (style)
            {
                case ColorScheme.Danger:
                    return "text-bg-danger";
                case ColorScheme.Warning:
                    return "text-bg-warning";
                case ColorScheme.Dark:
                    return "text-bg-dark";
                case ColorScheme.Primary:
                    return "text-bg-primary";
                case ColorScheme.Secondary:
                    return "text-bg-secondary";
                case ColorScheme.Success:
                    return "text-bg-success";
                case ColorScheme.Info:
                    return "text-bg-info";
                case ColorScheme.Light:
                    return "text-bg-light";
                case ColorScheme.Link:
                case ColorScheme.None:
                default:
                    return "";
            }
        }

        /// <summary>
        /// Returns the btn class associated to the ColorScheme
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetButtonClass(this ColorScheme style)
        {
            switch (style)
            {
                case ColorScheme.Danger:
                    return "btn-danger";
                case ColorScheme.Warning:
                    return "btn-warning";
                case ColorScheme.Dark:
                    return "btn-dark";
                case ColorScheme.Primary:
                    return "btn-primary";
                case ColorScheme.Secondary:
                    return "btn-secondary";
                case ColorScheme.Success:
                    return "btn-success";
                case ColorScheme.Info:
                    return "btn-info";
                case ColorScheme.Light:
                    return "btn-light";
                case ColorScheme.Link:
                    return "btn-link";
                case ColorScheme.None:
                default:
                    return "";
            }
        }

        /// <summary>
        /// Returns the btn-outline class associated to the ColorScheme
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetButtonOutlineClass(this ColorScheme style)
        {
            switch (style)
            {
                case ColorScheme.Danger:
                    return "btn-outline-danger";
                case ColorScheme.Warning:
                    return "btn-outline-warning";
                case ColorScheme.Dark:
                    return "btn-outline-dark";
                case ColorScheme.Primary:
                    return "btn-outline-primary";
                case ColorScheme.Secondary:
                    return "btn-outline-secondary";
                case ColorScheme.Success:
                    return "btn-outline-success";
                case ColorScheme.Info:
                    return "btn-outline-info";
                case ColorScheme.Light:
                    return "btn-outline-light";
                case ColorScheme.Link:
                case ColorScheme.None:
                default:
                    return "";
            }
        }

        /// <summary>
        /// Returns the text class associated to the ColorScheme
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetTextClass(this ColorScheme style)
        {
            switch (style)
            {
                case ColorScheme.Danger:
                    return "text-danger";
                case ColorScheme.Warning:
                    return "text-warning";
                case ColorScheme.Dark:
                    return "text-dark";
                case ColorScheme.Primary:
                    return "text-primary";
                case ColorScheme.Secondary:
                    return "text-secondary";
                case ColorScheme.Success:
                    return "text-success";
                case ColorScheme.Info:
                    return "text-info";
                case ColorScheme.Light:
                    return "text-light";
                case ColorScheme.None:
                case ColorScheme.Link:
                default:
                    return "";
            }
        }

        /// <summary>
        /// Returns the alert class associated to the ColorScheme
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        internal static string GetAlertClass(this ColorScheme style)
        {
            switch (style)
            {
                case ColorScheme.Danger:
                    return "alert-danger";
                case ColorScheme.Warning:
                    return "alert-warning";
                case ColorScheme.Dark:
                    return "alert-dark";
                case ColorScheme.Primary:
                    return "alert-primary";
                case ColorScheme.Secondary:
                    return "alert-secondary";
                case ColorScheme.Success:
                    return "alert-success";
                case ColorScheme.Info:
                    return "alert-info";
                case ColorScheme.Light:
                case ColorScheme.None:
                case ColorScheme.Link:
                default:
                    return "alert-light";
            }
        }

        /// <summary>
        /// Return the bg classs associated to the ColorScheme
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        internal static string GetBgClass(this ColorScheme style)
        {
            switch (style)
            {
                case ColorScheme.Danger:
                    return "bg-danger";
                case ColorScheme.Warning:
                    return "bg-warning";
                case ColorScheme.Dark:
                    return "bg-dark";
                case ColorScheme.Primary:
                    return "bg-primary";
                case ColorScheme.Secondary:
                    return "bg-secondary";
                case ColorScheme.Success:
                    return "bg-success";
                case ColorScheme.Info:
                    return "bg-info";
                case ColorScheme.None:
                case ColorScheme.Light:
                case ColorScheme.Link:
                default:
                    return "bg-light";
            }
        }

        #endregion

        #region Sizes

        /// <summary>
        /// Return the size class related to the Size constant
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static string GetSizeClass(this Sizes size)
        {
            switch (size)
            {
                case Sizes.Large:
                    return "btn-lg";
                case Sizes.Small:
                    return "btn-sm";
                case Sizes.Normal:
                default:
                    return "";
            }
        }

        #endregion

        #region DropdownDirections

        /// <summary>
        /// Returns the css class associated with the DropdownDirections constant passed.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        internal static string GetDirectionClass (this DropdownDirections direction)
        {
            switch (direction)
            {
                case DropdownDirections.DownCentered:
                    return "dropdown-center";
                case DropdownDirections.Up:
                    return "dropup";
                case DropdownDirections.UpCentered:
                    return "dropup-center dropup";
                case DropdownDirections.End:
                    return "dropend";
                case DropdownDirections.Start:
                    return "dropstart";
                case DropdownDirections.Down:
                default:
                    return "dropdown";

            }
        }

        #endregion
    }
}
