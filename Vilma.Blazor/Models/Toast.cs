using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Internal;

namespace Vilma.Blazor.Models
{
    public class Toast
    {
        /// <summary>
        /// Gets or sets the text content of the toast. If you want to use HTML or other components 
        /// use BodyTemplate property instead.
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Gets or sets the content of the toast defined by pure HTML or other components.
        /// </summary>
        public RenderFragment? BodyTemplate { get; set; }

        /// <summary>
        /// Gets or sets the text content of the header. If you want to user HTML or other components
        /// use HeaderTemplate property instead.
        /// </summary>
        public string? Header { get; set; }

        /// <summary>
        /// Gets or set the content of the header defined by pure HTML or other components.
        /// </summary>
        public RenderFragment? HeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets this component style.
        /// </summary>
        public ComponentStyle ColorScheme { get; set; } = ComponentStyle.None;

        /// <summary>
        /// Gets or sets additional CSS classes to the toast.
        /// </summary>
        public string? CssClasses { get; set; }

        /// <summary>
        /// Show or hide the close button.
        /// </summary>
        public bool ShowCloseButton { get; set; }

        /// <summary>
        /// Automatically hide the toast after the delay
        /// </summary>
        public bool Autohide { get; set; } = true;

        /// <summary>
        /// Delay in miliseconds before hiding the toast
        /// </summary>
        public int AutohideDelay { get; set; } = 5000;

        internal string ObjectId { get; private set; } = Guid.NewGuid().ToString();
    }
}
