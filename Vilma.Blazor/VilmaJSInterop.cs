using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilma.Blazor.Internal;

namespace Vilma.Blazor
{
    internal class VilmaJSInterop
    {
        private readonly Lazy<Task<IJSObjectReference>> accordionModule;
        private readonly Lazy<Task<IJSObjectReference>> modalModule;

        public VilmaJSInterop(IJSRuntime jsRuntime)
        {
            jsRuntime.InvokeVoidAsync("import", "./_content/Vilma.Blazor/js/bootstrap.min.js");

            accordionModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Vilma.Blazor/js/vilma.accordion.js").AsTask());

            modalModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Vilma.Blazor/js/vilma.modal.js").AsTask());
        }

        #region Accordion

        public async Task AccordionSetItemListeners(DotNetObjectReference<VilmaCollapsibleComponent> dnReference, ElementReference? element)
        {
            await (await GetModule(accordionModule)).InvokeVoidAsync("setAccordionItemListeners", dnReference, element);
        }

        public async Task AccordionToggle(ElementReference? element)
        {
            await (await GetModule(accordionModule)).InvokeVoidAsync("accordionToggle", element);
        }

        public async Task AccordionShow(ElementReference? element)
        {
            await (await GetModule(accordionModule)).InvokeVoidAsync("accordionShow", element);
        }

        public async Task AccordionHide(ElementReference? element)
        {
            await (await GetModule(accordionModule)).InvokeVoidAsync("accordionHide", element);
        }

        #endregion

        #region Modal

        public async Task ModalShow(ElementReference? element)
        {
            await (await GetModule(modalModule)).InvokeVoidAsync("modalShow", element);
        }

        #endregion

        private async Task<IJSObjectReference> GetModule (Lazy<Task<IJSObjectReference>> module)
        {
            return await module.Value;
        }
    }
}
