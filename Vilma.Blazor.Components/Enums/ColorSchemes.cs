using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Components
{
    public enum ColorScheme
    {
        Primary,
        Secondary,
        Success,
        Warning,
        Danger,
        Info,
        Light,
        Dark,
        /// <summary>
        /// This color scheme is limited only in some components:
        /// VilmaButton
        /// </summary>
        Link,
        None
    }
}
