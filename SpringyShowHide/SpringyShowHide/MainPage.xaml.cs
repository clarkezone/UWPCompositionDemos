using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

namespace SpringyShowHide
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            githubimage.Visibility = (githubimage.Visibility == Visibility.Collapsed ? githubimage.Visibility = Visibility.Visible : githubimage.Visibility = Visibility.Collapsed);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddShowHide();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveShowHide();
        }

        private void AddShowHide()
        {
            ElementCompositionPreview.SetIsTranslationEnabled(githubimage, true);
            ElementCompositionPreview.SetImplicitShowAnimation(githubimage, CreateSpringAnimation());
            ElementCompositionPreview.SetImplicitHideAnimation(githubimage, CreateOpacityAnimation(0.4, 0));
        }
        private void RemoveShowHide()
        {
            ElementCompositionPreview.SetImplicitShowAnimation(githubimage, null);
            ElementCompositionPreview.SetImplicitHideAnimation(githubimage, null);
        }

        private static ICompositionAnimationBase CreateSpringAnimation()
        {
            var springAnimation = Window.Current.Compositor.CreateSpringScalarAnimation();
            springAnimation.InitialVelocity = 1000.0f;
            springAnimation.DampingRatio = 0.3f;
            springAnimation.Target = "Translation.Y";
            springAnimation.Period = TimeSpan.FromSeconds(0.2);
            return springAnimation;
        }

        internal static ICompositionAnimationBase CreateOpacityAnimation(double seconds, float finalvalue)
        {
            var animation = Window.Current.Compositor.CreateScalarKeyFrameAnimation();
            animation.Target = "Opacity";
            animation.Duration = TimeSpan.FromSeconds(seconds);
            animation.InsertKeyFrame(1, finalvalue);
            return animation;
        }

        
    }
}
