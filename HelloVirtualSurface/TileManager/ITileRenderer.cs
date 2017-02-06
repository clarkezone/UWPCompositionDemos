using Windows.Foundation;

namespace TileManager
{
    public interface ITileRenderer
    {
        void DrawTile(Rect rect, int tileRow, int tileColumn);
        void Trim(Rect trimRect);
    }
}
