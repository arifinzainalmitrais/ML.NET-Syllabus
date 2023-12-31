﻿using uwp_integration.trainer.Enums;

namespace uwp_integration.trainer.Objects
{
    public class ProgramArguments
    {
        public ProgramActions Action { get; set; }

        public string TrainingFileName { get; set; }

        public string TestingFileName { get; set; }

        public string TrainingOutputFileName { get; set; }

        public string TestingOutputFileName { get; set; }

        public string URL { get; set; }

        public string ModelFileName { get; set; }

        public ProgramArguments()
        {
            TrainingOutputFileName = @"..\..\..\..\Data\sampledata.csv";

            TestingOutputFileName = @"..\..\..\..\Data\testdata.csv";
        }
    }
}