using System;
using System.Collections.Generic;
using System.IO;
using matrix_factorization.Common;
using matrix_factorization.ML.Base;
using matrix_factorization.ML.Objects;

using Microsoft.ML;

using Newtonsoft.Json;

namespace matrix_factorization.ML
{
    public class Predictor : BaseML
    {
        public void Predict(string inputDataFile)
        {
            if (!File.Exists(ModelPath))
            {
                Console.WriteLine($"Failed to find model at {ModelPath}");

                return;
            }

            if (!File.Exists(inputDataFile))
            {
                Console.WriteLine($"Failed to find input data at {inputDataFile}");

                return;
            }

            ITransformer mlModel;

            using (var stream = new FileStream(ModelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MlContext.Model.Load(stream, out _);
            }

            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");

                return;
            }

            var predictionEngine = MlContext.Model.CreatePredictionEngine<MusicRating, MusicPrediction>(mlModel);

            var json = File.ReadAllText(inputDataFile);

            var rating = JsonConvert.DeserializeObject<MusicRating>(json);

            var prediction = predictionEngine.Predict(rating);

            Console.WriteLine(
                $"Based on input:{System.Environment.NewLine}" +
                $"Label: {rating.Label} | MusicID: {rating.MusicID} | UserID: {rating.UserID}{System.Environment.NewLine}" +
                $"The music is {(prediction.Score > Constants.SCORE_THRESHOLD ? "recommended" : "not recommended")}");
        }
    }
}