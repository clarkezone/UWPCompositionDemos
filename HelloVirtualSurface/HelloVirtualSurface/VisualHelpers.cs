using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

static class VisualHelpers
{
    private static Compositor currentCompositor;

    public static void SetCompositor(Compositor w)
    {
        currentCompositor = w;
    }

    public static Compositor Compositor(this Window w)
    {
        if (Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent(typeof(Window).FullName,"Compositor"))
        {
            return Window.Current.Compositor;
        }
        if (currentCompositor == null)
        {
            throw new ArgumentException("no compositor");
        }

        return currentCompositor;
    }

    public static void SetSize(this Visual v, FrameworkElement element)
    {
        v.Size = new System.Numerics.Vector2((float)element.ActualWidth, (float)element.ActualHeight);
    }

    public static void FadeVisual(this Visual v, double seconds)
    {
        var fadeAnimation = CreateImplicitFadeAnimation(seconds);
        v.ImplicitAnimations = Window.Current.Compositor().CreateImplicitAnimationCollection();
        v.ImplicitAnimations.Add(nameof(Visual.Opacity), fadeAnimation);
    }

    public static void VisibleFadeElement(this UIElement u)
    {
        ElementCompositionPreview.SetImplicitHideAnimation(u, CreateOpacityAnimation(0.4));
        //TODO fadeIn
    }

    class classHolder
    {
        public classHolder(FrameworkElement element)
        {
            this.hostElement = element;
            this.blurVisual = Window.Current.Compositor().CreateSpriteVisual();
            this.blurVisual.Brush = Window.Current.Compositor().CreateHostBackdropBrush();
            ElementCompositionPreview.SetElementChildVisual(element, blurVisual);
            this.hostElement.SizeChanged += HostElement_SizeChanged;
        }

        private void HostElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            blurVisual.SetSize(this.hostElement);
        }

        SpriteVisual blurVisual;
        FrameworkElement hostElement;

    }

    public static void GlassIt(this FrameworkElement u)
    {
        if (Windows.Foundation.Metadata.ApiInformation.IsMethodPresent(typeof(Compositor).FullName, "CreateHostBackdropBrush"))
        {
            classHolder c = new classHolder(u);
            u.Tag = c;
        }
    }

    //TODO: kill this function
    public static ScalarKeyFrameAnimation CreateOpacityAnimation(double seconds)
    {
        var animation = Window.Current.Compositor().CreateScalarKeyFrameAnimation();
        animation.Target = "Opacity";
        animation.Duration = TimeSpan.FromSeconds(seconds);
        animation.InsertKeyFrame(0, 0);
        animation.InsertKeyFrame(0.25f, 0);
        animation.InsertKeyFrame(1, 1);
        return animation;
    }

    internal static ICompositionAnimationBase CreateOpacityAnimation(double seconds, float finalvalue)
    {
        var animation = Window.Current.Compositor().CreateScalarKeyFrameAnimation();
        animation.Target = "Opacity";
        animation.Duration = TimeSpan.FromSeconds(seconds);
        animation.InsertKeyFrame(1, finalvalue);
        return animation;
    }

    private static CompositionAnimation CreateImplicitFadeAnimation(double seconds)
    {
        var animation = Window.Current.Compositor().CreateScalarKeyFrameAnimation();
        animation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
        //animation.InsertKeyFrame(1.0f, 1.0f);
        animation.Target = nameof(Visual.Opacity);
        animation.Duration = TimeSpan.FromSeconds(seconds);
        return animation;
    }

    internal static ICompositionAnimationBase CreateAnimationGroup(CompositionAnimation listContentShowAnimations, ScalarKeyFrameAnimation listContentOpacityAnimations)
    {
        var group = Window.Current.Compositor().CreateAnimationGroup();
        group.Add(listContentShowAnimations);
        group.Add(listContentOpacityAnimations);
        return group;
    }

    

    internal static CompositionAnimation CreateVerticalOffsetAnimation(double seconds, float offset, double delaySeconds, bool from)
    {
        var animation = Window.Current.Compositor().CreateScalarKeyFrameAnimation();
        if (delaySeconds != 0.0)
        {
            animation.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
            animation.DelayTime = TimeSpan.FromSeconds(delaySeconds);
        }
        animation.Duration = TimeSpan.FromSeconds(seconds);
        animation.Target = "Translation.Y";
        if (from)
        {
            animation.InsertKeyFrame(0, offset);
            animation.InsertKeyFrame(1, 0);
        } else
        {
            animation.InsertKeyFrame(1, offset);
        }
        return animation;
    }

    internal static CompositionAnimation CreateVerticalOffsetAnimation(double seconds, float offset, double delaySeconds)
    {
        return CreateVerticalOffsetAnimation(seconds, offset, delaySeconds, true);
    }

    public static CompositionAnimation CreateVerticalOffsetAnimationFrom(double seconds, float offset)
    {
        return CreateVerticalOffsetAnimation(seconds, offset, 0.0f);
    }

    public static CompositionAnimation CreateVerticalOffsetAnimationTo(double seconds, float offset)
    {
        return CreateVerticalOffsetAnimation(seconds, offset, 0.0f, false);
    }
}

//private void show_element(object sender, RoutedEventArgs e)
//{
//    var tb = new TextBlock();
//    tb.FadeElement();
//    tb.Text = "As if by magic";
//    //tb.Opacity = 0;
//    stacker.Children.Add(tb);

//}
