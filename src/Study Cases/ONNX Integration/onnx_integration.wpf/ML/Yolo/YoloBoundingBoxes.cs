﻿using System.Drawing;

using onnx_integration.wpf.ML.Yolo.Base;

namespace onnx_integration.wpf.ML.Yolo
{
    public class BoundingBoxDimensions : DimensionsBase { }

    public class YoloBoundingBox
    {
        public BoundingBoxDimensions Dimensions { get; set; }

        public string Label { get; set; }

        public float Confidence { get; set; }

        public RectangleF Rect => new RectangleF(Dimensions.X, Dimensions.Y, Dimensions.Width, Dimensions.Height);

        public Color BoxColor { get; set; }
    }
}