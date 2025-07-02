using BOOM_OFFILNE;
using System;
using System.Drawing;
using System.Windows.Forms;

public class Player
{
    public float PosX, PosY;
    public int TileX => (int)(PosX / TileSize);
    public int TileY => (int)(PosY / TileSize);
    public float Speed = 4f;
    public int MaxBombs = 1;
    public int CurrentBombs = 0;
    public int BombRange = 2;
    public string Name { get; set; }

    private Image sprite;

    public Player(int x, int y, string imagePath, string name = "")
    {
        PosX = x * TileSize + TileSize / 2;
        PosY = y * TileSize + TileSize / 2;
        Name = name;

        try
        {
            sprite = Image.FromFile(imagePath);
        }
        catch
        {
            MessageBox.Show("Không thể tải hình ảnh: " + imagePath);
        }
    }


    public void Draw(Graphics g)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Name) && g != null)
            {
                using (Font font = new Font(SystemFonts.DefaultFont.FontFamily, 10, FontStyle.Bold, GraphicsUnit.Pixel))
                using (SolidBrush brush = new SolidBrush(Color.White)) // dùng SolidBrush thay vì Brushes.White
                {
                    SizeF textSize = g.MeasureString(Name, font);
                    float textX = PosX - textSize.Width / 2;
                    float textY = PosY - TileSize / 2 - 20;

                    // Vẽ đổ bóng để dễ đọc
                    g.DrawString(Name, font, Brushes.Black, textX + 1, textY + 1);
                    g.DrawString(Name, font, brush, textX, textY);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Vẽ tên bị lỗi GDI+: " + ex.Message);
        }

        // Vẽ hình nhân vật
        if (sprite != null)
        {
            int size = TileSize + 8;
            g.DrawImage(sprite, PosX - size / 2, PosY - size / 2, size, size);
        }
        else
        {
            int size = 30 + 8;
            g.FillEllipse(Brushes.Red, PosX - size / 2, PosY - size / 2, size, size);
        }
    }






    public void TryMove(float dx, float dy, int[,] mapData)
    {
        float newX = PosX + dx;
        float newY = PosY + dy;

        // Kích thước nhân vật khi vẽ (lớn hơn ô nên dùng 36x36)
        int playerSize = 36;
        int halfSize = playerSize / 2;

        // Tính các góc của hình vuông nhân vật
        PointF topLeft = new PointF(newX - halfSize, newY - halfSize);
        PointF topRight = new PointF(newX + halfSize - 1, newY - halfSize);
        PointF bottomLeft = new PointF(newX - halfSize, newY + halfSize - 1);
        PointF bottomRight = new PointF(newX + halfSize - 1, newY + halfSize - 1);

        // Kiểm tra xem 4 điểm này có va vào tường không
        if (!IsBlocked(topLeft, mapData) &&
            !IsBlocked(topRight, mapData) &&
            !IsBlocked(bottomLeft, mapData) &&
            !IsBlocked(bottomRight, mapData))
        {
            PosX = newX;
            PosY = newY;
        }
    }

    // Hàm kiểm tra 1 điểm có va vào tường không
    private bool IsBlocked(PointF point, int[,] mapData)
    {
        int tileX = (int)(point.X / TileSize);
        int tileY = (int)(point.Y / TileSize);

        if (tileX < 0 || tileX >= mapData.GetLength(1) ||
            tileY < 0 || tileY >= mapData.GetLength(0))
            return true;

        // Kiểm tra xem ô này có phải là bom không, nếu có thì không block nhân vật
        if (mapData[tileY, tileX] == 3) // 3 là bom
        {
            return false; // Bỏ qua bom, cho phép nhân vật di chuyển qua
        }

        // Kiểm tra va chạm với tường
        return mapData[tileY, tileX] != 0; // 0 là ô trống, còn lại là tường, bom...
    }



    public void CollectItem(Item item)
    {
        switch (item.Type)
        {
            case ItemType.Speed:
                if (Speed < 9) Speed++;
                break;
            case ItemType.BombCount:
                if (MaxBombs < 5) MaxBombs++;
                break;
            case ItemType.BombRange:
                if (BombRange < 6) BombRange++;
                break;
        }
    }

    private const int TileSize = 40;
}
