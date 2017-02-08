using System;
using Windows.Foundation.Metadata;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MediaPlaybackViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PopupPlayer : Page
    {
        SpriteVisual playerVisual;
        
        MediaPlayer mediaplayer;

        public PopupPlayer()
        {
            this.InitializeComponent();
            playerVisual = Window.Current.Compositor().CreateSpriteVisual();
            
            ElementCompositionPreview.SetElementChildVisual(playerHolder, playerVisual);
            playerHolder.SizeChanged += PlayerHolder_SizeChanged;
        }

        private void PlayerHolder_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            playerVisual.SetSize(playerHolder);
        }

        internal void SetPlayer(MediaPlayer player)
        {
            mediaplayer = player;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HoookVideo();
        }

        public void HoookVideo()
        {
            var surface = mediaplayer.GetSurface(Window.Current.Compositor());
            playerVisual.Brush = Window.Current.Compositor().CreateSurfaceBrush(surface.CompositionSurface);
        }
    }
}
