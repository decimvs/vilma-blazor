using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Components.Models
{
    public class SlideEventArgs
    {
        public string? Direction { get; set; }

        public IJSObjectReference? RelatedTarget { get; set; }

        public int FromIndex { get; set; }

        public int ToIndex { get; set; }
    }
}
