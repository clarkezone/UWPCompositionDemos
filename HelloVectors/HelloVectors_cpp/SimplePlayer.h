#pragma once

#include "pch.h"

using namespace Windows::UI::Composition;
using namespace Windows::UI::Xaml::Controls;

//template<typename T>
class SimplePlayer {
	SimplePlayer(const Windows::UI::Compositor & thecompositor) : _compositor(thecompositor)
	{}

private:
	Windows::UI::Xaml::Controls::ScalarKeyFrameAnimation _playAnimation;
	Windows::UI::Compositor _compositor;
	IAnimatedVisual _animatedVisual;
};