﻿using System;
using System.IO;

using uwp_integration.lib.ML.Base;
using uwp_integration.lib.ML.Objects;

using Microsoft.ML;

namespace uwp_integration.lib.ML
{
    public class WebContentTrainer : BaseML
    {
        public void Train(string trainingFileName, string testingFileName, string modelFileName)
        {
            if (!System.IO.File.Exists(trainingFileName))
            {
                Console.WriteLine($"Failed to find training data file ({trainingFileName}");

                return;
            }

            if (!System.IO.File.Exists(testingFileName))
            {
                Console.WriteLine($"Failed to find test data file ({testingFileName}");

                return;
            }

            var dataView = MlContext.Data.LoadFromTextFile<WebPageInputItem>(trainingFileName, hasHeader: false, separatorChar: '|');

            var dataProcessPipeline = MlContext.Transforms.Text
                .FeaturizeText(FEATURES, nameof(WebPageInputItem.HTMLContent))
                .Append(MlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: FEATURES));

            var trainedModel = dataProcessPipeline.Fit(dataView);

            MlContext.Model.Save(trainedModel, dataView.Schema, Path.Combine(AppContext.BaseDirectory, modelFileName));

            var testingDataView = MlContext.Data.LoadFromTextFile<WebPageInputItem>(testingFileName, hasHeader: false, separatorChar: '|');

            IDataView testDataView = trainedModel.Transform(testingDataView);

            var modelMetrics = MlContext.BinaryClassification.Evaluate(
                data: testDataView);

            Console.WriteLine($"Entropy: {modelMetrics.Entropy}");
            Console.WriteLine($"Log Loss: {modelMetrics.LogLoss}");
            Console.WriteLine($"Log Loss Reduction: {modelMetrics.LogLossReduction}");
        }
    }
}