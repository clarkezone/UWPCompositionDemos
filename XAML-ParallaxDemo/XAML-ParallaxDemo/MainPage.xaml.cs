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
            //Only run this code if the app is running on Windows 10 1511 or later because API not supported on earlier versions of Windows

            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract",2)) {

                // Get a referece to a "propertyset" that contains the following keys:
                //  Translation
                //  CenterPoint
                //  Scale
                //  Matrix
                // that represent the state of the scrollview at any moment (i.e. as the user manipulates the scrollviewer with mouse, touch, touchpad)

                CompositionPropertySet scrollerViewerManipulation = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(myScroller);

                Compositor compositor = scrollerViewerManipulation.Compositor;

                // Create the expression
                ExpressionAnimation expression = compositor.CreateExpressionAnimation("ScrollManipululation.Translation.Y * ParallaxMultiplier");

                // wire the ParallaxMultiplier constant into the expression
                expression.SetScalarParameter("ParallaxMultiplier", 0.3f);

                // set "dynamic" reference parameter that will be used to evaluate the current position of the scrollbar every frame
                expression.SetReferenceParameter("ScrollManipululation", scrollerViewerManipulation);

                // Get the background image and start animating it's offset using the expression
                Visual backgroundVisual = ElementCompositionPreview.GetElementVisual(background);
                backgroundVisual.StartAnimation("Offset.Y", expression);
            }
        }
    }
}
