using System.IO;

using aspnet_integration.lib.Data;
using aspnet_integration.lib.Helpers;
using aspnet_integration.lib.ML.Base;
using aspnet_integration.lib.ML.Objects;

using Microsoft.ML;

namespace aspnet_integration.lib.ML
{
    public class FileClassificationPredictor : BaseML
    {
        public FileClassificationResponseItem Predict(string fileName)
        {
            var bytes = File.ReadAllBytes(fileName);

            return Predict(new FileClassificationResponseItem(bytes));
        }

        public FileClassificationResponseItem Predict(FileClassificationResponseItem file)
        {
            if (!File.Exists(Common.Constants.MODEL_PATH))
            {
                file.ErrorMessage = $"Model not found ({Common.Constants.MODEL_PATH}) - please train the model first";

                return file;
            }

            ITransformer mlModel;

            using (var stream = new FileStream(Common.Constants.MODEL_PATH, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MlContext.Model.Load(stream, out _);
            }

            var predictionEngine = MlContext.Model.CreatePredictionEngine<FileData, FileDataPrediction>(mlModel);

            var prediction = predictionEngine.Predict(file.ToFileData());

            file.Confidence = prediction.Probability;
            file.IsMalicious = prediction.PredictedLabel;

            return file;
        }
    }
}