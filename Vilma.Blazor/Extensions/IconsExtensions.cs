namespace Vilma.Blazor.Extensions
{
    internal static partial class Icons
    {
        /// <summary>
        /// Return the SVG markup of the icon.
        /// The width, height and icon color can be modified by passing
        /// different values.
        /// </summary>
        /// <param name="icon">Icon</param>
        /// <param name="width">Width of the icon</param>
        /// <param name="height">Height of the icon</param>
        /// <param name="textColor">Color of the text</param>
        /// <returns></returns>
        internal static string GetIconSvg(this Vilma.Blazor.Icons icon, int width = 16, int height = 16, string? textColor = null)
        {
            var iconStr = icon.ToString();

            if (s_svgIcons.ContainsKey(iconStr))
            {
                var svg = s_svgIcons[iconStr];
                svg = svg.Replace(@"width=""16""", $@"width=""{width}""");
                svg = svg.Replace(@"height=""16""", $@"height=""{height}""");

                if (textColor != null )
                {
                    var marker = "class=";
                    var classIdx = svg.IndexOf(marker);
                    bool startQuotationFound = false;

                    for (int i = classIdx + marker.Length; i < svg.Length; i++)
                    {
                        if (svg[i] == '"' && !startQuotationFound)
                            startQuotationFound = true;
                        else if (svg[i] == '"' && startQuotationFound)
                        {
                            var newClass = $" {textColor}";
                            svg = svg.Insert(i, newClass);
                            break;
                        }
                    }
                }

                return svg;
            }

            return "";
        }
    }
}
