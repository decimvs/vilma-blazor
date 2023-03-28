using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Internal
{
    public abstract class VilmaGroupableComponent : VilmaBasicComponent
    {
        [CascadingParameter] internal object? Parent { get; set; }

        protected string GroupName { get; set; } = DateTime.Now.Ticks.ToString("x");

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Parent != null && Parent is VilmaButtonGroup)
            {
                var parent = (VilmaButtonGroup)Parent;
                GroupName = parent.GroupName;
                parent.AddChild(this);
            }
        }

        internal abstract void SetDisabledStatus(bool newStatus);
    }
}
