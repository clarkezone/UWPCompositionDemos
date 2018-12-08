using Microsoft.UI.Xaml.Controls;
using System;
using System.Numerics;
using Windows.UI.Composition;

namespace HelloVectors
{
    interface AnimationTarget
    {
        bool TryCreateInstance(
          Compositor compositor,
          out object diagnostics);
    }
    class SimplePlayer<T> where T : IAnimatedVisualSource, new()
    {
        T targetAnimation;
        ScalarKeyFrameAnimation _playAnimation;
        Compositor _compositor;
        private IAnimatedVisual _animatedVisual;
        object diagnostics;

        public SimplePlayer(Compositor c)
        {
            _compositor = c;
            targetAnimation = new T();
            _animatedVisual = targetAnimation.TryCreateAnimatedVisual(_compositor, out diagnostics);
        }

        public IAnimatedVisual AnimatedVisual
        {
            get
            {
                return _animatedVisual;
            }
        }

        public void Play()
        {
            _playAnimation = _compositor.CreateScalarKeyFrameAnimation();
            _playAnimation.Duration = TimeSpan.FromSeconds(2);
            _playAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
            _playAnimation.Direction = Windows.UI.Composition.AnimationDirection.Alternate;
            var linearEasing = _compositor.CreateLinearEasingFunction();
            _playAnimation.InsertKeyFrame(0, 0, linearEasing);
            _playAnimation.InsertKeyFrame(1, 1, linearEasing);
            _animatedVisual.RootVisual.Properties.StartAnimation("Progress", _playAnimation);
        }

        internal void SetSize(double width, double height)
        {
            _animatedVisual.RootVisual.Scale = new Vector3((float)width / _animatedVisual.Size.X, (float)height / _animatedVisual.Size.Y, 1.0f);
        }
    }
}
