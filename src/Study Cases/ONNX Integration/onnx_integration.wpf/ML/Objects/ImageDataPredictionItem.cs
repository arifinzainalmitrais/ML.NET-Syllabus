using Microsoft.ML.Data;

namespace onnx_integration.wpf.ML.Objects
{
    public class ImageNetPrediction
    {
        [ColumnName("grid")]
        public float[] PredictedLabels;
    }
}