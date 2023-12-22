using uwp_integration.lib.Data;
using uwp_integration.lib.ML.Objects;

namespace uwp_integration.lib.Helpers
{
    public static class Converters
    {
        public static WebPageInputItem ToWebPageInputItem(this WebPageResponseItem webPage)
        {
            return new WebPageInputItem
            {
                HTMLContent = webPage.Content
            };
        }
    }
}