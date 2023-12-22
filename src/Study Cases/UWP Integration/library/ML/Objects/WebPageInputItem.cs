using Microsoft.ML.Data;

namespace uwp_integration.lib.ML.Objects
{
    public class WebPageInputItem
    {
        [LoadColumn(0), ColumnName("Label")]
        public bool Label { get; set; }

        [LoadColumn(1)]
        public string HTMLContent { get; set; }
    }
}