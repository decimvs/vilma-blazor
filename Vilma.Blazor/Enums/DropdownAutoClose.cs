using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor
{
    public enum DropdownAutoClose
    {
        /// <summary>
        /// Menu closes when clicking inside or outside.
        /// </summary>
        Default,

        /// <summary>
        /// Menu closes only when clicking again in the button.
        /// </summary>
        Manual,

        /// <summary>
        /// Menu closes only when clicking inside the menu. It allows to click
        /// outside the menu keeping the menu visible.
        /// </summary>
        ClickableInside,

        /// <summary>
        /// Menu closes only when clicking outside. It allows to click inside
        /// the menu keeping it visible.
        /// </summary>
        ClickableOutside
    }
}
