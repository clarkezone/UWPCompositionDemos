//
// Declaration of the MainPage class.
//

#pragma once

#include "MainPage.g.h"

namespace winrt::HelloVectors_cpp::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
		Windows::UI::Composition::Compositor compositor{ nullptr };

        MainPage();

        int32_t MyProperty();
        void MyProperty(int32_t value);

		void SimpleShapeImperative_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);

		void PathMorphImperative_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);
		
		void SimplePathImperative_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);

		Microsoft::Graphics::Canvas::Geometry::CanvasGeometry BuildSquareGeometry();

		Microsoft::Graphics::Canvas::Geometry::CanvasGeometry BuildCircleGeometry();

		Windows::UI::Composition::CompositionLinearGradientBrush CreateGradientBrush();
    };
}	

namespace winrt::HelloVectors_cpp::factory_implementation
{
    struct MainPage : MainPageT<MainPage, implementation::MainPage>
    {
    };
}
