using System;
using System.Numerics;
using Windows.Foundation;

namespace TileManager
{
    public class TileDrawingManager
    {
        private const int TILESIZE = 250;
        private const int DRAWAHEAD = 0; //Number of tiles to draw ahead //Note: drawahead doesn't currently work
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
            bool stateUpdate = false;

            //TODO: perf optimization to batch draw tile calls into a single drawingsession scope

            if (currentPosition.X > (currentTopLeftTileColumn + 1) * TILESIZE) // scrolling left, need new items to the right
            {
                stateUpdate = true;
                currentTopLeftTileColumn++;
                this.currentPosition.X += TILESIZE;

                for (int row = currentTopLeftTileRow; row < currentTopLeftTileRow + verticalVisibleTileCount + DRAWAHEAD; row++)
                {
                    for (int column = drawnRightTileColumn + 1; column <= drawnRightTileColumn + 1 + DRAWAHEAD; column++)
                    {
                        DrawTile(row, column);
                    }
                }
                drawnRightTileColumn++;
            } else
            if (currentPosition.X >= 0 && currentPosition.X < (currentTopLeftTileColumn * TILESIZE)) // scrolling right, need new items to the right
            {
                stateUpdate = true;
                currentTopLeftTileColumn--;
                    this.currentPosition.X -= TILESIZE;

                for (int row = currentTopLeftTileRow; row < currentTopLeftTileRow + verticalVisibleTileCount + DRAWAHEAD; row++)
                {
                    for (int column = drawnLeftTileColumn - 1; column >= drawnLeftTileColumn - 1 - DRAWAHEAD; column--)
                    {
                        DrawTile(row, column);
                    }
                }
                drawnLeftTileColumn--;
            } else if (currentPosition.Y > (currentTopLeftTileRow + 1) * TILESIZE) // scrolling down, need new items on bottom
            {
                stateUpdate = true;
                currentTopLeftTileRow++;
                this.currentPosition.Y += TILESIZE;

                for (int row = drawnBottomTileRow + 1; row <= drawnBottomTileRow + 1 + DRAWAHEAD; row++)
                {
                    for (int column = drawnLeftTileColumn; column <= drawnRightTileColumn; column++)
                    {
                        DrawTile(row, column);
                    }
                }
                drawnBottomTileRow++;
            }
            else if (currentPosition.Y >= 0 && currentPosition.Y < (currentTopLeftTileRow * TILESIZE)) // scrolling up, need new items on top
            {
                stateUpdate = true;
                currentTopLeftTileRow--;
                this.currentPosition.Y -= TILESIZE;

                for (int row = drawnTopTileRow - 1; row >= drawnTopTileRow - 1 - DRAWAHEAD; row--)
                {
                    for (int column = drawnLeftTileColumn; column <= drawnRightTileColumn; column++)
                    {
                        DrawTile(row, column);
                    }
                }
                drawnTopTileRow--;
            }


            if (stateUpdate)
            {
                Trim();
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

        private void Trim()
        {
            var trimRect = GetRectForTileRange(
                currentTopLeftTileColumn,
                currentTopLeftTileRow,
                drawnRightTileColumn - drawnLeftTileColumn +1,
                drawnBottomTileRow - drawnTopTileRow +1);
            this.currentRenderer.Trim(trimRect);

            drawnLeftTileColumn = currentTopLeftTileColumn;
            drawnRightTileColumn = currentTopLeftTileColumn + horizontalVisibleTileCount -1;

            drawnTopTileRow = currentTopLeftTileRow;
            drawnBottomTileRow = currentTopLeftTileRow + verticalVisibleTileCount -1;
        }


    }
}
