#pragma once
#include "pch.h"
#include "desktopwindow.h"
#include <memory>

using namespace winrt;
using namespace Windows::UI;
using namespace Windows::UI::Composition;
using namespace Windows::UI::Composition::Desktop;

struct CompositionWindow : DesktopWindow<CompositionWindow>
{
	CompositionWindow(std::function<void(const Windows::UI::Composition::Compositor &, const Windows::UI::Composition::Visual &)> func) noexcept : CompositionWindow()
	{
		//TODO: call base
		PrepareVisuals(m_compositor);
		func(m_compositor, m_root);
	}

	CompositionWindow() noexcept
	{
		WNDCLASS wc{};
		wc.hCursor = LoadCursor(nullptr, IDC_ARROW);
		wc.hInstance = reinterpret_cast<HINSTANCE>(&__ImageBase);
		wc.lpszClassName = L"XAML island in Win32";
		wc.style = CS_HREDRAW | CS_VREDRAW;
		wc.lpfnWndProc = WndProc;
		RegisterClass(&wc);
		WINRT_ASSERT(!m_window);

		WINRT_VERIFY(CreateWindow(wc.lpszClassName,
			L"Vectors in Win32",
			WS_OVERLAPPEDWINDOW | WS_VISIBLE,
			CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT,
			nullptr, nullptr, wc.hInstance, this));

		WINRT_ASSERT(m_window);

		NewScale(m_currentDpi);

		//func()
	}

	~CompositionWindow() {
	}

	LRESULT MessageHandler(UINT const message, WPARAM const wparam, LPARAM const lparam) noexcept
	{
		// TODO: handle messages here...
		return base_type::MessageHandler(message, wparam, lparam);
	}

	void NewScale(UINT dpi) {

		auto scaleFactor = (float)dpi / 100;

		/*if (m_scale != nullptr) {
			m_scale.ScaleX(scaleFactor);
			m_scale.ScaleY(scaleFactor);
		}

		ApplyCorrection(scaleFactor);*/
	}

	void ApplyCorrection(double scaleFactor) {
		/*double rightCorrection = (m_rootGrid.Width() * scaleFactor - m_rootGrid.Width()) / scaleFactor;
		double bottomCorrection = (m_rootGrid.Height() * scaleFactor - m_rootGrid.Height()) / scaleFactor;
*/
		
	}

	void DoResize(UINT width, UINT height) {
		m_currentWidth = width;
		m_currentHeight = height;
		
	}

	DesktopWindowTarget CreateDesktopWindowTarget(Compositor const& compositor, HWND window)
	{
		namespace abi = ABI::Windows::UI::Composition::Desktop;

		auto interop = compositor.as<abi::ICompositorDesktopInterop>();
		DesktopWindowTarget target{ nullptr };
		check_hresult(interop->CreateDesktopWindowTarget(window, true, reinterpret_cast<abi::IDesktopWindowTarget**>(put_abi(target))));
		return target;
	}

	void PrepareVisuals(Compositor const& compositor)
	{
		m_target = CreateDesktopWindowTarget(compositor, m_window);
		m_root = compositor.CreateSpriteVisual();
		m_root.RelativeSizeAdjustment({ 1.0f, 1.0f });
		m_root.Brush(compositor.CreateColorBrush({ 0xFF, 0xEF, 0xE4 , 0xB0 }));
		m_target.Root(m_root);
	}

private:
	UINT m_currentWidth = 600;
	UINT m_currentHeight = 600;
	HWND m_interopWindowHandle = nullptr;
	Compositor m_compositor;
	DesktopWindowTarget m_target{ nullptr };
	SpriteVisual m_root{ nullptr };
};