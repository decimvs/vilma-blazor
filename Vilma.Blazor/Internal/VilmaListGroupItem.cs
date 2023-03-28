using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Internal;

namespace Vilma.Blazor
{
    public class VilmaListGroupItem : ComponentBase
    {
        [Parameter] public string? Content { get; set; }

        [Parameter] public RenderFragment? ContentTemplate { get; set; }

        [Parameter] public string? CssClasses { get; set; }

        [Parameter] public bool Active { get; set; }

        [Parameter] public bool Disabled { get; set; }

        [Parameter] public ColorScheme ColorScheme { get; set; } = ColorScheme.None;


        internal CssClassCollection _cssClasses = new CssClassCollection();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            _cssClasses.Clear();
            _cssClasses.Add("list-group-item");
            _cssClasses.AddClasses(ColorScheme.GetGroupListClass());

            if (Active)
                _cssClasses.Add("active");

            if (Disabled)
                _cssClasses.Add("disabled");

            _cssClasses.AddClasses(CssClasses);
        }

    }
}
