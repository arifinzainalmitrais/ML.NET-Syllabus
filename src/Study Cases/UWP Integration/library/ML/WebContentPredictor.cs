using System.Reflection;

using uwp_integration.lib.Common;
using uwp_integration.lib.Data;
using uwp_integration.lib.Helpers;
using uwp_integration.lib.ML.Base;
using uwp_integration.lib.ML.Objects;

using Microsoft.ML;

namespace uwp_integration.lib.ML
{
    public class WebContentPredictor : BaseML
    {
        private ITransformer _model;

        public WebPageResponseItem Predict(string url) => Predict(new WebPageResponseItem(url.ToWebContentString()));

        public bool Initialize()
        {
            var assembly = typeof(WebContentPredictor).GetTypeInfo().Assembly;

            var resource = assembly.GetManifestResourceStream($"uwp_integration.lib.Model.{Constants.MODEL_NAME}");

            if (resource == null)
            {
                return false;
            }

            _model = MlContext.Model.Load(resource, out _);

            return true;
        }

        public WebPageResponseItem Predict(WebPageResponseItem webPage)
        {
            var predictionEngine = MlContext.Model.CreatePredictionEngine<WebPageInputItem, WebPagePredictionItem>(_model);

            var prediction = predictionEngine.Predict(webPage.ToWebPageInputItem());

            webPage.Confidence = prediction.Probability;
            webPage.IsMalicious = prediction.Prediction;

            return webPage;
        }
    }
}