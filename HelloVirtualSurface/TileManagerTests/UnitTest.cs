
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Foundation;
using System.Collections.Generic;
using TileManager;

namespace TileManagerTests
{
    [TestClass]
    public class UnitTest1
    {
        TestTileRenderer ttr;
        TileDrawingManager tm;

        public UnitTest1()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);
        }

        [TestMethod]
        public void InitialPaint()
        {
            tm.UpdateViewportSize(new Size(750, 750));

            Assert.AreEqual(ttr.Impressions.Count, 9);

            //row 1
            Assert.AreEqual(ttr.Impressions[0].tileRow, 0);
            Assert.AreEqual(ttr.Impressions[0].tileColumn, 0);
            Assert.AreEqual(ttr.Impressions[1].tileRow, 0);
            Assert.AreEqual(ttr.Impressions[1].tileColumn, 1);
            Assert.AreEqual(ttr.Impressions[2].tileRow, 0);
            Assert.AreEqual(ttr.Impressions[2].tileColumn, 2);

            //row 2
            Assert.AreEqual(ttr.Impressions[3].tileRow, 1);
            Assert.AreEqual(ttr.Impressions[3].tileColumn, 0);
            Assert.AreEqual(ttr.Impressions[4].tileRow, 1);
            Assert.AreEqual(ttr.Impressions[4].tileColumn, 1);
            Assert.AreEqual(ttr.Impressions[5].tileRow, 1);
            Assert.AreEqual(ttr.Impressions[5].tileColumn, 2);

            Assert.AreEqual(tm.currentTopLeftTileRow, 0);
            Assert.AreEqual(tm.currentTopLeftTileColumn, 0);

            Assert.AreEqual(tm.drawnLeftTileColumn, 0);
            Assert.AreEqual(tm.drawnRightTileColumn, 2);

            ttr.ClearLog();
        }

        [TestMethod]
        public void PanRightLessThanThreshold()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            tm.UpdateViewportSize(new Size(750, 750));

            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(1.0f, 0f, 0f));
            //tm.UpdateVisibleRegion(new System.Numerics.Vector3(251.0f, 0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 0);

            Assert.AreEqual(tm.drawnLeftTileColumn, 0);
            Assert.AreEqual(tm.drawnRightTileColumn, 2);
        }

        [TestMethod]
        public void PanRightCrossingThreshold()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            tm.UpdateViewportSize(new Size(750, 750));

            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(251.0f, 0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 4);

            //Column 5
            Assert.AreEqual(ttr.Impressions[0].tileRow, 0);
            Assert.AreEqual(ttr.Impressions[0].tileColumn, 3);
            Assert.AreEqual(ttr.Impressions[1].tileRow, 1);
            Assert.AreEqual(ttr.Impressions[1].tileColumn, 3);
            Assert.AreEqual(ttr.Impressions[2].tileRow, 2);
            Assert.AreEqual(ttr.Impressions[2].tileColumn, 3);

            Assert.AreEqual(ttr.Impressions[3].type, OperationType.Clear);
            Assert.AreEqual(ttr.Impressions[3].rect, new Rect() { X = 250, Y = 0, Width = 1000, Height = 750 });

            Assert.AreEqual(tm.drawnLeftTileColumn, 1);
            Assert.AreEqual(tm.drawnRightTileColumn, 3);
        }

        [TestMethod]
        public void PanRightCrossingThresholdContinue()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            PanRightCrossingThreshold();
            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(252.0f, 0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 0);
        }

        [TestMethod]
        public void PanRightThenLeft()
        {
            PanRightCrossingThreshold();

            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 4);

            //Column 1 redraw (since it was cleared above)
            Assert.AreEqual(ttr.Impressions[0].tileRow, 0);
            Assert.AreEqual(ttr.Impressions[0].tileColumn, 0);
            Assert.AreEqual(ttr.Impressions[1].tileRow, 1);
            Assert.AreEqual(ttr.Impressions[1].tileColumn, 0);
            Assert.AreEqual(ttr.Impressions[2].tileRow, 2);
            Assert.AreEqual(ttr.Impressions[2].tileColumn, 0);

            Assert.AreEqual(ttr.Impressions[3].type, OperationType.Clear);
            Assert.AreEqual(ttr.Impressions[3].rect, new Rect() { X = 0, Y = 0, Width = 1000, Height = 750 });

            Assert.AreEqual(tm.drawnLeftTileColumn, 0);
            Assert.AreEqual(tm.drawnRightTileColumn, 2);
        }

        [TestMethod]
        public void PanLeftLessThanThreshold()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            tm.UpdateViewportSize(new Size(750, 750));

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(251.0f, 0f, 0f));
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(501.0f, 0f, 0f));
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(755.0f, 0f, 0f));

            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(753.0f, 0f, 0f));
            //tm.UpdateVisibleRegion(new System.Numerics.Vector3(251.0f, 0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 0);

            Assert.AreEqual(tm.drawnLeftTileColumn, 3);
            Assert.AreEqual(tm.drawnRightTileColumn, 5);
        }

        [TestMethod]
        public void PanLeftCrossingThreshold()
        {
            PanLeftLessThanThreshold();
            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(749.0f, 0f, 0f));
            Assert.AreEqual(ttr.Impressions.Count, 4);

            Assert.AreEqual(tm.drawnLeftTileColumn, 2);
            Assert.AreEqual(tm.drawnRightTileColumn, 4);
        }

        [TestMethod]
        public void PanLeftCrossingThresholdContinue()
        {
            PanLeftCrossingThreshold();
            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(748.0f, 0f, 0f));
            Assert.AreEqual(ttr.Impressions.Count, 0);
        }

        [TestMethod]
        public void PanDownLessThanThreshold()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            tm.UpdateViewportSize(new Size(750, 750));

            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 1.0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 0);

            Assert.AreEqual(tm.drawnTopTileRow, 0);
            Assert.AreEqual(tm.drawnBottomTileRow, 2);
        }

        [TestMethod]
        public void PanDownCrossingThreshold()
        {
            PanDownLessThanThreshold();
            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 251.0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 4);

            Assert.AreEqual(ttr.Impressions[0].tileRow, 3);
            Assert.AreEqual(ttr.Impressions[0].tileColumn, 0);
            Assert.AreEqual(ttr.Impressions[1].tileRow, 3);
            Assert.AreEqual(ttr.Impressions[1].tileColumn, 1);
            Assert.AreEqual(ttr.Impressions[2].tileRow, 3);
            Assert.AreEqual(ttr.Impressions[2].tileColumn, 2);

            Assert.AreEqual(ttr.Impressions[3].type, OperationType.Clear);
            Assert.AreEqual(ttr.Impressions[3].rect, new Rect() { X = 0, Y = 250, Width = 750, Height = 1000 });

            Assert.AreEqual(tm.drawnTopTileRow, 1);
            Assert.AreEqual(tm.drawnBottomTileRow, 3);
        }

        [TestMethod]
        public void PanDownCrossingThresholdContinue()
        {
            PanDownCrossingThreshold();
            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 253.0f, 0f));
            Assert.AreEqual(ttr.Impressions.Count, 0);
        }

        // Pan up tests
        [TestMethod]
        public void PanUpLessThanThreshold()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            tm.UpdateViewportSize(new Size(750, 750));
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 251.0f, 0f));
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 501.0f, 0f));
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 752.0f, 0f));

            ttr.ClearLog();

            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 751.0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 0);

            Assert.AreEqual(tm.drawnTopTileRow, 3);
            Assert.AreEqual(tm.drawnBottomTileRow, 5);
        }

        [TestMethod]
        public void PanUpCrossingThreshold()
        {
            PanUpLessThanThreshold();
            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 749.0f, 0f));

            Assert.AreEqual(ttr.Impressions.Count, 4);

            Assert.AreEqual(ttr.Impressions[0].tileRow, 2);
            Assert.AreEqual(ttr.Impressions[0].tileColumn, 0);
            Assert.AreEqual(ttr.Impressions[1].tileRow, 2);
            Assert.AreEqual(ttr.Impressions[1].tileColumn, 1);
            Assert.AreEqual(ttr.Impressions[2].tileRow, 2);
            Assert.AreEqual(ttr.Impressions[2].tileColumn, 2);

            Assert.AreEqual(ttr.Impressions[3].type, OperationType.Clear);
            Assert.AreEqual(ttr.Impressions[3].rect, new Rect() { X = 0, Y = 500, Width = 750, Height = 1000 });

            Assert.AreEqual(tm.drawnTopTileRow, 2);
            Assert.AreEqual(tm.drawnBottomTileRow, 4);
        }

        [TestMethod]
        public void PanUpCrossingThresholdContinue()
        {
            PanDownCrossingThreshold();
            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 253.0f, 0f));
            Assert.AreEqual(ttr.Impressions.Count, 0);
        }

        //Combinations

        [TestMethod]
        public void PanTwoUpOneRight()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            tm.UpdateViewportSize(new Size(750, 750));
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0, 251, 0));
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0, 501, 0));

            Assert.AreEqual(tm.drawnLeftTileColumn, 0);
            Assert.AreEqual(tm.drawnRightTileColumn, 2);
            Assert.AreEqual(tm.drawnTopTileRow, 2);
            Assert.AreEqual(tm.drawnBottomTileRow, 4);

            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(251.0f, 501.0f, 0f));
            Assert.AreEqual(ttr.Impressions.Count, 4);
        }

        [TestMethod]
        public void PanTwoUpOneLeft()
        {
            PanTwoUpOneRight();

            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(0.0f, 501.0f, 0f));
            Assert.AreEqual(ttr.Impressions.Count, 4);
        }

        [TestMethod]
        public void PanTwoRightOneLeftUp()
        {
            ttr = new TestTileRenderer();
            tm = new TileDrawingManager(ttr);

            tm.UpdateViewportSize(new Size(750, 750));

            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(251, 0, 0));
            Assert.AreEqual(ttr.Impressions.Count, 4);

            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(501, 0, 0));
            Assert.AreEqual(ttr.Impressions.Count, 4);

            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(499, 0, 0));

            Assert.AreEqual(tm.drawnLeftTileColumn, 1);
            Assert.AreEqual(tm.drawnRightTileColumn, 3);
            Assert.AreEqual(tm.drawnTopTileRow, 0);
            Assert.AreEqual(tm.drawnBottomTileRow, 2);

            ttr.ClearLog();
            tm.UpdateVisibleRegion(new System.Numerics.Vector3(251.0f, 251.0f, 0f));
            Assert.AreEqual(ttr.Impressions.Count, 4);
        }

    }

    enum OperationType { Draw, Clear }

    class TileOperation
    {
        public OperationType type;
        public Rect rect;
        public int tileRow;
        public int tileColumn;
    }

    class TestTileRenderer : ITileRenderer
    {
        List<TileOperation> impressionLog = new List<TileOperation>();

        public void DrawTile(Rect rect, int tileRow, int tileColumn)
        {
            impressionLog.Add(new TileOperation() { type = OperationType.Draw, rect = rect, tileRow = tileRow, tileColumn = tileColumn });
        }

        public void Trim(Rect trimRect)
        {
            impressionLog.Add(new TileOperation() { type = OperationType.Clear, rect = trimRect });
        }

        public void ClearLog()
        {
            impressionLog.Clear();
        }

        public IList<TileOperation> Impressions
        {
            get
            {
                return impressionLog;
            }
        }
    }
}
