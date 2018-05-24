using System;
using System.Numerics;
using Windows.UI.Composition;

namespace HelloVectors
{
    interface AnimationTarget
    {
        //void CreateInstance(
        //   Compositor compositor,
        //   out Visual rootVisual,
        //   out Vector2 size,
        //   out CompositionPropertySet progressPropertySet,
        //   out string progressPropertyName,
        //   out TimeSpan duration);

        bool TryCreateInstance(
          Compositor compositor,
          out Visual rootVisual,
          out Vector2 size,
          out CompositionPropertySet progressPropertySet,
          out TimeSpan duration,
          out object diagnostics);
    }
    class SimplePlayer<T> where T : AnimationTarget, new()
    {
        T targetAnimation;
        ScalarKeyFrameAnimation playAnimation;
        Compositor _compositor;
        private Visual v;
        private Vector2 size;
        CompositionPropertySet set;
        TimeSpan duration;
        object diagnostics;

        public SimplePlayer(Compositor c)
        {
            _compositor = c;
            targetAnimation = new T();
            targetAnimation.TryCreateInstance(_compositor, out v, out size, out set, out duration, out diagnostics);
        }

        public Visual Visual
        {
            get
            {
                return v;
            }
        }

        public Vector2 Size
        {
            get
            {
                return size;
            }
        }

        public void Play()
        {
            playAnimation = _compositor.CreateScalarKeyFrameAnimation();
            playAnimation.Duration = TimeSpan.FromSeconds(2);
            playAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
            playAnimation.Direction = Windows.UI.Composition.AnimationDirection.Alternate;
            var linearEasing = _compositor.CreateLinearEasingFunction();
            playAnimation.InsertKeyFrame(0, 0, linearEasing);
            playAnimation.InsertKeyFrame(1, 1, linearEasing);
            set.StartAnimation("Progress", playAnimation);
        }
    }
}
