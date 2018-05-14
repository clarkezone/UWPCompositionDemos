using Compositions;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloVectors
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Compositor compositor;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SimpleShapeImperative_Click(object sender, RoutedEventArgs e)
        {
            
            compositor = Window.Current.Compositor;
            Windows.UI.Composition.ShapeVisual shape = compositor.CreateShapeVisual();
            ElementCompositionPreview.SetElementChildVisual(VectorHost, shape);
            shape.Size = new System.Numerics.Vector2((float)VectorHost.Width, (float)VectorHost.Height);

            var circleGeometry = compositor.CreateEllipseGeometry();
            circleGeometry.Radius = new System.Numerics.Vector2(30, 30);

            var circleShape = compositor.CreateSpriteShape(circleGeometry);
            circleShape.FillBrush = compositor.CreateColorBrush(Colors.Orange);
            circleShape.Offset = new Vector2(50f, 50f);

            shape.Shapes.Add(circleShape);
        }

        private void SimplePathImperative_Click(object sender, RoutedEventArgs e)
        {
            compositor = Window.Current.Compositor;
            Windows.UI.Composition.ShapeVisual shape = compositor.CreateShapeVisual();
            ElementCompositionPreview.SetElementChildVisual(VectorHost, shape);
            shape.Size = new System.Numerics.Vector2((float)VectorHost.Width, (float)VectorHost.Height);

            CanvasGeometry triangleGeometry = CreateTrianglePath();
            CompositionPath trianglePath = new CompositionPath(triangleGeometry);

            CompositionPathGeometry compositionPathGeometry = compositor.CreatePathGeometry(trianglePath);
            CompositionSpriteShape spriteShape = compositor.CreateSpriteShape(compositionPathGeometry);
            spriteShape.FillBrush = CreateGradientBrush();

            shape.Shapes.Add(spriteShape);
        }

        private CompositionLinearGradientBrush CreateGradientBrush()
        {
            var gradBrush = compositor.CreateLinearGradientBrush();
            gradBrush.ColorStops.Add(compositor.CreateColorGradientStop(0.0f, Colors.Orange));
            gradBrush.ColorStops.Add(compositor.CreateColorGradientStop(0.5f, Colors.Yellow));
            gradBrush.ColorStops.Add(compositor.CreateColorGradientStop(1.0f, Colors.Red));
            return gradBrush;
        }

        private static CanvasGeometry CreateTrianglePath()
        {
            CanvasPathBuilder pathBuilder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice());

            pathBuilder.BeginFigure(1, 1);
            pathBuilder.AddLine(300, 300);
            pathBuilder.AddLine(1, 300);
            pathBuilder.EndFigure(CanvasFigureLoop.Closed);
            return CanvasGeometry.CreatePath(pathBuilder);
        }

        private void PathMorphImperative_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BodyMovinImperative_Click(object sender, RoutedEventArgs e)
        {
            //https://www.lottiefiles.com/427-happy-birthday

            //Animation Class generated with TODO:

            compositor = Window.Current.Compositor;
            Windows.UI.Composition.ShapeVisual shape = compositor.CreateShapeVisual();


            SimplePlayer<HappyBirthdayComposition> player = new SimplePlayer<HappyBirthdayComposition>(Window.Current.Compositor);

            ElementCompositionPreview.SetElementChildVisual(VectorHost, player.Visual);

            player.Play();
        }
    }
}
