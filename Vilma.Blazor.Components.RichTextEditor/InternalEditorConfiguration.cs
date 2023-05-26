using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vilma.Blazor.Components.RichTextEditor
{
    internal class InternalEditorConfiguration
    {
        public InternalEditorConfiguration(string selector, string baseUrl)
        {
            Selector = selector;
            BaseUrl = baseUrl;
        }

        [JsonPropertyName("selector")]
        public string Selector { get; set; }

        [JsonPropertyName("base_url")]
        public string BaseUrl { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; } = ".min";

        [JsonPropertyName("skin")]
        public string Skin { get; set; } = "oxide";

        [JsonPropertyName("promotion")]
        public bool Promotion { get; set; } = false;
    }
}
