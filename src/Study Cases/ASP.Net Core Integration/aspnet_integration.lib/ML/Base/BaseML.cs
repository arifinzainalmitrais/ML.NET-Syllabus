using Microsoft.ML;

namespace aspnet_integration.lib.ML.Base
{
    public class BaseML
    {
        protected const string FEATURES = "Features";

        protected MLContext MlContext;

        public BaseML()
        {
            MlContext = new MLContext(2020);
        }
    }
}