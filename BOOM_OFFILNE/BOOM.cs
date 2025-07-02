using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System;

public class Bomb
{
    public int X, Y;
    public DateTime PlacedTime; // Thời điểm đặt bom
    private int range = 2; // Phạm vi nổ
    private Timer _timer; // Timer để theo dõi thời gian bom đã được đặt
    public Player Owner; // Người đặt bom
    public Image Image; // Ảnh đại diện cho bomb

    public Bomb(int x, int y, int range, Player owner = null, Image image = null)
    {
        X = x;
        Y = y;
        PlacedTime = DateTime.Now;
        this.range = range;
        Owner = owner;
        Image = image; // Gán ảnh
    }

    // Thực thi khi timer hết thời gian
    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Sau khi timer hết thời gian (1.5 giây), chúng ta có thể cập nhật trạng thái bom
        IsBomberActive = true; // Đánh dấu rằng bom đã đủ thời gian để không cho nhân vật đi qua
    }

    public bool IsBomberActive { get; private set; } // Biến để kiểm tra nếu bom đã đủ thời gian (1.5 giây)

    public List<Point> Explode(int[,] mapData, List<Bomb> bombs)
    {
        List<Point> affected = new List<Point> { new Point(X, Y) }; // Ô giữa

        // Tính các ô xung quanh theo hình dấu cộng
        foreach (var (dx, dy) in new[] { (0, 1), (0, -1), (1, 0), (-1, 0) })
        {
            for (int i = 1; i <= range; i++)
            {
                int nx = X + dx * i;
                int ny = Y + dy * i;
                if (nx < 0 || ny < 0 || nx >= mapData.GetLength(1) || ny >= mapData.GetLength(0))
                    break; // Ngoài bản đồ
                if (mapData[ny, nx] == 1)
                    break; // Gặp tường cứng thì dừng lại
                affected.Add(new Point(nx, ny));

                // Kiểm tra nếu có bom chưa nổ trong phạm vi nổ, thì kích hoạt bom đó nổ
                foreach (var bomb in bombs)
                {
                    if (!bomb.IsBomberActive && bomb.X == nx && bomb.Y == ny)
                    {
                        bomb.PlacedTime = DateTime.Now.AddSeconds(-2); // Cập nhật thời gian bom để nó nổ ngay lập tức
                    }
                }
            }
        }

        return affected; // Trả về các ô bị ảnh hưởng
    }

}
