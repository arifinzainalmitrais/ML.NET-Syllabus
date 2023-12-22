using Microsoft.ML.Data;

namespace tensorflow_integration.wpf.ML.Objects
{
    public class ImageDataInputItem
    {
        [LoadColumn(0)]
        public string ImagePath;

        [LoadColumn(1)]
        public string Label;
    }
}