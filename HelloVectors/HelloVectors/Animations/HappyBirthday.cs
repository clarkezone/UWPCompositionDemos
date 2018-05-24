using HelloVectors;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;

namespace Compositions
{
    sealed class HappyBirthday : AnimationTarget
    {
        public bool TryCreateInstance(
            Compositor compositor,
            out Visual rootVisual,
            out Vector2 size,
            out CompositionPropertySet progressPropertySet,
            out TimeSpan duration,
            out object diagnostics)
        {
            rootVisual = Instantiator.InstantiateComposition(compositor);
            size = new Vector2(315, 280);
            progressPropertySet = rootVisual.Properties;
            duration = TimeSpan.FromTicks(12670000);
            diagnostics = null;
            return true;
        }
        
        sealed class Instantiator
        {
            readonly Compositor _c;
            readonly ExpressionAnimation _expressionAnimation;
            CanvasGeometry _canvasGeometry_0019;
            CanvasGeometry _canvasGeometry_0021;
            CanvasGeometry _canvasGeometry_0023;
            CompositionColorBrush _compositionColorBrush_0000;
            CompositionColorBrush _compositionColorBrush_0001;
            CompositionColorBrush _compositionColorBrush_0002;
            CompositionColorBrush _compositionColorBrush_0003;
            CompositionColorBrush _compositionColorBrush_0005;
            ContainerVisual _containerVisual_0000;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0001;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0002;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0021;
            ExpressionAnimation _expressionAnimation_0000;
            LinearEasingFunction _linearEasingFunction_0000;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0016;
            ScalarKeyFrameAnimation _scalarKeyFrameAnimation_0017;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0001;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0005;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0008;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0015;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0027;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0028;
            Vector2KeyFrameAnimation _vector2KeyFrameAnimation_0030;
            
