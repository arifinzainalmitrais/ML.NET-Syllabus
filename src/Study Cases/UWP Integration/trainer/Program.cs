using System;

using uwp_integration.lib.ML;

using uwp_integration.trainer.Enums;
using uwp_integration.trainer.Helpers;
using uwp_integration.trainer.Objects;

namespace uwp_integration.trainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            var arguments = CommandLineParser.ParseArguments<ProgramArguments>(args);

            switch (arguments.Action)
            {
                case ProgramActions.FEATURE_EXTRACTOR:
                    new WebContentFeatureExtractor().Extract(arguments.TrainingFileName, arguments.TestingFileName, 
                        arguments.TrainingOutputFileName, arguments.TestingOutputFileName);
                    break;
                case ProgramActions.PREDICT:
                    var predictor = new WebContentPredictor();

                    var initialization = predictor.Initialize();

                    if (!initialization)
                    {
                        Console.WriteLine("Failed to initialize the model");

                        return;
                    }

                    var prediction = predictor.Predict(arguments.URL);

                    Console.WriteLine($"URL is {(prediction.IsMalicious ? "malicious" : "clean")} with a {prediction.Confidence:P2}% confidence");
                    break;
                case ProgramActions.TRAINING:
                    new WebContentTrainer().Train(arguments.TrainingFileName, arguments.TestingFileName, arguments.ModelFileName);
                    break;
                default:
                    Console.WriteLine($"Unhandled action {arguments.Action}");
                    break;
            }
        }
    }
}