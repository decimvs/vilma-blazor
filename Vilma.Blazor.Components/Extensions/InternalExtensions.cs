using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Components
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
        /// Returns the group list class associated to the ColorScheme
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetGroupListClass(this ColorScheme style)
        {
            switch (style)
            {
                case ColorScheme.Danger:
                    return "list-group-item-danger";
                case ColorScheme.Warning:
                    return "list-group-item-warning";
                case ColorScheme.Dark:
                    return "list-group-item-dark";
                case ColorScheme.Primary:
                    return "list-group-item-primary";
                case ColorScheme.Secondary:
                    return "list-group-item-secondary";
                case ColorScheme.Success:
                    return "list-group-item-success";
                case ColorScheme.Info:
                    return "list-group-item-info";
                case ColorScheme.Light:
                    return "list-group-item-light";
                case ColorScheme.Link:
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

        #region Dropdown

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

        /// <summary>
        /// Returns the config value needed for the auto close behavior of the
        /// dropdown.
        /// </summary>
        /// <param name="autoClose"></param>
        /// <returns></returns>
        internal static string GetAutoCloseValue (this DropdownAutoClose autoClose)
        {
            switch (autoClose)
            {
                case DropdownAutoClose.Default:
                default:
                    return "true";
                case DropdownAutoClose.Manual:
                    return "false";
                case DropdownAutoClose.ClickableInside:
                    return "inside";
                case DropdownAutoClose.ClickableOutside:
                    return "outside";
            }
        }

        #endregion

        #region InputTypes

        /// <summary>
        /// Returns the css class for the input type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static string GetInputTypeClass(this InputTypes type)
        {
            switch (type)
            {
                case InputTypes.Text:
                case InputTypes.Password:
                case InputTypes.Color:
                case InputTypes.Date:
                case InputTypes.DateTimeLocal:
                case InputTypes.Email:
                case InputTypes.File:
                case InputTypes.Month:
                case InputTypes.Number:
                case InputTypes.Tel:
                case InputTypes.Time:
                case InputTypes.Url:
                case InputTypes.Week:
                default:
                    return "form-control";
            }
        }

        /// <summary>
        /// Returns the input type text for use in <input/> tag.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static string GetInputTypeText(this InputTypes type)
        {
            switch (type)
            {
                case InputTypes.Text:
                default:
                    return "text";
                case InputTypes.Password:
                    return "password";
                case InputTypes.Color:
                    return "color";
                case InputTypes.Date:
                    return "date";
                case InputTypes.DateTimeLocal:
                    return "datetime-local";
                case InputTypes.Email:
                    return "email";
                case InputTypes.File:
                    return "file";
                case InputTypes.Month:
                    return "month";
                case InputTypes.Number:
                    return "number";
                case InputTypes.Tel:
                    return "tel";
                case InputTypes.Time:
                    return "time";
                case InputTypes.Url:
                    return "url";
                case InputTypes.Week:
                    return "week";
            }
        }

        #endregion

    }
}
