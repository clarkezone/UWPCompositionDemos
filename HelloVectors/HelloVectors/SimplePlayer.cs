using System;
using System.Numerics;
using Windows.UI.Composition;

namespace HelloVectors
{
    interface AnimationTarget
    {
        void CreateInstance(
           Compositor compositor,
           out Visual rootVisual,
           out Vector2 size,
           out CompositionPropertySet progressPropertySet,
           out string progressPropertyName,
           out TimeSpan duration);
    }
    class SimplePlayer<T> where T : AnimationTarget, new()
    {
        T dc;
        ScalarKeyFrameAnimation playAnimation;
        Compositor _compositor;
        private Visual v;
        private string name;
        private Vector2 size;
        CompositionPropertySet set;
        TimeSpan duration;

        public SimplePlayer(Compositor c)
        {
            _compositor = c;
            dc = new T();
            dc.CreateInstance(_compositor, out v, out size, out set, out name, out duration);
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
            set.StartAnimation(name, playAnimation);
        }
    }
}