            CanvasGeometry CanvasGeometry_0000()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(7.601F, -5.783F));
                    builder.AddCubicBezier(new Vector2(7.601F, -5.783F), new Vector2(2.602F, -5.086F), new Vector2(2.602F, -5.086F));
                    builder.AddCubicBezier(new Vector2(2.602F, -5.086F), new Vector2(-0.764F, -8.713F), new Vector2(-0.764F, -8.713F));
                    builder.AddCubicBezier(new Vector2(-1.352F, -9.346F), new Vector2(-2.597F, -8.99F), new Vector2(-2.76F, -8.141F));
                    builder.AddCubicBezier(new Vector2(-2.76F, -8.141F), new Vector2(-3.693F, -3.281F), new Vector2(-3.693F, -3.281F));
                    builder.AddCubicBezier(new Vector2(-3.693F, -3.281F), new Vector2(-8.301F, -1.223F), new Vector2(-8.301F, -1.223F));
                    builder.AddCubicBezier(new Vector2(-9.173F, -0.833F), new Vector2(-9.229F, 0.367F), new Vector2(-8.387F, 0.807F));
                    builder.AddCubicBezier(new Vector2(-8.387F, 0.807F), new Vector2(-3.962F, 3.114F), new Vector2(-3.962F, 3.114F));
                    builder.AddCubicBezier(new Vector2(-3.962F, 3.114F), new Vector2(-3.445F, 8.013F), new Vector2(-3.445F, 8.013F));
                    builder.AddCubicBezier(new Vector2(-3.346F, 8.941F), new Vector2(-2.2F, 9.346F), new Vector2(-1.503F, 8.694F));
                    builder.AddCubicBezier(new Vector2(-1.503F, 8.694F), new Vector2(2.163F, 5.259F), new Vector2(2.163F, 5.259F));
                    builder.AddCubicBezier(new Vector2(2.163F, 5.259F), new Vector2(7.09F, 6.23F), new Vector2(7.09F, 6.23F));
                    builder.AddCubicBezier(new Vector2(8.019F, 6.411F), new Vector2(8.789F, 5.469F), new Vector2(8.378F, 4.624F));
                    builder.AddCubicBezier(new Vector2(8.378F, 4.624F), new Vector2(6.219F, 0.195F), new Vector2(6.219F, 0.195F));
                    builder.AddCubicBezier(new Vector2(6.219F, 0.195F), new Vector2(8.749F, -4.107F), new Vector2(8.749F, -4.107F));
                    builder.AddCubicBezier(new Vector2(9.228F, -4.926F), new Vector2(8.547F, -5.914F), new Vector2(7.601F, -5.783F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0001()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(10.542F, -8.02F));
                    builder.AddCubicBezier(new Vector2(10.542F, -8.02F), new Vector2(3.609F, -7.053F), new Vector2(3.609F, -7.053F));
                    builder.AddCubicBezier(new Vector2(3.609F, -7.053F), new Vector2(-1.06F, -12.084F), new Vector2(-1.06F, -12.084F));
                    builder.AddCubicBezier(new Vector2(-1.876F, -12.963F), new Vector2(-3.602F, -12.468F), new Vector2(-3.829F, -11.291F));
                    builder.AddCubicBezier(new Vector2(-3.829F, -11.291F), new Vector2(-5.121F, -4.55F), new Vector2(-5.121F, -4.55F));
                    builder.AddCubicBezier(new Vector2(-5.121F, -4.55F), new Vector2(-11.514F, -1.696F), new Vector2(-11.514F, -1.696F));
                    builder.AddCubicBezier(new Vector2(-12.724F, -1.155F), new Vector2(-12.8F, 0.509F), new Vector2(-11.632F, 1.119F));
                    builder.AddCubicBezier(new Vector2(-11.632F, 1.119F), new Vector2(-5.496F, 4.318F), new Vector2(-5.496F, 4.318F));
                    builder.AddCubicBezier(new Vector2(-5.496F, 4.318F), new Vector2(-4.779F, 11.114F), new Vector2(-4.779F, 11.114F));
                    builder.AddCubicBezier(new Vector2(-4.642F, 12.401F), new Vector2(-3.051F, 12.962F), new Vector2(-2.084F, 12.058F));
                    builder.AddCubicBezier(new Vector2(-2.084F, 12.058F), new Vector2(2.999F, 7.295F), new Vector2(2.999F, 7.295F));
                    builder.AddCubicBezier(new Vector2(2.999F, 7.295F), new Vector2(9.835F, 8.642F), new Vector2(9.835F, 8.642F));
                    builder.AddCubicBezier(new Vector2(11.124F, 8.893F), new Vector2(12.19F, 7.585F), new Vector2(11.62F, 6.414F));
                    builder.AddCubicBezier(new Vector2(11.62F, 6.414F), new Vector2(8.627F, 0.269F), new Vector2(8.627F, 0.269F));
                    builder.AddCubicBezier(new Vector2(8.627F, 0.269F), new Vector2(12.136F, -5.695F), new Vector2(12.136F, -5.695F));
                    builder.AddCubicBezier(new Vector2(12.801F, -6.832F), new Vector2(11.854F, -8.203F), new Vector2(10.542F, -8.02F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0002()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.633F, -6.229F));
                    builder.AddCubicBezier(new Vector2(1.633F, -6.229F), new Vector2(-1.096F, -3.945F), new Vector2(-1.096F, -3.945F));
                    builder.AddCubicBezier(new Vector2(-1.096F, -3.945F), new Vector2(-4.463F, -4.856F), new Vector2(-4.463F, -4.856F));
                    builder.AddCubicBezier(new Vector2(-5.051F, -5.015F), new Vector2(-5.661F, -4.337F), new Vector2(-5.442F, -3.768F));
                    builder.AddCubicBezier(new Vector2(-5.442F, -3.768F), new Vector2(-4.183F, -0.516F), new Vector2(-4.183F, -0.516F));
                    builder.AddCubicBezier(new Vector2(-4.183F, -0.516F), new Vector2(-6.17F, 2.436F), new Vector2(-6.17F, 2.436F));
                    builder.AddCubicBezier(new Vector2(-6.546F, 2.995F), new Vector2(-6.131F, 3.732F), new Vector2(-5.463F, 3.681F));
                    builder.AddCubicBezier(new Vector2(-5.463F, 3.681F), new Vector2(-1.958F, 3.407F), new Vector2(-1.958F, 3.407F));
                    builder.AddCubicBezier(new Vector2(-1.958F, 3.407F), new Vector2(0.182F, 6.143F), new Vector2(0.182F, 6.143F));
                    builder.AddCubicBezier(new Vector2(0.587F, 6.661F), new Vector2(1.425F, 6.474F), new Vector2(1.598F, 5.824F));
                    builder.AddCubicBezier(new Vector2(1.598F, 5.824F), new Vector2(2.507F, 2.403F), new Vector2(2.507F, 2.403F));
                    builder.AddCubicBezier(new Vector2(2.507F, 2.403F), new Vector2(5.814F, 1.142F), new Vector2(5.814F, 1.142F));
                    builder.AddCubicBezier(new Vector2(6.437F, 0.903F), new Vector2(6.546F, 0.052F), new Vector2(5.984F, -0.299F));
                    builder.AddCubicBezier(new Vector2(5.984F, -0.299F), new Vector2(3.04F, -2.141F), new Vector2(3.04F, -2.141F));
                    builder.AddCubicBezier(new Vector2(3.04F, -2.141F), new Vector2(2.945F, -5.656F), new Vector2(2.945F, -5.656F));
                    builder.AddCubicBezier(new Vector2(2.925F, -6.325F), new Vector2(2.149F, -6.661F), new Vector2(1.633F, -6.229F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0003()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(2.135F, -8.142F));
                    builder.AddCubicBezier(new Vector2(2.135F, -8.142F), new Vector2(-1.43F, -5.157F), new Vector2(-1.43F, -5.157F));
                    builder.AddCubicBezier(new Vector2(-1.43F, -5.157F), new Vector2(-5.831F, -6.348F), new Vector2(-5.831F, -6.348F));
                    builder.AddCubicBezier(new Vector2(-6.601F, -6.556F), new Vector2(-7.4F, -5.669F), new Vector2(-7.113F, -4.926F));
                    builder.AddCubicBezier(new Vector2(-7.113F, -4.926F), new Vector2(-5.467F, -0.674F), new Vector2(-5.467F, -0.674F));
                    builder.AddCubicBezier(new Vector2(-5.467F, -0.674F), new Vector2(-8.064F, 3.186F), new Vector2(-8.064F, 3.186F));
                    builder.AddCubicBezier(new Vector2(-8.555F, 3.916F), new Vector2(-8.013F, 4.879F), new Vector2(-7.141F, 4.812F));
                    builder.AddCubicBezier(new Vector2(-7.141F, 4.812F), new Vector2(-2.557F, 4.454F), new Vector2(-2.557F, 4.454F));
                    builder.AddCubicBezier(new Vector2(-2.557F, 4.454F), new Vector2(0.239F, 8.029F), new Vector2(0.239F, 8.029F));
                    builder.AddCubicBezier(new Vector2(0.769F, 8.706F), new Vector2(1.864F, 8.462F), new Vector2(2.09F, 7.613F));
                    builder.AddCubicBezier(new Vector2(2.09F, 7.613F), new Vector2(3.277F, 3.141F), new Vector2(3.277F, 3.141F));
                    builder.AddCubicBezier(new Vector2(3.277F, 3.141F), new Vector2(7.602F, 1.493F), new Vector2(7.602F, 1.493F));
                    builder.AddCubicBezier(new Vector2(8.416F, 1.181F), new Vector2(8.556F, 0.068F), new Vector2(7.822F, -0.391F));
                    builder.AddCubicBezier(new Vector2(7.822F, -0.391F), new Vector2(3.974F, -2.799F), new Vector2(3.974F, -2.799F));
                    builder.AddCubicBezier(new Vector2(3.974F, -2.799F), new Vector2(3.851F, -7.393F), new Vector2(3.851F, -7.393F));
                    builder.AddCubicBezier(new Vector2(3.825F, -8.268F), new Vector2(2.81F, -8.707F), new Vector2(2.135F, -8.142F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0004()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(2.281F, -8.697F));
                    builder.AddCubicBezier(new Vector2(2.281F, -8.697F), new Vector2(-1.528F, -5.509F), new Vector2(-1.528F, -5.509F));
                    builder.AddCubicBezier(new Vector2(-1.528F, -5.509F), new Vector2(-6.23F, -6.781F), new Vector2(-6.23F, -6.781F));
                    builder.AddCubicBezier(new Vector2(-7.051F, -7.002F), new Vector2(-7.904F, -6.055F), new Vector2(-7.598F, -5.261F));
                    builder.AddCubicBezier(new Vector2(-7.598F, -5.261F), new Vector2(-5.84F, -0.719F), new Vector2(-5.84F, -0.719F));
                    builder.AddCubicBezier(new Vector2(-5.84F, -0.719F), new Vector2(-8.615F, 3.403F), new Vector2(-8.615F, 3.403F));
                    builder.AddCubicBezier(new Vector2(-9.139F, 4.183F), new Vector2(-8.559F, 5.212F), new Vector2(-7.627F, 5.141F));
                    builder.AddCubicBezier(new Vector2(-7.627F, 5.141F), new Vector2(-2.732F, 4.758F), new Vector2(-2.732F, 4.758F));
                    builder.AddCubicBezier(new Vector2(-2.732F, 4.758F), new Vector2(0.255F, 8.578F), new Vector2(0.255F, 8.578F));
                    builder.AddCubicBezier(new Vector2(0.821F, 9.301F), new Vector2(1.991F, 9.041F), new Vector2(2.232F, 8.133F));
                    builder.AddCubicBezier(new Vector2(2.232F, 8.133F), new Vector2(3.5F, 3.356F), new Vector2(3.5F, 3.356F));
                    builder.AddCubicBezier(new Vector2(3.5F, 3.356F), new Vector2(8.121F, 1.595F), new Vector2(8.121F, 1.595F));
                    builder.AddCubicBezier(new Vector2(8.99F, 1.262F), new Vector2(9.14F, 0.074F), new Vector2(8.357F, -0.417F));
                    builder.AddCubicBezier(new Vector2(8.357F, -0.417F), new Vector2(4.245F, -2.989F), new Vector2(4.245F, -2.989F));
                    builder.AddCubicBezier(new Vector2(4.245F, -2.989F), new Vector2(4.113F, -7.897F), new Vector2(4.113F, -7.897F));
                    builder.AddCubicBezier(new Vector2(4.086F, -8.832F), new Vector2(3.002F, -9.301F), new Vector2(2.281F, -8.697F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0005()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(4.322F, -0.152F));
                    builder.AddCubicBezier(new Vector2(4.322F, -0.152F), new Vector2(2.152F, -1.511F), new Vector2(2.152F, -1.511F));
                    builder.AddCubicBezier(new Vector2(2.152F, -1.511F), new Vector2(2.027F, -4.018F), new Vector2(2.027F, -4.018F));
                    builder.AddCubicBezier(new Vector2(2.005F, -4.456F), new Vector2(1.405F, -4.723F), new Vector2(1.065F, -4.446F));
                    builder.AddCubicBezier(new Vector2(1.065F, -4.446F), new Vector2(-0.882F, -2.861F), new Vector2(-0.882F, -2.861F));
                    builder.AddCubicBezier(new Vector2(-0.882F, -2.861F), new Vector2(-3.344F, -3.565F), new Vector2(-3.344F, -3.565F));
                    builder.AddCubicBezier(new Vector2(-3.81F, -3.698F), new Vector2(-4.222F, -3.25F), new Vector2(-4.039F, -2.804F));
                    builder.AddCubicBezier(new Vector2(-4.039F, -2.804F), new Vector2(-3.072F, -0.466F), new Vector2(-3.072F, -0.466F));
                    builder.AddCubicBezier(new Vector2(-3.072F, -0.466F), new Vector2(-4.469F, 1.607F), new Vector2(-4.469F, 1.607F));
                    builder.AddCubicBezier(new Vector2(-4.733F, 1.999F), new Vector2(-4.419F, 2.531F), new Vector2(-3.935F, 2.505F));
                    builder.AddCubicBezier(new Vector2(-3.935F, 2.505F), new Vector2(-1.392F, 2.366F), new Vector2(-1.392F, 2.366F));
                    builder.AddCubicBezier(new Vector2(-1.392F, 2.366F), new Vector2(0.207F, 4.35F), new Vector2(0.207F, 4.35F));
                    builder.AddCubicBezier(new Vector2(0.509F, 4.723F), new Vector2(1.115F, 4.607F), new Vector2(1.231F, 4.145F));
                    builder.AddCubicBezier(new Vector2(1.231F, 4.145F), new Vector2(1.837F, 1.72F), new Vector2(1.837F, 1.72F));
                    builder.AddCubicBezier(new Vector2(1.837F, 1.72F), new Vector2(4.222F, 0.874F), new Vector2(4.222F, 0.874F));
                    builder.AddCubicBezier(new Vector2(4.676F, 0.712F), new Vector2(4.733F, 0.106F), new Vector2(4.322F, -0.152F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0006()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(4.322F, -0.152F));
                    builder.AddCubicBezier(new Vector2(4.322F, -0.152F), new Vector2(2.152F, -1.51F), new Vector2(2.152F, -1.51F));
                    builder.AddCubicBezier(new Vector2(2.152F, -1.51F), new Vector2(2.027F, -4.017F), new Vector2(2.027F, -4.017F));
                    builder.AddCubicBezier(new Vector2(2.005F, -4.456F), new Vector2(1.405F, -4.723F), new Vector2(1.065F, -4.447F));
                    builder.AddCubicBezier(new Vector2(1.065F, -4.447F), new Vector2(-0.882F, -2.861F), new Vector2(-0.882F, -2.861F));
                    builder.AddCubicBezier(new Vector2(-0.882F, -2.861F), new Vector2(-3.344F, -3.565F), new Vector2(-3.344F, -3.565F));
                    builder.AddCubicBezier(new Vector2(-3.81F, -3.698F), new Vector2(-4.222F, -3.25F), new Vector2(-4.038F, -2.804F));
                    builder.AddCubicBezier(new Vector2(-4.038F, -2.804F), new Vector2(-3.072F, -0.465F), new Vector2(-3.072F, -0.465F));
                    builder.AddCubicBezier(new Vector2(-3.072F, -0.465F), new Vector2(-4.468F, 1.607F), new Vector2(-4.468F, 1.607F));
                    builder.AddCubicBezier(new Vector2(-4.733F, 1.999F), new Vector2(-4.418F, 2.532F), new Vector2(-3.935F, 2.505F));
                    builder.AddCubicBezier(new Vector2(-3.935F, 2.505F), new Vector2(-1.392F, 2.366F), new Vector2(-1.392F, 2.366F));
                    builder.AddCubicBezier(new Vector2(-1.392F, 2.366F), new Vector2(0.207F, 4.35F), new Vector2(0.207F, 4.35F));
                    builder.AddCubicBezier(new Vector2(0.509F, 4.723F), new Vector2(1.115F, 4.608F), new Vector2(1.231F, 4.145F));
                    builder.AddCubicBezier(new Vector2(1.231F, 4.145F), new Vector2(1.837F, 1.72F), new Vector2(1.837F, 1.72F));
                    builder.AddCubicBezier(new Vector2(1.837F, 1.72F), new Vector2(4.222F, 0.874F), new Vector2(4.222F, 0.874F));
                    builder.AddCubicBezier(new Vector2(4.676F, 0.712F), new Vector2(4.733F, 0.106F), new Vector2(4.322F, -0.152F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0007()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(2.206F, -0.078F));
                    builder.AddCubicBezier(new Vector2(2.206F, -0.078F), new Vector2(1.099F, -0.771F), new Vector2(1.099F, -0.771F));
                    builder.AddCubicBezier(new Vector2(1.099F, -0.771F), new Vector2(1.034F, -2.052F), new Vector2(1.034F, -2.052F));
                    builder.AddCubicBezier(new Vector2(1.023F, -2.275F), new Vector2(0.717F, -2.411F), new Vector2(0.543F, -2.27F));
                    builder.AddCubicBezier(new Vector2(0.543F, -2.27F), new Vector2(-0.45F, -1.461F), new Vector2(-0.45F, -1.461F));
                    builder.AddCubicBezier(new Vector2(-0.45F, -1.461F), new Vector2(-1.707F, -1.82F), new Vector2(-1.707F, -1.82F));
                    builder.AddCubicBezier(new Vector2(-1.945F, -1.888F), new Vector2(-2.155F, -1.66F), new Vector2(-2.062F, -1.432F));
                    builder.AddCubicBezier(new Vector2(-2.062F, -1.432F), new Vector2(-1.568F, -0.238F), new Vector2(-1.568F, -0.238F));
                    builder.AddCubicBezier(new Vector2(-1.568F, -0.238F), new Vector2(-2.281F, 0.82F), new Vector2(-2.281F, 0.82F));
                    builder.AddCubicBezier(new Vector2(-2.416F, 1.02F), new Vector2(-2.256F, 1.292F), new Vector2(-2.009F, 1.278F));
                    builder.AddCubicBezier(new Vector2(-2.009F, 1.278F), new Vector2(-0.711F, 1.207F), new Vector2(-0.711F, 1.207F));
                    builder.AddCubicBezier(new Vector2(-0.711F, 1.207F), new Vector2(0.105F, 2.22F), new Vector2(0.105F, 2.22F));
                    builder.AddCubicBezier(new Vector2(0.26F, 2.41F), new Vector2(0.569F, 2.351F), new Vector2(0.628F, 2.115F));
                    builder.AddCubicBezier(new Vector2(0.628F, 2.115F), new Vector2(0.937F, 0.878F), new Vector2(0.937F, 0.878F));
                    builder.AddCubicBezier(new Vector2(0.937F, 0.878F), new Vector2(2.155F, 0.445F), new Vector2(2.155F, 0.445F));
                    builder.AddCubicBezier(new Vector2(2.387F, 0.363F), new Vector2(2.416F, 0.053F), new Vector2(2.206F, -0.078F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0008()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(2.206F, -0.078F));
                    builder.AddCubicBezier(new Vector2(2.206F, -0.078F), new Vector2(1.1F, -0.771F), new Vector2(1.1F, -0.771F));
                    builder.AddCubicBezier(new Vector2(1.1F, -0.771F), new Vector2(1.036F, -2.051F), new Vector2(1.036F, -2.051F));
                    builder.AddCubicBezier(new Vector2(1.024F, -2.275F), new Vector2(0.718F, -2.411F), new Vector2(0.544F, -2.27F));
                    builder.AddCubicBezier(new Vector2(0.544F, -2.27F), new Vector2(-0.45F, -1.461F), new Vector2(-0.45F, -1.461F));
                    builder.AddCubicBezier(new Vector2(-0.45F, -1.461F), new Vector2(-1.706F, -1.82F), new Vector2(-1.706F, -1.82F));
                    builder.AddCubicBezier(new Vector2(-1.944F, -1.888F), new Vector2(-2.156F, -1.659F), new Vector2(-2.062F, -1.432F));
                    builder.AddCubicBezier(new Vector2(-2.062F, -1.432F), new Vector2(-1.568F, -0.238F), new Vector2(-1.568F, -0.238F));
                    builder.AddCubicBezier(new Vector2(-1.568F, -0.238F), new Vector2(-2.281F, 0.82F), new Vector2(-2.281F, 0.82F));
                    builder.AddCubicBezier(new Vector2(-2.416F, 1.02F), new Vector2(-2.255F, 1.292F), new Vector2(-2.008F, 1.278F));
                    builder.AddCubicBezier(new Vector2(-2.008F, 1.278F), new Vector2(-0.711F, 1.207F), new Vector2(-0.711F, 1.207F));
                    builder.AddCubicBezier(new Vector2(-0.711F, 1.207F), new Vector2(0.105F, 2.22F), new Vector2(0.105F, 2.22F));
                    builder.AddCubicBezier(new Vector2(0.26F, 2.411F), new Vector2(0.569F, 2.352F), new Vector2(0.628F, 2.115F));
                    builder.AddCubicBezier(new Vector2(0.628F, 2.115F), new Vector2(0.938F, 0.878F), new Vector2(0.938F, 0.878F));
                    builder.AddCubicBezier(new Vector2(0.938F, 0.878F), new Vector2(2.156F, 0.446F), new Vector2(2.156F, 0.446F));
                    builder.AddCubicBezier(new Vector2(2.387F, 0.363F), new Vector2(2.415F, 0.053F), new Vector2(2.206F, -0.078F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0009()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(2.206F, -0.077F));
                    builder.AddCubicBezier(new Vector2(2.206F, -0.077F), new Vector2(1.1F, -0.771F), new Vector2(1.1F, -0.771F));
                    builder.AddCubicBezier(new Vector2(1.1F, -0.771F), new Vector2(1.036F, -2.051F), new Vector2(1.036F, -2.051F));
                    builder.AddCubicBezier(new Vector2(1.024F, -2.274F), new Vector2(0.718F, -2.411F), new Vector2(0.544F, -2.269F));
                    builder.AddCubicBezier(new Vector2(0.544F, -2.269F), new Vector2(-0.45F, -1.461F), new Vector2(-0.45F, -1.461F));
                    builder.AddCubicBezier(new Vector2(-0.45F, -1.461F), new Vector2(-1.706F, -1.819F), new Vector2(-1.706F, -1.819F));
                    builder.AddCubicBezier(new Vector2(-1.944F, -1.888F), new Vector2(-2.155F, -1.659F), new Vector2(-2.062F, -1.431F));
                    builder.AddCubicBezier(new Vector2(-2.062F, -1.431F), new Vector2(-1.568F, -0.237F), new Vector2(-1.568F, -0.237F));
                    builder.AddCubicBezier(new Vector2(-1.568F, -0.237F), new Vector2(-2.281F, 0.82F), new Vector2(-2.281F, 0.82F));
                    builder.AddCubicBezier(new Vector2(-2.416F, 1.021F), new Vector2(-2.255F, 1.292F), new Vector2(-2.008F, 1.278F));
                    builder.AddCubicBezier(new Vector2(-2.008F, 1.278F), new Vector2(-0.711F, 1.208F), new Vector2(-0.711F, 1.208F));
                    builder.AddCubicBezier(new Vector2(-0.711F, 1.208F), new Vector2(0.105F, 2.221F), new Vector2(0.105F, 2.221F));
                    builder.AddCubicBezier(new Vector2(0.26F, 2.411F), new Vector2(0.569F, 2.352F), new Vector2(0.628F, 2.116F));
                    builder.AddCubicBezier(new Vector2(0.628F, 2.116F), new Vector2(0.938F, 0.878F), new Vector2(0.938F, 0.878F));
                    builder.AddCubicBezier(new Vector2(0.938F, 0.878F), new Vector2(2.156F, 0.446F), new Vector2(2.156F, 0.446F));
                    builder.AddCubicBezier(new Vector2(2.388F, 0.363F), new Vector2(2.415F, 0.054F), new Vector2(2.206F, -0.077F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0010()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(0, -5.832F));
                    builder.AddCubicBezier(new Vector2(3.22F, -5.832F), new Vector2(5.829F, -3.222F), new Vector2(5.829F, 0));
                    builder.AddCubicBezier(new Vector2(5.829F, 3.221F), new Vector2(3.22F, 5.832F), new Vector2(0, 5.832F));
                    builder.AddCubicBezier(new Vector2(-3.22F, 5.832F), new Vector2(-5.829F, 3.221F), new Vector2(-5.829F, 0));
                    builder.AddCubicBezier(new Vector2(-5.829F, -3.222F), new Vector2(-3.22F, -5.832F), new Vector2(0, -5.832F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0011()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-0.001F, -3.888F));
                    builder.AddCubicBezier(new Vector2(2.145F, -3.888F), new Vector2(3.886F, -2.147F), new Vector2(3.886F, 0));
                    builder.AddCubicBezier(new Vector2(3.886F, 2.147F), new Vector2(2.145F, 3.888F), new Vector2(-0.001F, 3.888F));
                    builder.AddCubicBezier(new Vector2(-2.147F, 3.888F), new Vector2(-3.887F, 2.147F), new Vector2(-3.887F, 0));
                    builder.AddCubicBezier(new Vector2(-3.887F, -2.147F), new Vector2(-2.147F, -3.888F), new Vector2(-0.001F, -3.888F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0012()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(4.37F, -5.433F));
                    builder.AddCubicBezier(new Vector2(4.37F, -5.433F), new Vector2(4.286F, 5.433F), new Vector2(4.286F, 5.433F));
                    builder.AddCubicBezier(new Vector2(4.286F, 5.433F), new Vector2(-4.37F, 1.022F), new Vector2(-4.37F, 1.022F));
                    builder.AddCubicBezier(new Vector2(-4.37F, 1.022F), new Vector2(4.37F, -5.433F), new Vector2(4.37F, -5.433F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0013()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-2.376F, -3.394F));
                    builder.AddCubicBezier(new Vector2(-2.376F, -3.394F), new Vector2(2.799F, 1.018F), new Vector2(2.799F, 1.018F));
                    builder.AddCubicBezier(new Vector2(2.799F, 1.018F), new Vector2(-2.799F, 3.394F), new Vector2(-2.799F, 3.394F));
                    builder.AddCubicBezier(new Vector2(-2.799F, 3.394F), new Vector2(-2.376F, -3.394F), new Vector2(-2.376F, -3.394F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0014()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-1.53F, -6.63F));
                    builder.AddCubicBezier(new Vector2(-1.53F, -6.63F), new Vector2(4.974F, -4.639F), new Vector2(4.974F, -4.639F));
                    builder.AddCubicBezier(new Vector2(4.974F, -4.639F), new Vector2(6.505F, 1.99F), new Vector2(6.505F, 1.99F));
                    builder.AddCubicBezier(new Vector2(6.505F, 1.99F), new Vector2(1.532F, 6.63F), new Vector2(1.532F, 6.63F));
                    builder.AddCubicBezier(new Vector2(1.532F, 6.63F), new Vector2(-4.972F, 4.64F), new Vector2(-4.972F, 4.64F));
                    builder.AddCubicBezier(new Vector2(-4.972F, 4.64F), new Vector2(-6.505F, -1.989F), new Vector2(-6.505F, -1.989F));
                    builder.AddCubicBezier(new Vector2(-6.505F, -1.989F), new Vector2(-1.53F, -6.63F), new Vector2(-1.53F, -6.63F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0015()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Alternate);
                    builder.BeginFigure(new Vector2(-2.18F, -3.777F));
                    builder.AddCubicBezier(new Vector2(-2.18F, -3.777F), new Vector2(2.178F, -3.775F), new Vector2(2.178F, -3.775F));
                    builder.AddCubicBezier(new Vector2(2.178F, -3.775F), new Vector2(4.359F, 0.001F), new Vector2(4.359F, 0.001F));
                    builder.AddCubicBezier(new Vector2(4.359F, 0.001F), new Vector2(2.181F, 3.777F), new Vector2(2.181F, 3.777F));
                    builder.AddCubicBezier(new Vector2(2.181F, 3.777F), new Vector2(-2.18F, 3.775F), new Vector2(-2.18F, 3.775F));
                    builder.AddCubicBezier(new Vector2(-2.18F, 3.775F), new Vector2(-4.359F, -0.001F), new Vector2(-4.359F, -0.001F));
                    builder.AddCubicBezier(new Vector2(-4.359F, -0.001F), new Vector2(-2.18F, -3.777F), new Vector2(-2.18F, -3.777F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0016()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(0, -6));
                    builder.AddCubicBezier(new Vector2(53.02F, -6), new Vector2(96, -3.313F), new Vector2(96, 0));
                    builder.AddCubicBezier(new Vector2(96, 3.313F), new Vector2(53.02F, 6), new Vector2(0, 6));
                    builder.AddCubicBezier(new Vector2(-53.02F, 6), new Vector2(-96, 3.313F), new Vector2(-96, 0));
                    builder.AddCubicBezier(new Vector2(-96, -3.313F), new Vector2(-53.02F, -6), new Vector2(0, -6));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0017()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(23.385F, -14.5F));
                    builder.AddCubicBezier(new Vector2(21.475F, -14.5F), new Vector2(19.691F, -14.259F), new Vector2(18.024F, -13.831F));
                    builder.AddCubicBezier(new Vector2(18.565F, -11.961F), new Vector2(19.158F, -10.108F), new Vector2(19.756F, -8.259F));
                    builder.AddCubicBezier(new Vector2(20.901F, -8.541F), new Vector2(22.107F, -8.7F), new Vector2(23.385F, -8.7F));
                    builder.AddCubicBezier(new Vector2(28.22F, -8.7F), new Vector2(32.155F, -4.797F), new Vector2(32.155F, 0));
                    builder.AddCubicBezier(new Vector2(32.155F, 4.796F), new Vector2(28.22F, 8.7F), new Vector2(23.385F, 8.7F));
                    builder.AddCubicBezier(new Vector2(23.385F, 8.7F), new Vector2(4.075F, 8.7F), new Vector2(4.075F, 8.7F));
                    builder.AddCubicBezier(new Vector2(6.172F, 3.382F), new Vector2(11.063F, -6.12F), new Vector2(19.756F, -8.259F));
                    builder.AddCubicBezier(new Vector2(19.158F, -10.108F), new Vector2(18.565F, -11.961F), new Vector2(18.024F, -13.831F));
                    builder.AddCubicBezier(new Vector2(8.639F, -11.418F), new Vector2(3.006F, -2.944F), new Vector2(0, 3.422F));
                    builder.AddCubicBezier(new Vector2(-2.071F, -0.964F), new Vector2(-5.39F, -6.349F), new Vector2(-10.322F, -10.065F));
                    builder.AddCubicBezier(new Vector2(-11.594F, -8.587F), new Vector2(-12.83F, -7.073F), new Vector2(-13.987F, -5.478F));
                    builder.AddCubicBezier(new Vector2(-8.835F, -1.655F), new Vector2(-5.669F, 4.702F), new Vector2(-4.083F, 8.7F));
                    builder.AddCubicBezier(new Vector2(-4.083F, 8.7F), new Vector2(-23.385F, 8.7F), new Vector2(-23.385F, 8.7F));
                    builder.AddCubicBezier(new Vector2(-28.219F, 8.7F), new Vector2(-32.154F, 4.796F), new Vector2(-32.154F, 0));
                    builder.AddCubicBezier(new Vector2(-32.154F, -4.797F), new Vector2(-28.219F, -8.7F), new Vector2(-23.385F, -8.7F));
                    builder.AddCubicBezier(new Vector2(-19.706F, -8.7F), new Vector2(-16.593F, -7.412F), new Vector2(-13.987F, -5.478F));
                    builder.AddCubicBezier(new Vector2(-12.83F, -7.073F), new Vector2(-11.594F, -8.587F), new Vector2(-10.322F, -10.065F));
                    builder.AddCubicBezier(new Vector2(-13.82F, -12.702F), new Vector2(-18.129F, -14.5F), new Vector2(-23.385F, -14.5F));
                    builder.AddCubicBezier(new Vector2(-31.443F, -14.5F), new Vector2(-38, -7.995F), new Vector2(-38, 0));
                    builder.AddCubicBezier(new Vector2(-38, 7.995F), new Vector2(-31.443F, 14.5F), new Vector2(-23.385F, 14.5F));
                    builder.AddCubicBezier(new Vector2(-23.385F, 14.5F), new Vector2(0, 14.5F), new Vector2(0, 14.5F));
                    builder.AddCubicBezier(new Vector2(0, 14.5F), new Vector2(23.385F, 14.5F), new Vector2(23.385F, 14.5F));
                    builder.AddCubicBezier(new Vector2(31.444F, 14.5F), new Vector2(38, 7.995F), new Vector2(38, 0));
                    builder.AddCubicBezier(new Vector2(38, -7.995F), new Vector2(31.444F, -14.5F), new Vector2(23.385F, -14.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0018()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(61.174F, -14.5F));
                    builder.AddCubicBezier(new Vector2(61.174F, -14.5F), new Vector2(-61.174F, -14.5F), new Vector2(-61.174F, -14.5F));
                    builder.AddCubicBezier(new Vector2(-64.393F, -14.5F), new Vector2(-67, -11.904F), new Vector2(-67, -8.7F));
                    builder.AddCubicBezier(new Vector2(-67, -8.7F), new Vector2(-67, 8.7F), new Vector2(-67, 8.7F));
                    builder.AddCubicBezier(new Vector2(-67, 11.904F), new Vector2(-64.393F, 14.5F), new Vector2(-61.174F, 14.5F));
                    builder.AddCubicBezier(new Vector2(-61.174F, 14.5F), new Vector2(61.174F, 14.5F), new Vector2(61.174F, 14.5F));
                    builder.AddCubicBezier(new Vector2(64.393F, 14.5F), new Vector2(67, 11.904F), new Vector2(67, 8.7F));
                    builder.AddCubicBezier(new Vector2(67, 8.7F), new Vector2(67, -8.7F), new Vector2(67, -8.7F));
                    builder.AddCubicBezier(new Vector2(67, -11.904F), new Vector2(64.393F, -14.5F), new Vector2(61.174F, -14.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0019()
            {
                if (_canvasGeometry_0019 != null)
                {
                    return _canvasGeometry_0019;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(56.25F, 46.5F));
                    builder.AddCubicBezier(new Vector2(56.25F, 46.5F), new Vector2(-54.75F, 46.5F), new Vector2(-54.75F, 46.5F));
                    builder.AddCubicBezier(new Vector2(-54.75F, 46.5F), new Vector2(-55, 46.688F), new Vector2(-55, 46.688F));
                    builder.AddCubicBezier(new Vector2(-50.25F, 46.5F), new Vector2(-52.886F, 46.5F), new Vector2(-49.658F, 46.5F));
                    builder.AddCubicBezier(new Vector2(-49.658F, 46.5F), new Vector2(49.658F, 46.5F), new Vector2(49.658F, 46.5F));
                    builder.AddCubicBezier(new Vector2(52.886F, 46.5F), new Vector2(53.25F, 46.75F), new Vector2(56, 46.688F));
                    builder.AddCubicBezier(new Vector2(56, 46.688F), new Vector2(56.25F, 46.5F), new Vector2(56.25F, 46.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return  _canvasGeometry_0019 = CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0020()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(55.5F, -46.5F));
                    builder.AddCubicBezier(new Vector2(55.5F, -46.5F), new Vector2(-55.5F, -46.5F), new Vector2(-55.5F, -46.5F));
                    builder.AddCubicBezier(new Vector2(-55.5F, -46.5F), new Vector2(-55.5F, 40.688F), new Vector2(-55.5F, 40.688F));
                    builder.AddCubicBezier(new Vector2(-55.5F, 43.898F), new Vector2(-52.886F, 46.5F), new Vector2(-49.658F, 46.5F));
                    builder.AddCubicBezier(new Vector2(-49.658F, 46.5F), new Vector2(49.658F, 46.5F), new Vector2(49.658F, 46.5F));
                    builder.AddCubicBezier(new Vector2(52.886F, 46.5F), new Vector2(55.5F, 43.898F), new Vector2(55.5F, 40.688F));
                    builder.AddCubicBezier(new Vector2(55.5F, 40.688F), new Vector2(55.5F, -46.5F), new Vector2(55.5F, -46.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0021()
            {
                if (_canvasGeometry_0021 != null)
                {
                    return _canvasGeometry_0021;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-14.5F, -14.5F));
                    builder.AddCubicBezier(new Vector2(-14.5F, -14.5F), new Vector2(14.5F, -14.5F), new Vector2(14.5F, -14.5F));
                    builder.AddCubicBezier(new Vector2(14.5F, -14.5F), new Vector2(15.036F, -14.207F), new Vector2(15.036F, -14.207F));
                    builder.AddCubicBezier(new Vector2(15.036F, -14.207F), new Vector2(-13.964F, -14.207F), new Vector2(-13.964F, -14.207F));
                    builder.AddCubicBezier(new Vector2(-13.964F, -14.207F), new Vector2(-14.5F, -14.5F), new Vector2(-14.5F, -14.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return  _canvasGeometry_0021 = CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0022()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-14.5F, -14.5F));
                    builder.AddCubicBezier(new Vector2(-14.5F, -14.5F), new Vector2(14.5F, -14.5F), new Vector2(14.5F, -14.5F));
                    builder.AddCubicBezier(new Vector2(14.5F, -14.5F), new Vector2(14.5F, 14.5F), new Vector2(14.5F, 14.5F));
                    builder.AddCubicBezier(new Vector2(14.5F, 14.5F), new Vector2(-14.5F, 14.5F), new Vector2(-14.5F, 14.5F));
                    builder.AddCubicBezier(new Vector2(-14.5F, 14.5F), new Vector2(-14.5F, -14.5F), new Vector2(-14.5F, -14.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0023()
            {
                if (_canvasGeometry_0023 != null)
                {
                    return _canvasGeometry_0023;
                }
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-14.5F, 52));
                    builder.AddCubicBezier(new Vector2(-14.5F, 52), new Vector2(14.5F, 52), new Vector2(14.5F, 52));
                    builder.AddCubicBezier(new Vector2(14.5F, 52), new Vector2(14.5F, 52.25F), new Vector2(14.5F, 52.25F));
                    builder.AddCubicBezier(new Vector2(14.5F, 52.25F), new Vector2(-14.5F, 52.25F), new Vector2(-14.5F, 52.25F));
                    builder.AddCubicBezier(new Vector2(-14.5F, 52.25F), new Vector2(-14.5F, 52), new Vector2(-14.5F, 52));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return  _canvasGeometry_0023 = CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry CanvasGeometry_0024()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-14.5F, -41));
                    builder.AddCubicBezier(new Vector2(-14.5F, -41), new Vector2(14.5F, -41), new Vector2(14.5F, -41));
                    builder.AddCubicBezier(new Vector2(14.5F, -41), new Vector2(14.5F, 52.25F), new Vector2(14.5F, 52.25F));
                    builder.AddCubicBezier(new Vector2(14.5F, 52.25F), new Vector2(-14.5F, 52.25F), new Vector2(-14.5F, 52.25F));
                    builder.AddCubicBezier(new Vector2(-14.5F, 52.25F), new Vector2(-14.5F, -41), new Vector2(-14.5F, -41));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            ColorKeyFrameAnimation ColorKeyFrameAnimation_0000()
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, Color.FromArgb(0x00, 0x03, 0xA9, 0xF4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.09747368F, Color.FromArgb(0x00, 0x03, 0xA9, 0xF4), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1169562F, Color.FromArgb(0xFF, 0x03, 0xA9, 0xF4), CubicBezierEasingFunction_0002());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0000()
            {
                if (_compositionColorBrush_0000 != null)
                {
                    return _compositionColorBrush_0000;
                }
                var result = _compositionColorBrush_0000 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xB9, 0x07));
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0001()
            {
                if (_compositionColorBrush_0001 != null)
                {
                    return _compositionColorBrush_0001;
                }
                var result = _compositionColorBrush_0001 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x09, 0x50, 0x63));
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0002()
            {
                if (_compositionColorBrush_0002 != null)
                {
                    return _compositionColorBrush_0002;
                }
                var result = _compositionColorBrush_0002 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x25, 0xC7, 0x54));
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0003()
            {
                if (_compositionColorBrush_0003 != null)
                {
                    return _compositionColorBrush_0003;
                }
                var result = _compositionColorBrush_0003 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x03, 0xA9, 0xF4));
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0004()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF0, 0xF0, 0xF0));
            }
            
            CompositionColorBrush CompositionColorBrush_0005()
            {
                if (_compositionColorBrush_0005 != null)
                {
                    return _compositionColorBrush_0005;
                }
                var result = _compositionColorBrush_0005 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xD3, 0x64));
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0006()
            {
                var result = _c.CreateColorBrush(Color.FromArgb(0x00, 0x03, 0xA9, 0xF4));
                result.StartAnimation("Color", ColorKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Color");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionColorBrush CompositionColorBrush_0007()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x02, 0x95, 0xD7));
            }
            
            CompositionColorBrush CompositionColorBrush_0008()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xDE, 0xB3, 0x45));
            }
            
            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(219.606F, 61.933F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(219.606F, 61.933F);
                result.RotationAngleInDegrees = -239;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0001());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0001());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0000());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0001()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(219.647F, 61.944F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0002()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(155.771F, 214.44F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(155.771F, 214.44F);
                result.RotationAngleInDegrees = 50;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0003());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0003());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0001());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0003()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(155.828F, 214.455F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0001());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0004()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(78.559F, 168.874F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(78.559F, 168.874F);
                result.RotationAngleInDegrees = -256;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0005());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0004());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0005());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0002());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0005()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(78.54F, 168.865F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0002());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0006()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(97.064F, 84.204F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(97.064F, 84.204F);
                result.RotationAngleInDegrees = -212;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0007());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0006());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0001());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0003());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0007()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(97.039F, 84.191F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0003());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0008()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(257.258F, 159.497F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(257.258F, 159.497F);
                result.RotationAngleInDegrees = 399;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0009());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0007());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0008());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0004());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0009()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(257.231F, 159.483F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0004());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0010()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(133.395F, 26.515F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(133.395F, 26.515F);
                result.RotationAngleInDegrees = -266;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0011());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0009());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0010());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0005());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0011()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(133.378F, 26.508F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0005());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0012()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(252.337F, 213.938F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(252.337F, 213.938F);
                result.RotationAngleInDegrees = 132.9F;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0013());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0011());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0005());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0006());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0013()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(252.32F, 213.932F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0006());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0014()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(261.12F, 26.218F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(261.12F, 26.218F);
                result.RotationAngleInDegrees = 275;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0015());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0012());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0013());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0007());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0015()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(261.111F, 26.215F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0007());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0016()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(35.721F, 103.978F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(35.721F, 103.978F);
                result.RotationAngleInDegrees = -209;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0017());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0014());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0015());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0008());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0017()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(35.712F, 103.975F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0008());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0018()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(62.925F, 234.226F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(62.925F, 234.226F);
                result.RotationAngleInDegrees = 168;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0019());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0016());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0005());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0009());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0019()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(62.916F, 234.223F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0009());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0020()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(214.65F, 244.558F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(214.65F, 244.558F);
                result.RotationAngleInDegrees = 29;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0021());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0017());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0018());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0010());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0021()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(214.65F, 244.558F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0010());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0022()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(183.561F, 32.661F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(183.561F, 32.661F);
                result.RotationAngleInDegrees = 74;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0023());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0019());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0008());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0011());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0023()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(183.561F, 32.661F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0011());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0024()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(61.63F, 139.445F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(61.63F, 139.445F);
                result.RotationAngleInDegrees = 134;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0025());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0020());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0015());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0012());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0025()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(61.63F, 139.445F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0012());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0026()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(120.728F, 247.196F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(120.728F, 247.196F);
                result.RotationAngleInDegrees = -200;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0027());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0021());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0022());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0013());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0027()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(120.728F, 247.196F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0013());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0028()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(248.067F, 112.75F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(248.067F, 112.75F);
                result.RotationAngleInDegrees = -63;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0029());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0023());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0005());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0014());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0029()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(248.067F, 112.75F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0014());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0030()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(95.449F, 44.997F));
                propertySet.InsertVector2("Position", new Vector2(157.5F, 140));
                result.CenterPoint = new Vector2(95.449F, 44.997F);
                result.RotationAngleInDegrees = 262;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0031());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0024());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0025());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0015());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0031()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(95.449F, 44.997F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0015());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0032()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(162, 225);
                result.Offset = new Vector2(0, 11);
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0033());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0026());
                var controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0033()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(162, 225);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0016());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0034()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(161, 128.5F));
                propertySet.InsertVector2("Position", new Vector2(160, 177.5F));
                result.CenterPoint = new Vector2(161, 128.5F);
                result.RotationAngleInDegrees = 10;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0035());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0027());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0028());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0016());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0035()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(161, 115);
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0036());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0029());
                var controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0036()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(161, 100.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0017());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0037()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(161, 128.5F));
                propertySet.InsertVector2("Position", new Vector2(160, 177.5F));
                result.CenterPoint = new Vector2(161, 128.5F);
                result.RotationAngleInDegrees = 10;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0038());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0027());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0028());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0016());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0038()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(161, 128.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0018());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0039()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(162.125F, 225.099F));
                propertySet.InsertVector2("Position", new Vector2(162.125F, 247.599F));
                result.CenterPoint = new Vector2(162.125F, 225.099F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0040());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0030());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0017());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0040()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(161.5F, 178.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0019());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0041()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(161, 128.5F));
                propertySet.InsertVector2("Position", new Vector2(160, 177.5F));
                result.CenterPoint = new Vector2(161, 128.5F);
                result.RotationAngleInDegrees = 10;
                result.Scale = new Vector2(0, 0);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0042());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0027());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("Scale", Vector2KeyFrameAnimation_0028());
                controller = result.TryGetAnimationController("Scale");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0016());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0042()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(157.5F, 140);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0043());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0043()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(160.5F, 128.5F);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0020());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0044()
            {
                var result = _c.CreateContainerShape();
                var propertySet = result.Properties;
                propertySet.InsertVector2("Anchor", new Vector2(162.125F, 225.099F));
                propertySet.InsertVector2("Position", new Vector2(162.125F, 247.599F));
                result.CenterPoint = new Vector2(162.125F, 225.099F);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0045());
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "my.Position-my.Anchor";
                _expressionAnimation.SetReferenceParameter("my", result);
                result.StartAnimation("Offset", _expressionAnimation);
                result.StartAnimation("Position", Vector2KeyFrameAnimation_0030());
                var controller = result.TryGetAnimationController("Position");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                result.StartAnimation("RotationAngleInDegrees", ScalarKeyFrameAnimation_0017());
                controller = result.TryGetAnimationController("RotationAngleInDegrees");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0045()
            {
                var result = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(157.5F, 140);
                result.Offset = new Vector2(0, -11);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0046());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0046()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(160.5F, 184);
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0021());
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0000()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0000()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0001()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0001()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0002()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0002()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0003()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0003()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0004()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0004()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0005()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0005()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0006()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0006()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0007()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0007()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0008()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0008()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0009()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0009()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0010()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0010()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0011()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0011()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0012()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0012()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0013()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0013()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0014()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0014()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0015()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0015()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0016()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0016()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0017()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0017()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0018()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0018()));
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0019()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0019()));
                result.StartAnimation("Path", PathKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Path");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0020()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0021()));
                result.StartAnimation("Path", PathKeyFrameAnimation_0001());
                var controller = result.TryGetAnimationController("Path");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionPathGeometry CompositionPathGeometry_0021()
            {
                var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0023()));
                result.StartAnimation("Path", PathKeyFrameAnimation_0002());
                var controller = result.TryGetAnimationController("Path");
                controller.Pause();
                controller.StartAnimation("Progress", ExpressionAnimation_0000());
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0000()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0000();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0001()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0001();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0002()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0002();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0003()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0003();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0004()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0004();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0005()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0005();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0006()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0006();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0007()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0007();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0008()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0008();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0009()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = CompositionPathGeometry_0009();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0010()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0010();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0011()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0011();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0012()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0012();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeMiterLimit = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0013()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0013();
                result.StrokeBrush = CompositionColorBrush_0002();
                result.StrokeMiterLimit = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0014()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0014();
                result.StrokeBrush = CompositionColorBrush_0003();
                result.StrokeMiterLimit = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0015()
            {
                var result = _c.CreateSpriteShape();
                result.Geometry = CompositionPathGeometry_0015();
                result.StrokeBrush = CompositionColorBrush_0003();
                result.StrokeMiterLimit = 4;
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0016()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0004();
                result.Geometry = CompositionPathGeometry_0016();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0017()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionPathGeometry_0017();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0018()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0006();
                result.Geometry = CompositionPathGeometry_0018();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0019()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0007();
                result.Geometry = CompositionPathGeometry_0019();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0020()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0005();
                result.Geometry = CompositionPathGeometry_0020();
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0021()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0008();
                result.Geometry = CompositionPathGeometry_0021();
                return result;
            }
            
            ContainerVisual ContainerVisual_0000()
            {
                if (_containerVisual_0000 != null)
                {
                    return _containerVisual_0000;
                }
                var result = _containerVisual_0000 = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Progress", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0000());
                return result;
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0000()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.5F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0001()
            {
                if (_cubicBezierEasingFunction_0001 != null)
                {
                    return _cubicBezierEasingFunction_0001;
                }
                return _cubicBezierEasingFunction_0001 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.042F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0002()
            {
                if (_cubicBezierEasingFunction_0002 != null)
                {
                    return _cubicBezierEasingFunction_0002;
                }
                return _cubicBezierEasingFunction_0002 = _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0003()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.897F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0004()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.718F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0005()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.748F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0006()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.478F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0007()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.337F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0008()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.326F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0009()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.09F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0010()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.25F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0011()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.243F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0012()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.463F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0013()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.387F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0014()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.547F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0015()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.477F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0016()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.564F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0017()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0, 0.359F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0018()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.115F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0019()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.937F, 0.946F));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0020()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.084F, 0.101F), new Vector2(0.097F, 0));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0021()
            {
                if (_cubicBezierEasingFunction_0021 != null)
                {
                    return _cubicBezierEasingFunction_0021;
                }
                return _cubicBezierEasingFunction_0021 = _c.CreateCubicBezierEasingFunction(new Vector2(0.333F, 0), new Vector2(0.667F, 1));
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0022()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.029F, 1));
            }
            
            ExpressionAnimation ExpressionAnimation_0000()
            {
                if (_expressionAnimation_0000 != null)
                {
                    return _expressionAnimation_0000;
                }
                var result = _expressionAnimation_0000 = _c.CreateExpressionAnimation();
                result.SetReferenceParameter("_", ContainerVisual_0000());
                result.Expression = "_.Progress";
                return result;
            }
            
            LinearEasingFunction LinearEasingFunction_0000()
            {
                if (_linearEasingFunction_0000 != null)
                {
                    return _linearEasingFunction_0000;
                }
                return _linearEasingFunction_0000 = _c.CreateLinearEasingFunction();
            }
            
            PathKeyFrameAnimation PathKeyFrameAnimation_0000()
            {
                var result = _c.CreatePathKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new CompositionPath(CanvasGeometry_0019()), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.09747636F, new CompositionPath(CanvasGeometry_0020()), CubicBezierEasingFunction_0002());
                return result;
            }
            
            PathKeyFrameAnimation PathKeyFrameAnimation_0001()
            {
                var result = _c.CreatePathKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new CompositionPath(CanvasGeometry_0021()), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4415F, new CompositionPath(CanvasGeometry_0021()), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, new CompositionPath(CanvasGeometry_0022()), CubicBezierEasingFunction_0021());
                return result;
            }
            
            PathKeyFrameAnimation PathKeyFrameAnimation_0002()
            {
                var result = _c.CreatePathKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new CompositionPath(CanvasGeometry_0023()), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2368421F, new CompositionPath(CanvasGeometry_0023()), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5029297F, new CompositionPath(CanvasGeometry_0024()), CubicBezierEasingFunction_0021());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0000()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, -239, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2894737F, -239, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8157895F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0001()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 50, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4473684F, 50, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9736842F, 18, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0002()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, -256, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, -256, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0003()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, -212, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2894737F, -212, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8157895F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0004()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 399, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.131579F, 399, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6578947F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0005()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, -266, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3421053F, -266, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8684211F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0006()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 132.9F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, 132.9F, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0007()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 275, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1842105F, 275, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7105263F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0008()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, -209, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2105263F, -209, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7368421F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0009()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 168, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, 168, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0010()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 29, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3157895F, 29, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8421053F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0011()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 74, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.131579F, 74, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6578947F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0012()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 134, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2105263F, 134, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7368421F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0013()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, -200, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5263158F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0014()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, -63, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, -63, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0015()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 262, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2368421F, 262, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7631579F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0016()
            {
                if (_scalarKeyFrameAnimation_0016 != null)
                {
                    return _scalarKeyFrameAnimation_0016;
                }
                var result = _scalarKeyFrameAnimation_0016 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 10, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.214421F, 10, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3703684F, -23, CubicBezierEasingFunction_0002());
                result.InsertKeyFrame(0.5263158F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ScalarKeyFrameAnimation ScalarKeyFrameAnimation_0017()
            {
                if (_scalarKeyFrameAnimation_0017 != null)
                {
                    return _scalarKeyFrameAnimation_0017;
                }
                var result = _scalarKeyFrameAnimation_0017 = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, 0, LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1429474F, -13, CubicBezierEasingFunction_0002());
                result.InsertKeyFrame(0.2923947F, 17.85F, CubicBezierEasingFunction_0002());
                result.InsertKeyFrame(0.4288394F, 0, CubicBezierEasingFunction_0002());
                return result;
            }
            
            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(315, 280);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                shapes.Add(CompositionContainerShape_0002());
                shapes.Add(CompositionContainerShape_0004());
                shapes.Add(CompositionContainerShape_0006());
                shapes.Add(CompositionContainerShape_0008());
                shapes.Add(CompositionContainerShape_0010());
                shapes.Add(CompositionContainerShape_0012());
                shapes.Add(CompositionContainerShape_0014());
                shapes.Add(CompositionContainerShape_0016());
                shapes.Add(CompositionContainerShape_0018());
                shapes.Add(CompositionContainerShape_0020());
                shapes.Add(CompositionContainerShape_0022());
                shapes.Add(CompositionContainerShape_0024());
                shapes.Add(CompositionContainerShape_0026());
                shapes.Add(CompositionContainerShape_0028());
                shapes.Add(CompositionContainerShape_0030());
                shapes.Add(CompositionContainerShape_0032());
                shapes.Add(CompositionContainerShape_0034());
                shapes.Add(CompositionContainerShape_0037());
                shapes.Add(CompositionContainerShape_0039());
                shapes.Add(CompositionContainerShape_0041());
                shapes.Add(CompositionContainerShape_0044());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0000()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2894737F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8157895F, new Vector2(219.606F, 61.933F), CubicBezierEasingFunction_0000());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0001()
            {
                if (_vector2KeyFrameAnimation_0001 != null)
                {
                    return _vector2KeyFrameAnimation_0001;
                }
                var result = _vector2KeyFrameAnimation_0001 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2894737F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8157895F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0002()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4473684F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9736842F, new Vector2(155.771F, 214.44F), CubicBezierEasingFunction_0003());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0003()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.4473684F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.9736842F, new Vector2(0.67F, 0.67F), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0004()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, new Vector2(78.559F, 168.874F), CubicBezierEasingFunction_0004());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0005()
            {
                if (_vector2KeyFrameAnimation_0005 != null)
                {
                    return _vector2KeyFrameAnimation_0005;
                }
                var result = _vector2KeyFrameAnimation_0005 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0006()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2894737F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8157895F, new Vector2(97.064F, 84.204F), CubicBezierEasingFunction_0005());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0007()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.131579F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6578947F, new Vector2(257.258F, 159.497F), CubicBezierEasingFunction_0006());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0008()
            {
                if (_vector2KeyFrameAnimation_0008 != null)
                {
                    return _vector2KeyFrameAnimation_0008;
                }
                var result = _vector2KeyFrameAnimation_0008 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.131579F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6578947F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0009()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3421053F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8684211F, new Vector2(133.395F, 26.515F), CubicBezierEasingFunction_0007());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0010()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3421053F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8684211F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0011()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, new Vector2(268.337F, 196.938F), CubicBezierEasingFunction_0008());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0012()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1842105F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7105263F, new Vector2(261.12F, 26.218F), CubicBezierEasingFunction_0009());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0013()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.1842105F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7105263F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0014()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2105263F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7368421F, new Vector2(35.721F, 103.978F), CubicBezierEasingFunction_0010());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0015()
            {
                if (_vector2KeyFrameAnimation_0015 != null)
                {
                    return _vector2KeyFrameAnimation_0015;
                }
                var result = _vector2KeyFrameAnimation_0015 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2105263F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7368421F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0016()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, new Vector2(294.925F, 112.226F), CubicBezierEasingFunction_0011());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0017()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3157895F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8421053F, new Vector2(44.65F, 36.558F), CubicBezierEasingFunction_0012());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0018()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3157895F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8421053F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0019()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.131579F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6578947F, new Vector2(183.561F, 32.661F), CubicBezierEasingFunction_0013());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0020()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2105263F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7368421F, new Vector2(61.63F, 139.445F), CubicBezierEasingFunction_0014());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0021()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5263158F, new Vector2(268.728F, 57.196F), CubicBezierEasingFunction_0015());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0022()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.5263158F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0023()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.07894737F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, new Vector2(248.067F, 112.75F), CubicBezierEasingFunction_0016());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0024()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2368421F, new Vector2(157.5F, 140), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7631579F, new Vector2(95.449F, 44.997F), CubicBezierEasingFunction_0017());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0025()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2368421F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.7631579F, new Vector2(1, 1), CubicBezierEasingFunction_0001());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0026()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.3421053F, new Vector2(1, 1), CubicBezierEasingFunction_0018());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0027()
            {
                if (_vector2KeyFrameAnimation_0027 != null)
                {
                    return _vector2KeyFrameAnimation_0027;
                }
                var result = _vector2KeyFrameAnimation_0027 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(160, 177.5F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2728947F, new Vector2(150, 34.5F), CubicBezierEasingFunction_0019());
                result.InsertKeyFrame(0.5263158F, new Vector2(161, 128.5F), CubicBezierEasingFunction_0020());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0028()
            {
                if (_vector2KeyFrameAnimation_0028 != null)
                {
                    return _vector2KeyFrameAnimation_0028;
                }
                var result = _vector2KeyFrameAnimation_0028 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.2728947F, new Vector2(0.58621F, 0.58621F), CubicBezierEasingFunction_0021());
                result.InsertKeyFrame(0.5263158F, new Vector2(1, 1), CubicBezierEasingFunction_0021());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0029()
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.6052632F, new Vector2(0, 0), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.8947368F, new Vector2(1, 1), CubicBezierEasingFunction_0022());
                return result;
            }
            
            Vector2KeyFrameAnimation Vector2KeyFrameAnimation_0030()
            {
                if (_vector2KeyFrameAnimation_0030 != null)
                {
                    return _vector2KeyFrameAnimation_0030;
                }
                var result = _vector2KeyFrameAnimation_0030 = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(12670000);
                result.InsertKeyFrame(0, new Vector2(162.125F, 247.599F), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.214421F, new Vector2(162.125F, 145.599F), CubicBezierEasingFunction_0021());
                result.InsertKeyFrame(0.4288394F, new Vector2(162.125F, 236.099F), CubicBezierEasingFunction_0021());
                return result;
            }
            
            internal static Visual InstantiateComposition(Compositor compositor)
                => new Instantiator(compositor).ContainerVisual_0000();
            
            Instantiator(Compositor compositor)
            {
                _c = compositor;
                _expressionAnimation = compositor.CreateExpressionAnimation();
            }
            
        }
    }
}
