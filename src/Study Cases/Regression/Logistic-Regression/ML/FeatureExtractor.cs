﻿using System;
using System.IO;
using System.Text;

using logistic_rregression.Common;
using logistic_rregression.ML.Base;

namespace logistic_rregression.ML
{
    public class FeatureExtractor : BaseML
    {
        public void Extract(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);

            using (var streamWriter =
                new StreamWriter(Path.Combine(AppContext.BaseDirectory, $"../../../Data/{Constants.SAMPLE_DATA}")))
            {
                foreach (var file in files)
                {
                    var strings = GetStrings(File.ReadAllBytes(file));

                    streamWriter.WriteLine($"{file.ToLower().Contains("malicious")}\t{strings}");
                }
            }

            Console.WriteLine($"Extracted {files.Length} to {Constants.SAMPLE_DATA}");
        }
    }
}