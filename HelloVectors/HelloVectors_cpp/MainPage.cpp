#include "pch.h"
#include "MainPage.h"

using namespace winrt;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Hosting;
using namespace Windows::UI::Composition;
using namespace Windows::Foundation::Numerics;
using namespace Microsoft::Graphics::Canvas;
using namespace Microsoft::Graphics::Canvas::Geometry;

namespace winrt::HelloVectors_cpp::implementation
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

	void MainPage::SimpleShapeImperative_Click(IInspectable const&, RoutedEventArgs const&)
	{
		// Grab the compositor for the window
		compositor = Window::Current().Compositor();

		// Create a new ShapeVisual that will contain our drawings
		ShapeVisual shape = compositor.CreateShapeVisual();

		// set this as a child of our host shape from XAML
		ElementCompositionPreview::SetElementChildVisual(VectorHost(), shape);

		// set the size of the shape to match it's XAML host [note for completeness, listen to size change events]
		shape.Size(float2((float)VectorHost().Width(), (float)VectorHost().Height()));

		// Create a circle geometry and set it's radius
		auto circleGeometry = compositor.CreateEllipseGeometry();
		circleGeometry.Radius(float2(30, 30));

		// Create a shape object from the geometry and give it a color and offset
		auto circleShape = compositor.CreateSpriteShape(circleGeometry);
		circleShape.FillBrush(compositor.CreateColorBrush(Windows::UI::Colors::Orange()));
		circleShape.Offset(float2(50, 50));

		// Add the circle to our shape visual
		shape.Shapes().Append(circleShape);
	}

	void MainPage::SimplePathImperative_Click(IInspectable const&, RoutedEventArgs const&)
	{
		// Same steps as for SimpleShapeImperative_Click to create, size and host a ShapeVisual
		compositor = Window::Current().Compositor();
		ShapeVisual shape = compositor.CreateShapeVisual();
		ElementCompositionPreview::SetElementChildVisual(VectorHost(), shape);
		shape.Size(float2((float)VectorHost().Width(), (float)VectorHost().Height()));

		// use Win2D's CanvasPathBuilder to create a simple path
		auto pathBuilder = CanvasPathBuilder(CanvasDevice::GetSharedDevice());

		pathBuilder.BeginFigure(1, 1);
		pathBuilder.AddLine(300, 300);
		pathBuilder.AddLine(1, 300);
		pathBuilder.EndFigure(CanvasFigureLoop::Closed);

		// create a Win2D CanvasGeomtryobject from the path
		auto triangleGeometry = CanvasGeometry::CreatePath(pathBuilder);

		// create a CompositionPath from the Win2D geometry
		//CanvasGeometry triangleGeometry = CreateTrianglePath();
		CompositionPath trianglePath = CompositionPath(triangleGeometry);

		// create a CompositionPathGeometry from the composition path
		CompositionPathGeometry compositionPathGeometry = compositor.CreatePathGeometry(trianglePath);

		// create a SpriteShape from the CompositionPathGeometry, give it a gradient fill and add to our ShapeVisual
		CompositionSpriteShape spriteShape = compositor.CreateSpriteShape(compositionPathGeometry);
		spriteShape.FillBrush(CreateGradientBrush());

		// Add the SpriteShape to our shape visual
		shape.Shapes().Append(spriteShape);
	}

	void MainPage::PathMorphImperative_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args) {
		// Same steps as for SimpleShapeImperative_Click to create, size and host a ShapeVisual
		compositor = Window::Current().Compositor();
		ShapeVisual shape = compositor.CreateShapeVisual();
		ElementCompositionPreview::SetElementChildVisual(VectorHost(), shape);
		shape.Size(float2((float)VectorHost().Width(), (float)VectorHost().Height()));

		// Call helper functions that use Win2D to build square and circle path geometries and create CompositionPath's for them
		CanvasGeometry square = BuildSquareGeometry();
		CompositionPath squarePath = CompositionPath(square);

		CanvasGeometry circle = BuildCircleGeometry();
		CompositionPath circlePath = CompositionPath(circle);

		// Create a CompositionPathGeometry, CompositionSpriteShape and set offset and fill
		CompositionPathGeometry compositionPathGeometry = compositor.CreatePathGeometry(squarePath);
		CompositionSpriteShape spriteShape = compositor.CreateSpriteShape(compositionPathGeometry);
		spriteShape.Offset(float2(150, 200));
		spriteShape.FillBrush(CreateGradientBrush());

		// Create a PathKeyFrameAnimation to set up the path morph passing in the circle and square paths
		auto playAnimation = compositor.CreatePathKeyFrameAnimation();
		playAnimation.Duration(std::chrono::seconds(4));
		playAnimation.InsertKeyFrame(0, squarePath);
		playAnimation.InsertKeyFrame(0.3F, circlePath);
		playAnimation.InsertKeyFrame(0.6F, circlePath);
		playAnimation.InsertKeyFrame(1.0F, squarePath);

		// Make animation repeat forever and start it
		playAnimation.IterationBehavior(AnimationIterationBehavior::Forever);
		playAnimation.Direction(AnimationDirection::Alternate);
		compositionPathGeometry.StartAnimation(L"Path", playAnimation);

		// Add the SpriteShape to our shape visual
		shape.Shapes().Append(spriteShape);
	}

	CanvasGeometry MainPage::BuildSquareGeometry()
	{
		// use Win2D's CanvasPathBuilder to create a simple path
		auto builder = CanvasPathBuilder(CanvasDevice::GetSharedDevice());

		builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination::Winding);
		builder.BeginFigure(float2(-90, -146));
		builder.AddCubicBezier(float2(-90, -146), float2(176, -148.555F), float2(176, -148.555F));
		builder.AddCubicBezier(float2(176, -148.555F), float2(174.445F, 121.445F), float2(174.445F, 121.445F));
		builder.AddCubicBezier(float2(174.445F, 121.445F), float2(-91.555F, 120), float2(-91.555F, 120));
		builder.AddCubicBezier(float2(-91.555F, 120), float2(-90, -146), float2(-90, -146));
		builder.EndFigure(CanvasFigureLoop::Closed);
		return CanvasGeometry::CreatePath(builder);
	}

	CanvasGeometry MainPage::BuildCircleGeometry()
	{
		// use Win2D's CanvasPathBuilder to create a simple path
		auto builder = CanvasPathBuilder(CanvasDevice::GetSharedDevice());

		builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination::Winding);
		builder.BeginFigure(float2(42.223F, -146));
		builder.AddCubicBezier(float2(115.248F, -146), float2(174.445F, -86.13F), float2(174.445F, -12.277F));
		builder.AddCubicBezier(float2(174.445F, 61.576F), float2(115.248F, 121.445F), float2(42.223F, 121.445F));
		builder.AddCubicBezier(float2(-30.802F, 121.445F), float2(-90, 61.576F), float2(-90, -12.277F));
		builder.AddCubicBezier(float2(-90, -86.13F), float2(-30.802F, -146), float2(42.223F, -146));
		builder.EndFigure(CanvasFigureLoop::Closed);
		return CanvasGeometry::CreatePath(builder);
	}

	Windows::UI::Composition::CompositionLinearGradientBrush MainPage::CreateGradientBrush()
	{
		auto gradBrush = compositor.CreateLinearGradientBrush();
		gradBrush.ColorStops().InsertAt(0, compositor.CreateColorGradientStop(0.0f, Windows::UI::Colors::Orange()));
		gradBrush.ColorStops().InsertAt(1, compositor.CreateColorGradientStop(0.5f, Windows::UI::Colors::Yellow()));
		gradBrush.ColorStops().InsertAt(2, compositor.CreateColorGradientStop(1.0f, Windows::UI::Colors::Red()));
		return gradBrush;
	}



}
