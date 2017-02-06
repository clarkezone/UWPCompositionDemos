using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Shapes;

namespace HelloVirtualSurface
{
    class FastInfoDisplay : Control, IDisposable
    {
        private ContainerVisual rootVisual;
        CanvasSwapChain swapChain;
        private SpriteVisual swapChainVisual;
        private CanvasDevice canvasDevice = null;

        private Rectangle hostElement;

        CancellationTokenSource drawLoopCancellationTokenSource;
        private int drawCount;
        //private bool paused;

        public string Display { get; internal set; }

        public FastInfoDisplay()
        {
            drawLoopCancellationTokenSource = new CancellationTokenSource();
            this.DefaultStyleKey = typeof(FastInfoDisplay);
            this.Display = string.Empty;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            hostElement = GetTemplateChild("DrawHolder") as Rectangle;
            hostElement.SizeChanged += ElementCompositionVisual_SizeChanged;
            rootVisual = Window.Current.Compositor().CreateContainerVisual();
            swapChainVisual = Window.Current.Compositor().CreateSpriteVisual();
            swapChainVisual.Brush = Window.Current.Compositor().CreateColorBrush(Colors.Pink);
            rootVisual.Children.InsertAtTop(swapChainVisual);
            ElementCompositionPreview.SetElementChildVisual(hostElement, rootVisual);
        }

        private void ElementCompositionVisual_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            rootVisual.SetSize(hostElement);
            swapChainVisual.SetSize(hostElement);

            if (canvasDevice != null)
            {
                Dispose();
                canvasDevice = null;
            }

            if (canvasDevice == null)
            {
                canvasDevice = CanvasDevice.GetSharedDevice();
                SetDevice(canvasDevice);
            }
        }

        public void Dispose()
        {
            drawLoopCancellationTokenSource?.Cancel();
            swapChain?.Dispose();
        }

        public void SetDevice(CanvasDevice device)
        {
            drawLoopCancellationTokenSource?.Cancel();

            var displayInfo = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();

            this.swapChain = new CanvasSwapChain(device, (int)this.ActualWidth, (int)this.ActualHeight, displayInfo.LogicalDpi);

            swapChainVisual.Brush = Window.Current.Compositor().CreateSurfaceBrush(CanvasComposition.CreateCompositionSurfaceForSwapChain(Window.Current.Compositor(), swapChain));

            drawLoopCancellationTokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(

                DrawLoop,

                drawLoopCancellationTokenSource.Token,

                TaskCreationOptions.LongRunning,

                TaskScheduler.Default);
        }

        void DrawLoop()
        {
            var canceled = drawLoopCancellationTokenSource.Token;
            try
            {
                // Tracking the previous pause state lets us draw once even after becoming paused,
                // so the label text can change to indicate the paused state.

                bool wasPaused = false;

                while (!canceled.IsCancellationRequested)
                {
                    bool isPaused = false; //= paused;
                                         //if (!isPaused || isPaused != wasPaused)
                    if (!isPaused || isPaused != wasPaused)
                    {
                        DrawSwapChain(swapChain, isPaused);
                        swapChain.Present();
                    }
                    else
                    {
                        // A more sophisticated implementation might want to exit the draw loop when paused,
                        // but to keep things simple we just wait on vblank to yield CPU.

                        swapChain.WaitForVerticalBlank();
                    }
                    wasPaused = isPaused;
                }
                swapChain.Dispose();
            }
            catch (Exception e) when (swapChain.Device.IsDeviceLost(e.HResult))
            {
                swapChain.Device.RaiseDeviceLost();
            }
        }

        void DrawSwapChain(CanvasSwapChain swapChain, bool isPaused)
        {
            ++drawCount;

            using (var ds = swapChain.CreateDrawingSession(Color.FromArgb(80, 0, 0, 0)))
            {
                ds.DrawText(Display, new Rect(0, 0, this.swapChain.Size.Width, this.swapChain.Size.Height), Colors.White, new CanvasTextFormat()
                {
                    FontSize = 30,
                    VerticalAlignment = CanvasVerticalAlignment.Center,
                    HorizontalAlignment = CanvasHorizontalAlignment.Left
                });
            }
        }
    }
}
