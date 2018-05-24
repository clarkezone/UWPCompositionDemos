using HelloVectors;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace Compositions
{
    sealed class SimpleMorphComposition : AnimationTarget
    {
        public void CreateInstance(
            Compositor compositor,
            out Visual rootVisual,
            out Vector2 size,
            out CompositionPropertySet progressPropertySet,
            out string progressPropertyName,
            out TimeSpan duration)
        {
            rootVisual = Instantiator.InstantiateComposition(compositor);
            size = new Vector2(960, 540);
            progressPropertySet = rootVisual.Properties;
            progressPropertyName = "AnimationProgress";
            duration = TimeSpan.FromTicks(50050000);
        }
        
        sealed class Instantiator
        {
            readonly Compositor _c;
            readonly ExpressionAnimation _expressionAnimation;
            ContainerVisual _containerVisual_0000;
            
            internal static Visual InstantiateComposition(Compositor compositor)
                => new Instantiator(compositor).ContainerVisual_0000();
            
            Instantiator(Compositor compositor)
            {
                _c = compositor;
                _expressionAnimation = compositor.CreateExpressionAnimation();
            }
            
            CanvasGeometry BuildSquareGeometry()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-90, -146));
                    builder.AddCubicBezier(new Vector2(-90, -146), new Vector2(176, -148.555F), new Vector2(176, -148.555F));
                    builder.AddCubicBezier(new Vector2(176, -148.555F), new Vector2(174.445F, 121.445F), new Vector2(174.445F, 121.445F));
                    builder.AddCubicBezier(new Vector2(174.445F, 121.445F), new Vector2(-91.555F, 120), new Vector2(-91.555F, 120));
                    builder.AddCubicBezier(new Vector2(-91.555F, 120), new Vector2(-90, -146), new Vector2(-90, -146));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            CanvasGeometry BuildCircleGeometry()
            {
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(42.223F, -146));
                    builder.AddCubicBezier(new Vector2(115.248F, -146), new Vector2(174.445F, -86.13F), new Vector2(174.445F, -12.277F));
                    builder.AddCubicBezier(new Vector2(174.445F, 61.576F), new Vector2(115.248F, 121.445F), new Vector2(42.223F, 121.445F));
                    builder.AddCubicBezier(new Vector2(-30.802F, 121.445F), new Vector2(-90, 61.576F), new Vector2(-90, -12.277F));
                    builder.AddCubicBezier(new Vector2(-90, -86.13F), new Vector2(-30.802F, -146), new Vector2(42.223F, -146));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    return CanvasGeometry.CreatePath(builder);
                }
            }
            
            //CanvasGeometry CanvasGeometry_0002()
            //{
            //    using (var builder = new CanvasPathBuilder(null))
            //    {
            //        builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
            //        builder.BeginFigure(new Vector2(-90, -146));
            //        builder.AddCubicBezier(new Vector2(-90, -146), new Vector2(176, -148.555F), new Vector2(176, -148.555F));
            //        builder.AddCubicBezier(new Vector2(176, -148.555F), new Vector2(174.445F, 121.445F), new Vector2(174.445F, 121.445F));
            //        builder.AddCubicBezier(new Vector2(174.445F, 121.445F), new Vector2(-91.555F, 120), new Vector2(-91.555F, 120));
            //        builder.AddCubicBezier(new Vector2(-91.555F, 120), new Vector2(-90, -146), new Vector2(-90, -146));
            //        builder.EndFigure(CanvasFigureLoop.Closed);
            //        return CanvasGeometry.CreatePath(builder);
            //    }
            //}
            
            CompositionColorBrush CompositionColorBrush_0000()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x53, 0x53, 0x53));
            }
            
            CompositionColorBrush CompositionColorBrush_0001()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
            }
            
            CompositionContainerShape CompositionContainerShape_0000()
            {
                var result = _c.CreateContainerShape();
                result.Offset = new Vector2(480, 270);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0001());
                return result;
            }
            
            CompositionContainerShape CompositionContainerShape_0001()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                shapes.Add(CompositionSpriteShape_0000());
                return result;
            }
            
            CompositionPathGeometry SquarePathGeometry()
            {
                //var result = _c.CreatePathGeometry(new CompositionPath(CanvasGeometry_0002()));
                var result = _c.CreatePathGeometry(new CompositionPath(BuildSquareGeometry()));
                result.StartAnimation("Path", PathKeyFrameAnimation_0000());
                var controller = result.TryGetAnimationController("Path");
                controller.Pause();
                _expressionAnimation.ClearAllParameters();
                _expressionAnimation.Expression = "root.AnimationProgress";
                _expressionAnimation.SetReferenceParameter("root", ContainerVisual_0000());
                controller.StartAnimation("Progress", _expressionAnimation);
                return result;
            }
            
            CompositionSpriteShape CompositionSpriteShape_0000()
            {
                var result = _c.CreateSpriteShape();
                result.FillBrush = CompositionColorBrush_0000();
                result.Geometry = SquarePathGeometry();
                result.StrokeBrush = CompositionColorBrush_0001();
                result.StrokeMiterLimit = 4;
                result.StrokeThickness = 2;
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
                propertySet.InsertScalar("AnimationProgress", 0);
                var children = result.Children;
                children.InsertAtTop(ShapeVisual_0000());
                return result;
            }
            
            CubicBezierEasingFunction CubicBezierEasingFunction_0000()
            {
                return _c.CreateCubicBezierEasingFunction(new Vector2(0.167F, 0.167F), new Vector2(0.833F, 0.833F));
            }
            
            LinearEasingFunction LinearEasingFunction_0000()
            {
                return _c.CreateLinearEasingFunction();
            }
            
            PathKeyFrameAnimation PathKeyFrameAnimation_0000()
            {
                var result = _c.CreatePathKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(50050000);
                result.InsertKeyFrame(0, new CompositionPath(BuildSquareGeometry()), LinearEasingFunction_0000());
                result.InsertKeyFrame(0.24F, new CompositionPath(BuildCircleGeometry()), CubicBezierEasingFunction_0000());
                return result;
            }
            
            ShapeVisual ShapeVisual_0000()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(960, 540);
                var shapes = result.Shapes;
                shapes.Add(CompositionContainerShape_0000());
                return result;
            }
            
        }
    }
}
