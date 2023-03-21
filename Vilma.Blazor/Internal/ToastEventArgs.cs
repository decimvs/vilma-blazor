using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Models;

namespace Vilma.Blazor.Internal
{
    internal class ToastEventArgs : EventArgs
    {
        public ToastEventArgs(Toast toast) 
        {
            Toast = toast;
        }

        public Toast Toast { get; set; }
    }
}
