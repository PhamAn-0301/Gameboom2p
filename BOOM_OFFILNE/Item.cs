using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOM_OFFILNE
{
    // Các loại vật phẩm
    public enum ItemType { Speed, BombCount, BombRange }

    // Class đại diện cho vật phẩm trên bản đồ
    public class Item
    {
        public int X, Y;          // Tọa độ trên map
        public ItemType Type;     // Loại vật phẩm

        public Item(int x, int y, ItemType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        // Vẽ vật phẩm ra màn hình
        public void Draw(Graphics g)
        {
            // Chọn màu tùy theo loại vật phẩm
            Brush brush;

            switch (Type)
            {
                case ItemType.Speed:
                    brush = Brushes.Yellow;
                    break;
                case ItemType.BombCount:
                    brush = Brushes.Magenta;
                    break;
                case ItemType.BombRange:
                    brush = Brushes.Cyan;
                    break;
                default:
                    brush = Brushes.White;
                    break;
            }

            // Vẽ hình tròn nhỏ tượng trưng cho item
            g.FillEllipse(brush, X * 40 + 10, Y * 40 + 10, 20, 20);


            // Vẽ hình tròn nhỏ tượng trưng cho item
            g.FillEllipse(brush, X * 40 + 10, Y * 40 + 10, 20, 20);
        }
    }

}
