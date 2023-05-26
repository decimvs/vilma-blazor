using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Components.Internal
{
    public class VilmaFormControl : ComponentBase
    {
        [Parameter] public string? Label { get; set; }

        [Parameter] public RenderFragment? LabelTemplate { get; set; }

        [Parameter] public string? LabelCssClasses { get; set; }

        [Parameter] public string InputId { get; set; } = Guid.NewGuid().ToString();

        [Parameter] public string? InputCssClasses { get; set; }

        [Parameter] public string? Placeholder { get; set; }
    }
}
