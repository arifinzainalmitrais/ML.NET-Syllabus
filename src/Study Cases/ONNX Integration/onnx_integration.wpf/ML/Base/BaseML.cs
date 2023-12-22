using Microsoft.ML;

namespace onnx_integration.wpf.ML.Base
{
    public class BaseML
    {
        protected MLContext MlContext;

        public BaseML()
        {
            MlContext = new MLContext(2020);
        }
    }
}