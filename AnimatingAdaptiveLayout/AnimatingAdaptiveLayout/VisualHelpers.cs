namespace ObjectivePixel.BringCast.Ui.VisualLayer
{
    using System;
    using Windows.UI.Composition;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Hosting;

    static internal class VisualHelpers
    {
        public static void EnableLayoutImplicitAnimations(this UIElement element, TimeSpan t)
        {
            Compositor compositor;
            var result = element.GetVisual();
            compositor = result.Compositor;

            var elementImplicitAnimation = compositor.CreateImplicitAnimationCollection();
            elementImplicitAnimation[nameof(Visual.Offset)] = CreateOffsetAnimation(compositor, t);
            elementImplicitAnimation[nameof(Visual.Opacity)] = CreateOpacityAnimation(compositor, t);
            result.ImplicitAnimations = elementImplicitAnimation;
        }

        public static void EnableLayoutImplicitAnimations(this UIElement element)
        {
            EnableLayoutImplicitAnimations(element, TimeSpan.FromSeconds(0.9));
        }

        private static KeyFrameAnimation CreateOffsetAnimation(Compositor compositor, TimeSpan duration)
        {
            Vector3KeyFrameAnimation kf = compositor.CreateVector3KeyFrameAnimation();
            kf.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            kf.Duration = duration;
            kf.Target = "Offset";
            return kf;
        }

        public static KeyFrameAnimation CreateOpacityAnimation(Compositor compositor, TimeSpan duration)
        {
            ScalarKeyFrameAnimation kf = compositor.CreateScalarKeyFrameAnimation();
            kf.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            kf.Duration = duration;
            kf.Target = "Opacity";
            return kf;
        }

        public static Visual GetVisual(this UIElement element)
        {
            return ElementCompositionPreview.GetElementVisual(element);
        }
    }
}
