#include "pch.h"
#include "MainPage.h"
#include "snowman.h"

using namespace winrt;
using namespace Windows::UI::Xaml;

namespace winrt::HelloAnimatedVisualPlayer_cpp::implementation
{
    MainPage::MainPage()
    {
        InitializeComponent();
    }

    int32_t MainPage::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void MainPage::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

    void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
    {
		AnimatedVisuals::SampleSource s;
		
		avp().Source(s);
		auto async = avp().PlayAsync(0.0, 1.0, false);
    }
}
