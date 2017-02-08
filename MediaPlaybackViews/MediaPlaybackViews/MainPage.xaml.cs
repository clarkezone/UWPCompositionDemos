using System;
using Windows.ApplicationModel.Core;
using Windows.Media.Playback;
using Windows.System.Display;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MediaPlaybackViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaPlayer player;
        SpriteVisual videoVisual;
        DisplayRequest dr = new DisplayRequest();

        public MainPage()
        {
            this.InitializeComponent();

            player = ((App)Application.Current).Player;

            videoVisual = Window.Current.Compositor.CreateSpriteVisual();
            ElementCompositionPreview.SetElementChildVisual(spritehost, videoVisual);
            videoVisual.Brush = Window.Current.Compositor.CreateColorBrush(Colors.Red);
            spritehost.SizeChanged += Spritehost_SizeChanged;

            KeepDisplayAlive();
        }

        protected override void OnDisconnectVisualChildren()
        {
            base.OnDisconnectVisualChildren();
            dr.RequestRelease();
        }

        private void KeepDisplayAlive()
        {
            dr.RequestActive();
        }

        private void Spritehost_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            videoVisual.SetSize(spritehost);
        }

        private void play_click(object sender, RoutedEventArgs e)
        {
            player.SetUriSource(new Uri(url.Text));
            buffering.IsActive = true;
            player.BufferingEnded += async (o, s) =>
            {
                await Dispatcher.RunIdleAsync((p) =>
                {
                    buffering.IsActive = false;
                });
            };
            player.Play();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            mediaPlayerElement.SetMediaPlayer(player);
        }

        private void SpriteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var swapchain = player.GetSurface(Window.Current.Compositor);
            ((App)App.Current).PlayerSwapchain = swapchain;
            videoVisual.Brush = Window.Current.Compositor.CreateSurfaceBrush(swapchain.CompositionSurface);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            mediaPlayerElement.SetMediaPlayer(null);
        }

        private void SpriteCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            videoVisual.Brush = Window.Current.Compositor.CreateColorBrush(Colors.Red);
        }

        private async void openpopupplayer_click(object sender, RoutedEventArgs e)
        {
            PopupPlayer newPlayer = null;
            CoreApplicationView newView = CoreApplication.CreateNewView();
            var newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                newPlayer = new PopupPlayer();
                Window.Current.Content = newPlayer;
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id;

                var player = ((App)Application.Current).Player;
                newPlayer.SetPlayer(player);

                newPlayer.HoookVideo();
            });

            var viewShown = await ApplicationViewSwitcher.TryShowAsViewModeAsync(newViewId, ApplicationViewMode.CompactOverlay);
        }
    }
}
