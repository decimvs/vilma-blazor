using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor.Components
{
    public enum ModalFullScreenModes
    {
        /// <summary>
        /// Modal is shown on full screen on all viewports
        /// </summary>
        Always,

        /// <summary>
        /// Modal is shown when viewport < 576px
        /// </summary>
        Small,

        /// <summary>
        /// Modal is shown when viewport < 768px
        /// </summary>
        Medium,

        /// <summary>
        /// Modal is shown when viewport < 992px
        /// </summary>
        Large,

        /// <summary>
        /// Modal is shown when viewport < 1200px
        /// </summary>
        ExtraLarge,

        /// <summary>
        /// Modal is shown when viewport < 1400px
        /// </summary>
        ExtraExtraLarge,
    }
}
