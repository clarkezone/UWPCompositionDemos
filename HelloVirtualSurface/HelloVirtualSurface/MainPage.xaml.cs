using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Composition;
using System;
using System.Diagnostics;
using System.Numerics;
using TileManager;
using Windows.Foundation;
using Windows.Graphics;
using Windows.Graphics.DirectX;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Composition.Interactions;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloVirtualSurface
{
    //TODO: Implement draw ahead to avoid items painting when they are already in view
    //TODO: Implement coalescing of begin/end draw calls
    //TODO: fix bug with pan right, pan left, pan up incorrectly trimming the final column out


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IInteractionTrackerOwner, ITileRenderer
    {
        private Compositor compositor;
        private CanvasDevice win2dDevice;
        private CompositionGraphicsDevice comositionGraphicsDevice;
        private SpriteVisual myDrawingVisual;
        private CompositionVirtualDrawingSurface drawingSurface;

        private CompositionSurfaceBrush surfaceBrush;

        private InteractionTracker tracker;
        private VisualInteractionSource interactionSource;

        private CompositionPropertySet animatingPropset;
        private ExpressionAnimation animateMatrix;

        //TODO: dedupe with the one in tile manager
        private const int TILESIZE = 250;
        Random randonGen = new Random();
        private ExpressionAnimation moveSurfaceExpressionAnimation;
        private ExpressionAnimation moveSurfaceUpDownExpressionAnimation;
        private ExpressionAnimation scaleSurfaceUpDownExpressionAnimation;

        private TileDrawingManager visibleRegionManager;

        private float lastTrackerScale = 1f;
        private bool zooming;

        public MainPage()
        {
            this.InitializeComponent();
            InitializeComposition();
            ConfigureSpriteVisual();
            ConfigureInteraction();
            visibleRegionManager = new TileDrawingManager(this);
            startAnimation(surfaceBrush);
            ConfigureInput();
            Window.Current.CoreWindow.PointerPressed += CoreWindow_PointerPressed;
            virtualSurfaceHost.SizeChanged += TheSurface_SizeChanged;
            this.hud.Display = "X:00000.00 Y:00000.00 Scale:00000.00 Left tile:0 Top tile:0";
        }

        private void TheSurface_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            visibleRegionManager.UpdateViewportSize(e.NewSize);

            myDrawingVisual.SetSize(virtualSurfaceHost);
        }

        private void CoreWindow_PointerPressed(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.PointerEventArgs args)
        {
            try
            {
                interactionSource.TryRedirectForManipulation(args.CurrentPoint);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ConfigureInput()
        {
            virtualSurfaceHost.PointerWheelChanged += TheSurface_PointerWheelChanged;
        }

        private void TheSurface_PointerWheelChanged(Object sender, PointerRoutedEventArgs e)
        {
            tracker.TryUpdatePositionWithAdditionalVelocity(new Vector3(-5, 0, 0));
        }

        public void InitializeComposition()
        {
            compositor = ElementCompositionPreview.GetElementVisual(this as UIElement).Compositor;
            win2dDevice = CanvasDevice.GetSharedDevice();
            comositionGraphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(compositor, win2dDevice);
            myDrawingVisual = compositor.CreateSpriteVisual();
            ElementCompositionPreview.SetElementChildVisual(virtualSurfaceHost, myDrawingVisual);
        }

        public void ConfigureSpriteVisual()
        {
            var size = new Windows.Graphics.SizeInt32();
            size.Height = TILESIZE * 10000;
            size.Width = TILESIZE * 10000;

            this.drawingSurface = comositionGraphicsDevice.CreateVirtualDrawingSurface(size, 
                DirectXPixelFormat.B8G8R8A8UIntNormalized, 
                DirectXAlphaMode.Premultiplied);

            this.surfaceBrush = compositor.CreateSurfaceBrush(drawingSurface);
            this.surfaceBrush.Stretch = CompositionStretch.None;
            this.surfaceBrush.HorizontalAlignmentRatio = 0;
            this.surfaceBrush.VerticalAlignmentRatio = 0;
            this.surfaceBrush.TransformMatrix = System.Numerics.Matrix3x2.CreateTranslation(20.0f, 20.0f);

            this.myDrawingVisual.Brush = surfaceBrush;
            this.surfaceBrush.Offset = new System.Numerics.Vector2(0, 0);
        }

        public void ConfigureInteraction()
        {
            this.interactionSource = VisualInteractionSource.Create(myDrawingVisual);
            this.interactionSource.PositionXSourceMode = InteractionSourceMode.EnabledWithInertia;
            this.interactionSource.PositionYSourceMode = InteractionSourceMode.EnabledWithInertia;

            this.interactionSource.ScaleSourceMode = InteractionSourceMode.EnabledWithInertia;

            this.tracker = InteractionTracker.CreateWithOwner(this.compositor, this);
            this.tracker.InteractionSources.Add(this.interactionSource);

            this.moveSurfaceExpressionAnimation = this.compositor.CreateExpressionAnimation("-tracker.Position.X");
            this.moveSurfaceExpressionAnimation.SetReferenceParameter("tracker", this.tracker);

            this.moveSurfaceUpDownExpressionAnimation = this.compositor.CreateExpressionAnimation("-tracker.Position.Y");
            this.moveSurfaceUpDownExpressionAnimation.SetReferenceParameter("tracker", this.tracker);

            this.scaleSurfaceUpDownExpressionAnimation = this.compositor.CreateExpressionAnimation("tracker.Scale");
            this.scaleSurfaceUpDownExpressionAnimation.SetReferenceParameter("tracker", this.tracker);

            this.tracker.MinPosition = new System.Numerics.Vector3(0, 0, 0);
            //TODO: use same consts as tilemanager object
            this.tracker.MaxPosition = new System.Numerics.Vector3(TILESIZE * 10000, TILESIZE * 10000, 0);

            this.tracker.MinScale = 0.01f;
            this.tracker.MaxScale = 100.0f;
        }

        private void startAnimation(CompositionSurfaceBrush brush)
        {
            animatingPropset = compositor.CreatePropertySet();
            animatingPropset.InsertScalar("xcoord", 1.0f);
            animatingPropset.StartAnimation("xcoord", moveSurfaceExpressionAnimation);

            animatingPropset.InsertScalar("ycoord", 1.0f);
            animatingPropset.StartAnimation("ycoord", moveSurfaceUpDownExpressionAnimation);

            animatingPropset.InsertScalar("scale", 1.0f);
            animatingPropset.StartAnimation("scale", scaleSurfaceUpDownExpressionAnimation);

            animateMatrix = compositor.CreateExpressionAnimation("Matrix3x2(props.scale, 0.0, 0.0, props.scale, props.xcoord, props.ycoord)");
            animateMatrix.SetReferenceParameter("props", animatingPropset);

            brush.StartAnimation(nameof(brush.TransformMatrix), animateMatrix);
        }

        private void moveLeft(Object sender, RoutedEventArgs e)
        {
            var result = tracker.TryUpdatePositionWithAdditionalVelocity(new Vector3(400, 0, 0));
        }

        private void moveRight(Object sender, RoutedEventArgs e)
        {
            var result = tracker.TryUpdatePositionWithAdditionalVelocity(new Vector3(-400, 0, 0));
        }

        private void moveUpClick(Object sender, RoutedEventArgs e)
        {
            var result = tracker.TryUpdatePositionWithAdditionalVelocity(new Vector3(0, 400, 0));
        }

        private void moveDownClick(object sender, RoutedEventArgs e)
        {
            var result = tracker.TryUpdatePositionWithAdditionalVelocity(new Vector3(0, -400, 0));
        }

        #region interactionTrackerowner
        public void CustomAnimationStateEntered(InteractionTracker sender, InteractionTrackerCustomAnimationStateEnteredArgs args)
        {
        }

        public async void IdleStateEntered(InteractionTracker sender, InteractionTrackerIdleStateEnteredArgs args)
        {
            if (zooming)
            {
                MessageDialog md = new MessageDialog($"Zoom complete.  Final value:{lastTrackerScale}");
                await md.ShowAsync();
            }

            zooming = false;
        }

        public void InertiaStateEntered(InteractionTracker sender, InteractionTrackerInertiaStateEnteredArgs args)
        {
        }

        public void InteractingStateEntered(InteractionTracker sender, InteractionTrackerInteractingStateEnteredArgs args)
        {
            
        }

        public void RequestIgnored(InteractionTracker sender, InteractionTrackerRequestIgnoredArgs args)
        {
        }

        public void ValuesChanged(InteractionTracker sender, InteractionTrackerValuesChangedArgs args)
        {
            try
            {
                string diags = string.Empty;

                if (lastTrackerScale == args.Scale)
                {
                    diags = visibleRegionManager.UpdateVisibleRegion(sender.Position);
                } else
                {
                    // Don't run tilemanager during a zoom
                    // TODO need custom logic here eg for zoom out
                    zooming = true;
                }

                lastTrackerScale = args.Scale;

                hud.Display = $"X:{sender.Position.X:00000.00} Y:{sender.Position.Y:00000.00} Scale:{sender.Scale:00000.00} " + diags;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region ITileRenderer
        public void DrawTile(Rect rect, int tileRow, int tileColumn)
        {
            Color randomColor = Color.FromArgb((byte)255, (byte)randonGen.Next(255), (byte)randonGen.Next(255), (byte)randonGen.Next(255));
            using (var drawingSession = CanvasComposition.CreateDrawingSession(drawingSurface, rect))
            {
                drawingSession.Clear(randomColor);

                CanvasTextFormat tf = new CanvasTextFormat() { FontSize = 72 };
                drawingSession.DrawText($"{tileColumn},{tileRow}", new Vector2(50, 50), Colors.White, tf);
            }
        }

        public void Trim(Rect trimRect)
        {
            drawingSurface.Trim(new RectInt32[] { new RectInt32 { X = (int)trimRect.X, Y = (int)trimRect.Y, Width = (int)trimRect.Width, Height = (int)trimRect.Height } });
        }
        #endregion

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Drawahead not yet implemented");
            await md.ShowAsync();

            ((CheckBox)sender).IsChecked = false;
        }
    }
}
