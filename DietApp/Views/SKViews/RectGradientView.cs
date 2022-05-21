using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Views.SKViews
{
    public class RectGradientView : Base.GradientViewBase
    {
        protected override void DrawGradient(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            canvas.DrawRect(0, 0, info.Width, info.Height, paint);
        }
    }
}
