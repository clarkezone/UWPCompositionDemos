// HelloVectors_win32_cpp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include "HelloVectors_win32.h"
#include "SquareCircleMorph.h"
#include <iostream>

using namespace winrt;
using namespace Windows::Foundation::Numerics;

struct GeoSource final : implements<GeoSource,
	Windows::Graphics::IGeometrySource2D,
	ABI::Windows::Graphics::IGeometrySource2DInterop>	
{
public:
	GeoSource(com_ptr<ID2D1Geometry> const & pGeometry) :
		_cpGeometry(pGeometry)
	{ }

	IFACEMETHODIMP GetGeometry(ID2D1Geometry** value) override
	{
		_cpGeometry.copy_to(value);
		return S_OK;
	}

	IFACEMETHODIMP TryGetGeometryUsingFactory(ID2D1Factory*, ID2D1Geometry** result) override
	{
		*result = nullptr;
		return E_NOTIMPL;
	}

private:
	com_ptr<ID2D1Geometry> _cpGeometry;
};

void SimpleShape(const Compositor & compositor, const ContainerVisual & root) {

	// Create a new ShapeVisual that will contain our drawings
	ShapeVisual shape = compositor.CreateShapeVisual();
	shape.Size({ 100.0f,100.0f });

	// Create a circle geometry and set it's radius
	auto circleGeometry = compositor.CreateEllipseGeometry();
	circleGeometry.Radius(float2(30, 30));

	// Create a shape object from the geometry and give it a color and offset
	auto circleShape = compositor.CreateSpriteShape(circleGeometry);
	circleShape.FillBrush(compositor.CreateColorBrush(Windows::UI::Colors::Orange()));
	circleShape.Offset(float2(50, 50));

	// Add the circle to our shape visual
	shape.Shapes().Append(circleShape);

	// Add to the visual tree
	root.Children().InsertAtTop(shape);
}

Windows::UI::Composition::CompositionLinearGradientBrush CreateGradientBrush(const Compositor & compositor)
{
	auto gradBrush = compositor.CreateLinearGradientBrush();
	gradBrush.ColorStops().InsertAt(0, compositor.CreateColorGradientStop(0.0f, Windows::UI::Colors::Orange()));
	gradBrush.ColorStops().InsertAt(1, compositor.CreateColorGradientStop(0.5f, Windows::UI::Colors::Yellow()));
	gradBrush.ColorStops().InsertAt(2, compositor.CreateColorGradientStop(1.0f, Windows::UI::Colors::Red()));
	return gradBrush;
}

void SimplePath(const Compositor & compositor, const ContainerVisual & root) {
	// Same steps as for SimpleShapeImperative_Click to create, size and host a ShapeVisual
	ShapeVisual shape = compositor.CreateShapeVisual();

	shape.Size({ 500.0f, 500.0f });

	shape.Offset({ 300.0f, 0.0f, 1.0f });

	com_ptr<ID2D1Factory> d2dFactory;
	check_hresult(D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, d2dFactory.put()));

	com_ptr<GeoSource> result;
	com_ptr<ID2D1PathGeometry> path;
	check_hresult(d2dFactory->CreatePathGeometry(path.put()));
	com_ptr<ID2D1GeometrySink> sink;

	check_hresult(path->Open(sink.put()));
	sink->SetFillMode(D2D1_FILL_MODE_WINDING);
	sink->BeginFigure({ 1, 1 }, D2D1_FIGURE_BEGIN_FILLED);
	sink->AddLine({ 300, 300 });
	sink->AddLine({ 1, 300 });
	sink->EndFigure(D2D1_FIGURE_END_CLOSED);
	check_hresult(sink->Close());

	result.attach(new GeoSource(path));
	CompositionPath trianglePath = CompositionPath(result.as<Windows::Graphics::IGeometrySource2D>());

	// create a CompositionPathGeometry from the composition path
	CompositionPathGeometry compositionPathGeometry = compositor.CreatePathGeometry(trianglePath);

	// create a SpriteShape from the CompositionPathGeometry, give it a gradient fill and add to our ShapeVisual
	CompositionSpriteShape spriteShape = compositor.CreateSpriteShape(compositionPathGeometry);
	spriteShape.FillBrush(CreateGradientBrush(compositor));

	// Add the SpriteShape to our shape visual
	shape.Shapes().Append(spriteShape);

	// Add to the visual tree
	root.Children().InsertAtTop(shape);
}

CompositionPath BuildPath(com_ptr<ID2D1Factory> const & d2dFactory, std::function<void(com_ptr<ID2D1GeometrySink> const & sink)> builder)
{
	com_ptr<GeoSource> result;
	com_ptr<ID2D1PathGeometry> path;
	check_hresult(d2dFactory->CreatePathGeometry(path.put()));
	com_ptr<ID2D1GeometrySink> sink;

	check_hresult(path->Open(sink.put()));
	
	builder(sink);

	check_hresult(sink->Close());

	result.attach(new GeoSource(path));
	CompositionPath trianglePath = CompositionPath(result.as<Windows::Graphics::IGeometrySource2D>());
	return trianglePath;
}

