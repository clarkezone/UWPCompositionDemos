using System;
using System.Numerics;
using Windows.Foundation;

namespace TileManager
{
    public class TileDrawingManager
    {
        private const int TILESIZE = 250;
        private const int DRAWAHEAD = 5; //Up to this many extra tiles will be drawn on each edge outside the viewport
        internal int currentTopLeftTileRow = 0;
        internal int currentTopLeftTileColumn = 0;

        internal int drawnTopTileRow = 0;
        internal int drawnBottomTileRow = 0;
        internal int drawnLeftTileColumn = 0;
        internal int drawnRightTileColumn = 0;
        Size viewPortSize;
        int horizontalVisibleTileCount, verticalVisibleTileCount;
        Vector3 currentPosition;
        ITileRenderer currentRenderer;

        public TileDrawingManager(ITileRenderer renderer)
        {
            this.currentRenderer = renderer;
        }

        public string UpdateVisibleRegion(Vector3 currentPosition)
        {
            this.currentPosition = currentPosition;
            bool stateUpdate = false;
            
            int requiredTopTileRow = Math.Max((int)currentPosition.Y / TILESIZE - DRAWAHEAD, 0);
            int requiredBottomTileRow = (int)(currentPosition.Y + viewPortSize.Height) / TILESIZE + DRAWAHEAD;
            int requiredLeftTileColumn = Math.Max((int)currentPosition.X / TILESIZE - DRAWAHEAD, 0);
            int requiredRightTileColumn = (int)(currentPosition.X + viewPortSize.Width) / TILESIZE + DRAWAHEAD;

            currentTopLeftTileRow = (int)currentPosition.Y / TILESIZE;
            currentTopLeftTileColumn = (int)currentPosition.X / TILESIZE;

            for (int row = requiredTopTileRow; row < drawnTopTileRow; row++)
            {
                for (int column = drawnLeftTileColumn; column <= drawnRightTileColumn; column++)
                {
                    DrawTile(row, column);
                    stateUpdate = true;
                }
            }


            for (int row = drawnBottomTileRow + 1; row <= requiredBottomTileRow; row++)
            {
                for (int column = drawnLeftTileColumn; column <= drawnRightTileColumn; column++)
                {
                    DrawTile(row, column);
                    stateUpdate = true;
                }
            }
            drawnTopTileRow = Math.Min(requiredTopTileRow, drawnTopTileRow);
            drawnBottomTileRow = Math.Max(requiredBottomTileRow, drawnBottomTileRow);


            for (int column = requiredLeftTileColumn; column < drawnLeftTileColumn; column++)
            {
                for (int row = drawnTopTileRow; row <= drawnBottomTileRow; row++)
                {
                    DrawTile(row, column);
                    stateUpdate = true;
                }
            }


            for (int column = drawnRightTileColumn + 1; column <= requiredRightTileColumn; column++)
            {
                for (int row = drawnTopTileRow; row <= drawnBottomTileRow; row++)
                {
                    DrawTile(row, column);
                    stateUpdate = true;
                }
            }

            drawnLeftTileColumn = Math.Min(requiredLeftTileColumn, drawnLeftTileColumn);
            drawnRightTileColumn = Math.Max(requiredRightTileColumn, drawnRightTileColumn);


            //TODO: perf optimization to batch draw tile calls into a single drawingsession scope

            //
            // Consider doing something so that we don't draw tiles above that are simply going to get thrown away 
            // down here - might be as simple as trimming 
            //

            if (stateUpdate)
            {
                Trim(requiredLeftTileColumn, requiredTopTileRow, requiredRightTileColumn, requiredBottomTileRow);
            }

            return $"Left tile:{currentTopLeftTileColumn} Top tile:{currentTopLeftTileRow}";
        }

        public void UpdateViewportSize(Size newSize)
        {
            this.viewPortSize = newSize;
            this.horizontalVisibleTileCount = (int)Math.Ceiling(newSize.Width / (Double)TILESIZE);
            this.verticalVisibleTileCount = (int)Math.Ceiling(newSize.Height / (Double)TILESIZE);

            this.DrawVisibleTiles();
        }

        private Rect GetRectForTile(int row, int column)
        {
            int x = column * TILESIZE;
            int y = row * TILESIZE;
            return new Rect(x, y, TILESIZE, TILESIZE);
            //TODO: refactor above to use below
        }

        private Rect GetRectForTileRange(int tileStartColumn, int tileStartRow, int numColumns, int numRows)
        {
            int x = tileStartColumn * TILESIZE;
            int y = tileStartRow * TILESIZE;
            return new Rect(x, y, numColumns * TILESIZE, numRows * TILESIZE);
        }

        private void DrawVisibleTiles()
        {
            //TODO: drawahead applied to left as well
            for (int row = 0; row < verticalVisibleTileCount + DRAWAHEAD; row++)
            {
                for (int column = 0; column < horizontalVisibleTileCount + DRAWAHEAD; column++)
                {
                    DrawTile(row, column);
                }
            }
            this.drawnRightTileColumn = horizontalVisibleTileCount -1 + DRAWAHEAD;
            this.drawnBottomTileRow = verticalVisibleTileCount -1 + DRAWAHEAD;
        }

        private void DrawTile(int row, int column)
        {
            this.currentRenderer.DrawTile(GetRectForTile(row, column), row, column); //index's are 0 based
        }

        private void Trim(int leftColumn, int topRow, int rightColumn, int bottomRow)
        {
            var trimRect = GetRectForTileRange(
                leftColumn,
                topRow,
                rightColumn - leftColumn + 1,
                bottomRow - topRow + 1);

            this.currentRenderer.Trim(trimRect);

            drawnLeftTileColumn = leftColumn;
            drawnRightTileColumn = rightColumn;
            drawnTopTileRow = topRow;
            drawnBottomTileRow = bottomRow;
        }


    }
}
