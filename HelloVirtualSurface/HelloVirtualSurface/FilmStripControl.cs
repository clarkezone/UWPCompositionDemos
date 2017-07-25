using System;
using TileManager;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace HelloVirtualSurface
{
    class FilmStripControl : Control, ITileRenderer
    {
        private TileDrawingManager visibleRegionManager;
        //Image Cache

        public FilmStripControl()
        {
            visibleRegionManager = new TileDrawingManager(this);
            //visibleRegionManager tile size
            //only pan
            //only horizontal
        }

        //SizeChanged

        //InitializeComposition

        public void DrawTile(Rect rect, int tileRow, int tileColumn)
        {
            throw new NotImplementedException();
            //draw placeholderimage first
        }

        public void Trim(Rect trimRect)
        {
            throw new NotImplementedException();
        }
    }
}
