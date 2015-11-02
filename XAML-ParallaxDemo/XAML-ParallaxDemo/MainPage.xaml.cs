using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace XAML_ParallaxDemo
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            CompositionPropertySet scrollerViewerManipulation = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(myScroller);

            Compositor compositor = scrollerViewerManipulation.Compositor;

            ExpressionAnimation expression = compositor.CreateExpressionAnimation("ScrollManipululation.Translation.Y * ParallaxMultiplier");

            expression.SetScalarParameter("ParallaxMultiplier", 0.3f);
            expression.SetReferenceParameter("ScrollManipululation", scrollerViewerManipulation);

            Visual textVisual = ElementCompositionPreview.GetElementVisual(background);
            textVisual.StartAnimation("Offset.Y", expression);
        }
    }
}