CompositionPath BuildSquarePath(com_ptr<ID2D1Factory> const & d2dFactory)
{
	auto squareBuilder = [](com_ptr<ID2D1GeometrySink> const & sink) {
		sink->SetFillMode(D2D1_FILL_MODE_WINDING);
		sink->BeginFigure({ -90, -146 }, D2D1_FIGURE_BEGIN_FILLED);
		sink->AddBezier({ { -90.0F, -146.0F }, { 176.0F, -148.555F }, { 176.0F, -148.555F } });   
		sink->AddBezier({ { 176.0F, -148.555F }, { 174.445F, 121.445F }, { 174.445F, 121.445F }});
		sink->AddBezier({ { 174.445F, 121.445F }, { -91.555F, 120.0F }, { -91.555F, 120.0F } });
		sink->AddBezier({ { -91.555F, 120.0F }, { -90.0F, -146.0F }, { -90.0F, -146.0F } });
		sink->AddLine({ 1, 300 });
		sink->EndFigure(D2D1_FIGURE_END_CLOSED);
	};

	return BuildPath(d2dFactory, squareBuilder);
}

CompositionPath BuildCirclePath(com_ptr<ID2D1Factory> const & d2dFactory)
{
	auto circleBuilder = [](com_ptr<ID2D1GeometrySink> const & sink) {
		sink->SetFillMode(D2D1_FILL_MODE_WINDING);
		sink->BeginFigure({ 42.223F, -146 }, D2D1_FIGURE_BEGIN_FILLED);
		sink->AddBezier({ { 115.248F, -146 }, { 174.445F, -86.13F }, { 174.445F, -12.277F } });
		sink->AddBezier({ { 174.445F, 61.576F }, { 115.248F, 121.445F }, { 42.223F, 121.445F } });
		sink->AddBezier({ { -30.802F, 121.445F }, { -90, 61.576F }, { -90, -12.277F } });
		sink->AddBezier({ { -90, -86.13F }, { -30.802F, -146 }, { 42.223F, -146 } });
		sink->AddLine({ 1, 300 });
		sink->EndFigure(D2D1_FIGURE_END_CLOSED);
	};

	return BuildPath(d2dFactory, circleBuilder);
}

void PathMorphImperative(const Compositor & compositor, const ContainerVisual & root) {
	// Same steps as for SimpleShapeImperative_Click to create, size and host a ShapeVisual
	ShapeVisual shape = compositor.CreateShapeVisual();
	shape.Size({ 500.0f, 500.0f });
	shape.Offset({600.0f, 0.0f, 1.0f});

	com_ptr<ID2D1Factory> d2dFactory;
	check_hresult(D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, d2dFactory.put()));

	// Call helper functions that use Win2D to build square and circle path geometries and create CompositionPath's for them
	auto squarePath = BuildSquarePath(d2dFactory);

	auto circlePath = BuildCirclePath(d2dFactory);

	// Create a CompositionPathGeometry, CompositionSpriteShape and set offset and fill
	CompositionPathGeometry compositionPathGeometry = compositor.CreatePathGeometry(squarePath);
	CompositionSpriteShape spriteShape = compositor.CreateSpriteShape(compositionPathGeometry);
	spriteShape.Offset(float2(150, 200));
	spriteShape.FillBrush(CreateGradientBrush(compositor));

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

	// Add to the visual tree
	root.Children().InsertAtTop(shape);
}

void LottieOutput(const Compositor & compositor, const ContainerVisual & root) {

	SpriteVisual container = compositor.CreateSpriteVisual();
	container.Size({ 500.0f, 500.0f });
	container.Offset({ 0.0f, 300.0f, 1.0f });

	static std::unique_ptr<AnimatedVisuals::SquareCircleMorph> m_shapeTool = std::make_unique< AnimatedVisuals::SquareCircleMorph>();
	m_shapeTool->TryCreateAnimatedVisual(compositor, container.Children());
	//shape.Size({ 500.0f, 500.0f }); //TODO fix the size using same technique as in 
	m_shapeTool->Play(); //TODO: extract play into this class and also fix sizing

	// Add to the visual tree
	root.Children().InsertAtTop(container);
}

int __stdcall wWinMain(HINSTANCE, HINSTANCE, LPWSTR, int)
{
	init_apartment(apartment_type::single_threaded);
	auto controller = CreateDispatcherQueueController();

	auto buildvisualtree = [](const Windows::UI::Composition::Compositor & comp, const Windows::UI::Composition::Visual & root) {};

	auto func2 =
		[](const Compositor & compositor, const Visual & root) {

		SimpleShape(compositor, root.as<ContainerVisual>());
		SimplePath(compositor, root.as<ContainerVisual>());
		PathMorphImperative(compositor, root.as<ContainerVisual>());
		LottieOutput(compositor, root.as<ContainerVisual>());
	};
	
	CompositionWindow window(func2);
	MSG message;

	while (GetMessage(&message, nullptr, 0, 0))
	{
		DispatchMessage(&message);
	}
	//TODO teardown appartment
}

