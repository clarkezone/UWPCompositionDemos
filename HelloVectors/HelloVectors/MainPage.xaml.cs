using AnimatedVisuals;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Diagnostics;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

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

        #region HelloWorld for ShapeVisual
        private void SimpleShapeImperative_Click(object sender, RoutedEventArgs e)
        {
            // Grab the compositor for the window
            compositor = Window.Current.Compositor;

            // Create a new ShapeVisual that will contain our drawings
            Windows.UI.Composition.ShapeVisual shape = compositor.CreateShapeVisual();

            // set this as a child of our host shape from XAML
            SetVisualOnElement(shape);

            

            // Create a circle geometry and set it's radius
            var circleGeometry = compositor.CreateEllipseGeometry();
            circleGeometry.Radius = new System.Numerics.Vector2(30, 30);

            // Create a shape object from the geometry and give it a color and offset
            var circleShape = compositor.CreateSpriteShape(circleGeometry);
            circleShape.FillBrush = compositor.CreateColorBrush(Colors.Orange);
            circleShape.Offset = new Vector2(50f, 50f);

            // Add the circle to our shape visual
            shape.Shapes.Add(circleShape);
        } 
        #endregion

        #region Build a static path with Win2D
        private void SimplePathImperative_Click(object sender, RoutedEventArgs e)
        {
            // Same steps as for SimpleShapeImperative_Click to create, size and host a ShapeVisual
            compositor = Window.Current.Compositor;
            Windows.UI.Composition.ShapeVisual shape = compositor.CreateShapeVisual();
            SetVisualOnElement(shape);

            // use Win2D's CanvasPathBuilder to create a simple path
            CanvasPathBuilder pathBuilder = new CanvasPathBuilder(CanvasDevice.GetSharedDevice());

            pathBuilder.BeginFigure(1, 1);
            pathBuilder.AddLine(300, 300);
            pathBuilder.AddLine(1, 300);
            pathBuilder.EndFigure(CanvasFigureLoop.Closed);

            // create a Win2D CanvasGeomtryobject from the path
            CanvasGeometry triangleGeometry = CanvasGeometry.CreatePath(pathBuilder);

            // create a CompositionPath from the Win2D geometry
            CompositionPath trianglePath = new CompositionPath(triangleGeometry);

            // create a CompositionPathGeometry from the composition path
            CompositionPathGeometry compositionPathGeometry = compositor.CreatePathGeometry(trianglePath);

            // create a SpriteShape from the CompositionPathGeometry, give it a gradient fill and add to our ShapeVisual
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
        #endregion

        #region Morphing between different paths using PathKeyFrameAnimation
        private void PathMorphImperative_Click(object sender, RoutedEventArgs e)
        {
            // Same steps as for SimpleShapeImperative_Click to create, size and host a ShapeVisual
            compositor = Window.Current.Compositor;
            Windows.UI.Composition.ShapeVisual shape = compositor.CreateShapeVisual();
            SetVisualOnElement(shape);

            // Call helper functions that use Win2D to build square and circle path geometries and create CompositionPath's for them
            CanvasGeometry square = BuildSquareGeometry();
            CompositionPath squarePath = new CompositionPath(square);

            CanvasGeometry circle = BuildCircleGeometry();
            CompositionPath circlePath = new CompositionPath(circle);

            // Create a CompositionPathGeometry, CompositionSpriteShape and set offset and fill
            CompositionPathGeometry compositionPathGeometry = compositor.CreatePathGeometry(squarePath);
            CompositionSpriteShape spriteShape = compositor.CreateSpriteShape(compositionPathGeometry);
            spriteShape.Offset = new Vector2(150, 200);
            spriteShape.FillBrush = CreateGradientBrush();

            // Create a PathKeyFrameAnimation to set up the path morph passing in the circle and square paths
            var playAnimation = compositor.CreatePathKeyFrameAnimation();
            playAnimation.Duration = TimeSpan.FromSeconds(4);
            playAnimation.InsertKeyFrame(0, squarePath);
            playAnimation.InsertKeyFrame(0.3F, circlePath);
            playAnimation.InsertKeyFrame(0.6F, circlePath);
            playAnimation.InsertKeyFrame(1.0F, squarePath);

            // Make animation repeat forever and start it
            playAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
            playAnimation.Direction = Windows.UI.Composition.AnimationDirection.Alternate;
            compositionPathGeometry.StartAnimation("Path", playAnimation);

            // Add the SpriteShape to our shape visual
            shape.Shapes.Add(spriteShape);
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
        #endregion

        #region Play a more complex animation imported from After Effects with BodyMovin
        private void BodyMovinImperative_Click(object sender, RoutedEventArgs e)
        {
            ////https://www.lottiefiles.com/427-happy-birthday

            compositor = Window.Current.Compositor;

            SimplePlayer<HappyBirthday> player = new SimplePlayer<HappyBirthday>(Window.Current.Compositor);

            player.SetSize(VectorHost.ActualWidth, VectorHost.ActualHeight);

            SetVisualOnElement(player.AnimatedVisual.RootVisual);

            player.Play();
        }
        #endregion

        private void BodyMovinImperativeAnimationPlayer_Click(object sender, RoutedEventArgs e)
        {
            compositor = Window.Current.Compositor;
            
            Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer avp = new Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer();

            // Imported from here
            // https://www.lottiefiles.com/3415-snowman
            // And converted with Lottie Windows

            avp.Source = new Snowman();
            var ignore = avp.PlayAsync(0, 1.0, false);

            VectorHost.Children.Clear();
            VectorHost.Children.Add(avp);
        }

        private void SetVisualOnElement(Visual visual)
        {
            VectorHost.Children.Clear();
            var rect = new Rectangle() { Fill = new SolidColorBrush(Colors.LightGray), HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch };
            VectorHost.Children.Add(rect);
            // set the size of the shape to match it's XAML host [note for completeness, listen to size change events]
            visual.Size = new System.Numerics.Vector2((float)VectorHost.ActualWidth, (float)VectorHost.ActualHeight);
            ElementCompositionPreview.SetElementChildVisual(rect, visual);
        }
    }
}
