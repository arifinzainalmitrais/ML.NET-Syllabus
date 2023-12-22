using System;
using System.IO;

using classification.Common;

using Microsoft.ML;

namespace classification.ML.Base
{
    public class BaseML
    {
        protected const string FEATURES = "Features";

        protected static string ModelPath => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_FILENAME);

        protected readonly MLContext MlContext;

        protected BaseML()
        {
            MlContext = new MLContext(2020);
        }
    }
}