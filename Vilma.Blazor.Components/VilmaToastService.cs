using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Components.Internal;
using Vilma.Blazor.Components.Models;

namespace Vilma.Blazor.Components
{
    public class VilmaToastService
    {
        internal EventHandler<ToastEventArgs> ToastAdded { get; set; }

        public void AddToast(string content, ColorScheme colorScheme = ColorScheme.None, bool showCloseButton = true, 
                string? additionalCss = null, bool autohide = true, int autohideDelay = 5000)
        {
            var alert = new Toast
            {
                Content = content,
                ColorScheme = colorScheme,
                ShowCloseButton = showCloseButton,
                CssClasses = additionalCss,
                Autohide = autohide,
                AutohideDelay = autohideDelay
            };

            AddToast(alert);
        }

        public void AddToast(Toast alert)
        {
            ToastAdded?.Invoke(null, new ToastEventArgs(alert));
        }
    }
}
