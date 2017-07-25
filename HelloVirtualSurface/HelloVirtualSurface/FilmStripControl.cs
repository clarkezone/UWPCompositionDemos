using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Composition;
using System;
using System.Numerics;
using TileManager;
using Windows.Foundation;
using Windows.Graphics;
using Windows.Graphics.DirectX;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Composition.Interactions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace HelloVirtualSurface
{
    class FilmStripControl : Control, ITileRenderer, IInteractionTrackerOwner
    {
        private const int TILESIZE = 250;

        private TileDrawingManager visibleRegionManager;
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
        private ExpressionAnimation moveSurfaceExpressionAnimation;
        private ExpressionAnimation moveSurfaceUpDownExpressionAnimation;
        private ExpressionAnimation scaleSurfaceUpDownExpressionAnimation;

        //Image Cache

        public FilmStripControl()
        {
            InitializeComposition();
            ConfigureSpriteVisual();
            ConfigureInteraction();
            visibleRegionManager = new TileDrawingManager(this);
            startAnimation(surfaceBrush);

            SizeChanged += FilmStripControl_SizeChanged;

            //visibleRegionManager tile size
            //only pan
            //only horizontal
        }

        private void FilmStripControl_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            visibleRegionManager.UpdateViewportSize(e.NewSize);

            myDrawingVisual.SetSize(this);
        }

        #region Composition Initialization
        private void InitializeComposition()
        {
            compositor = ElementCompositionPreview.GetElementVisual(this as UIElement).Compositor;
            win2dDevice = CanvasDevice.GetSharedDevice();
            comositionGraphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(compositor, win2dDevice);
            myDrawingVisual = compositor.CreateSpriteVisual();
            ElementCompositionPreview.SetElementChildVisual(this, myDrawingVisual);
        }

        
        public void ConfigureSpriteVisual()
        {
            var size = new Windows.Graphics.SizeInt32();

            //TODO:
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

            animateMatrix = compositor.CreateExpressionAnimation("Matrix3x2(1.0, 0.0, 0.0, 1.0, props.xcoord, props.ycoord)");
            animateMatrix.SetReferenceParameter("props", animatingPropset);

            brush.StartAnimation(nameof(brush.TransformMatrix), animateMatrix);
        }
        #endregion

        #region ITileRenderer
        public void DrawTile(Rect rect, int tileRow, int tileColumn)
        {
            Color randomColor = Colors.Blue;
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

        #region interactionTrackerowner
        public void CustomAnimationStateEntered(InteractionTracker sender, InteractionTrackerCustomAnimationStateEnteredArgs args)
        {
        }

        public void IdleStateEntered(InteractionTracker sender, InteractionTrackerIdleStateEnteredArgs args)
        {
            
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
            visibleRegionManager.UpdateVisibleRegion(sender.Position);
        }
        #endregion
    }
}
