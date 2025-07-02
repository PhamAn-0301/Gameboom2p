using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using BOOM_OFFILNE;
using System.Xml.Linq;
using BOOM_OFFILNE.General;


namespace BombGame
{
    public partial class FormGame : Form
    {
        private const int TileSize = 40; // Kích thước ô
        private const int MapWidth = 18; // Chiều rộng bản đồ mới
        private const int MapHeight = 18; // Chiều cao bản đồ mới

        private int[,] mapData = new int[MapHeight, MapWidth]; // Bản đồ có kích thước mới 20x20
                                                               // 0 = nền, 1 = tường, 3 = bom
        private List<Bomb> bombs = new List<Bomb>();
        private Player player1, player2;

        private HashSet<Keys> keysPressed = new HashSet<Keys>();
        private System.Windows.Forms.Timer gameTimer;
        private List<Item> items = new List<Item>(); // Danh sách các item hiện tại trên bản đồ
        private System.Windows.Forms.Timer itemSpawnTimer; // Timer để spawn item mỗi 5 giây
        private Random rng = new Random(); // Random để chọn vị trí và loại vật phẩm
                                           // Danh sách hiệu ứng nổ (tọa độ và thời gian bắt đầu)
        private List<(Point position, DateTime explodeTime)> explosionEffects = new List<(Point, DateTime)>();
        private Image backgroundImage;

        private string ten1, ten2;

        public FormGame(string name1, string name2)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ClientSize = new Size(MapWidth * TileSize, MapHeight * TileSize);

            this.Text = "Bomber Game 2 Players";

            InitMap();
            ten1 = name1;
            ten2 = name2;
            player1 = new Player(1, 1, "Resources/player1.png", ten1);
            player2 = new Player(MapWidth - 2, MapHeight - 2, "Resources/player2.png", ten2);
            backgroundImage = Image.FromFile("Resources/background2.png");



            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 50;
            gameTimer.Tick += GameLoop;

            gameTimer.Start();

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            itemSpawnTimer = new System.Windows.Forms.Timer();
            itemSpawnTimer.Interval = 5000; // 5000ms = 5 giây
            itemSpawnTimer.Tick += SpawnItems; // Gọi hàm SpawnItems mỗi lần tick
            itemSpawnTimer.Start();
            this.Shown += FormGame_Shown;

        }
        private void SpawnItems(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++) // Mỗi lần spawn 2 vật phẩm
            {
                int x, y;
                do
                {
                    x = rng.Next(1, MapWidth - 1); // Chọn ngẫu nhiên trong map
                    y = rng.Next(1, MapHeight - 1);
                } while (mapData[y, x] != 0 || items.Any(it => it.X == x && it.Y == y));
                // Kiểm tra vị trí trống và chưa có item

                ItemType type = (ItemType)rng.Next(0, 3); // Random loại item
                items.Add(new Item(x, y, type)); // Thêm item vào danh sách
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keysPressed.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keysPressed.Remove(e.KeyCode);
        }

        private void InitMap()
        {
            // Khởi tạo bản đồ với tường ở biên
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (y == 0 || y == MapHeight - 1 || x == 0 || x == MapWidth - 1)
                        mapData[y, x] = 1; // Tường ở biên
                    else
                        mapData[y, x] = 0; // Nền
                }
            }

            // Tạo tường ngẫu nhiên bên trong bản đồ
            GenerateRandomWalls();
        }

        private void GenerateRandomWalls()
        {
            bool validMap = false;

            while (!validMap)
            {
                // Reset map (chỉ giữ tường ở biên)
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    for (int x = 1; x < MapWidth - 1; x++)
                    {
                        mapData[y, x] = 0; // Đặt nền
                    }
                }

                int wallCount = rng.Next(30, 50); // Số lượng tường ngẫu nhiên

                for (int i = 0; i < wallCount; i++)
                {
                    int x, y;
                    do
                    {
                        x = rng.Next(1, MapWidth - 1);
                        y = rng.Next(1, MapHeight - 1);
                    } while (mapData[y, x] != 0 || (Math.Abs(x - 1) + Math.Abs(y - 1) <= 2) || (Math.Abs(x - (MapWidth - 2)) + Math.Abs(y - (MapHeight - 2)) <= 2));
                    // Không đặt tường quá gần chỗ spawn player1 (1,1) và player2 (MapWidth-2,MapHeight-2)

                    mapData[y, x] = 1; // Đặt tường
                }

                // Sau khi sinh xong, kiểm tra nếu có đường thì OK
                validMap = CheckPathExists(new Point(1, 1), new Point(MapWidth - 2, MapHeight - 2));
            }
        }

        private bool CheckPathExists(Point start, Point end)
        {
            bool[,] visited = new bool[MapHeight, MapWidth];
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(start);
            visited[start.Y, start.X] = true;

            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == end)
                    return true; // Tìm được đường

                for (int dir = 0; dir < 4; dir++)
                {
                    int newX = current.X + dx[dir];
                    int newY = current.Y + dy[dir];

                    if (newX >= 0 && newX < MapWidth && newY >= 0 && newY < MapHeight)
                    {
                        if (!visited[newY, newX] && mapData[newY, newX] == 0) // Chỉ đi trên nền trống
                        {
                            visited[newY, newX] = true;
                            queue.Enqueue(new Point(newX, newY));
                        }
                    }
                }
            }

            return false; // Không tìm được đường
        }


        private void CheckItemPickup(Player player)
        {
            for (int i = items.Count - 1; i >= 0; i--) // Duyệt ngược để xóa an toàn
            {
                if (items[i].X == player.TileX && items[i].Y == player.TileY) // Nếu player đứng đúng ô có item
                {
                    Sound.PlayEatItemsSound();
                    player.CollectItem(items[i]); // Gọi hàm CollectItem để tăng chỉ số
                    items.RemoveAt(i); // Xóa item đã nhặt
                }
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            HandleInput();

            List<Point> affectedPoints = new List<Point>();
            bool player1Hit = false, player2Hit = false;

            for (int i = bombs.Count - 1; i >= 0; i--)
            {
                if ((DateTime.Now - bombs[i].PlacedTime).TotalSeconds >= 2)
                {
                    Sound.PlayBummSound();
                    // Bom nổ, lấy các điểm bị ảnh hưởng
                    // Thay đổi khi gọi Explode trong GameLoop:
                    var currentAffected = bombs[i].Explode(mapData, bombs);

                    mapData[bombs[i].Y, bombs[i].X] = 0;

                    // Thêm vào danh sách các điểm bị ảnh hưởng để vẽ
                    foreach (var p in currentAffected)
                    {
                        affectedPoints.Add(p);
                    }

                    // Xóa vật phẩm trong phạm vi nổ
                    items.RemoveAll(item => currentAffected.Any(p => p.X == item.X && p.Y == item.Y));

                    // Giảm số lượng bom của người chơi
                    if (bombs[i].Owner == player1) player1.CurrentBombs--;
                    if (bombs[i].Owner == player2) player2.CurrentBombs--;

                    bombs.RemoveAt(i);
                }
            }

            // Thêm hiệu ứng bom vào danh sách để vẽ
            foreach (var p in affectedPoints)
            {
                explosionEffects.Add((p, DateTime.Now));
            }

            // Kiểm tra người chơi có bị trúng bom hay không
            player1Hit = affectedPoints.Any(p => p.X == player1.TileX && p.Y == player1.TileY);
            player2Hit = affectedPoints.Any(p => p.X == player2.TileX && p.Y == player2.TileY);

            // Nếu có hiệu ứng bom, chờ hiển thị trước khi dừng game
            explosionEffects.RemoveAll(effect => (DateTime.Now - effect.explodeTime).TotalSeconds >= 0.3);

            // Vẽ lại hiệu ứng bom
            Invalidate();

            // Kiểm tra việc nhặt vật phẩm
            CheckItemPickup(player1);
            CheckItemPickup(player2);

            // Nếu có người chơi trúng bom, dừng trò chơi
            if (player1Hit || player2Hit)
            {
                gameTimer.Stop();
                Sound.StopBackgroundMusic();
                Sound.PlayGameOverSound();

                if (player1Hit)
                    MessageBox.Show("Player 1 thua!");
                else
                    MessageBox.Show("Player 2 thua!");

                this.Hide();

                // Hiện lại FormNhanVat đã được gán Owner
                if (this.Owner != null)
                    this.Owner.Show();

                this.Close();
            }



            // Loại bỏ các hiệu ứng bom đã hết thời gian (0.3 giây)
            explosionEffects.RemoveAll(effect => (DateTime.Now - effect.explodeTime).TotalSeconds >= 0.3);

            // Vẽ lại giao diện
            Invalidate();
        }



        private void HandleInput()
        {
            float speed = 10f;

            if (keysPressed.Contains(Keys.W)) player1.TryMove(0, -speed, mapData);
            if (keysPressed.Contains(Keys.S)) player1.TryMove(0, speed, mapData);
            if (keysPressed.Contains(Keys.A)) player1.TryMove(-speed, 0, mapData);
            if (keysPressed.Contains(Keys.D)) player1.TryMove(speed, 0, mapData);

            // Người chơi 1 đặt bom
            if (keysPressed.Contains(Keys.Space) && player1.CurrentBombs < player1.MaxBombs)
            {
                if (mapData[player1.TileY, player1.TileX] != 3)
                {
                    var bombImage = Image.FromFile("Resources/bomlua.png"); // Hình ảnh bom cho player 1
                    bombs.Add(new Bomb(player1.TileX, player1.TileY, player1.BombRange, player1, bombImage)); // Truyền phạm vi nổ và owner
                    mapData[player1.TileY, player1.TileX] = 3;
                    player1.CurrentBombs++; // Tăng số bom đang đặt
                }
            }

            // Người chơi 2 đặt bom
            if (keysPressed.Contains(Keys.Enter) && player2.CurrentBombs < player2.MaxBombs)
            {
                if (mapData[player2.TileY, player2.TileX] != 3)
                {
                    var bombImage = Image.FromFile("Resources/bomnuoc.png"); // Hình ảnh bom cho player 2
                    bombs.Add(new Bomb(player2.TileX, player2.TileY, player2.BombRange, player2, bombImage));
                    mapData[player2.TileY, player2.TileX] = 3;
                    player2.CurrentBombs++;
                }
            }

            // Các điều khiển khác của player 2
            if (keysPressed.Contains(Keys.Up)) player2.TryMove(0, -speed, mapData);
            if (keysPressed.Contains(Keys.Down)) player2.TryMove(0, speed, mapData);
            if (keysPressed.Contains(Keys.Left)) player2.TryMove(-speed, 0, mapData);
            if (keysPressed.Contains(Keys.Right)) player2.TryMove(speed, 0, mapData);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // 1. Vẽ nền bản đồ
            if (backgroundImage != null)
            {
                g.DrawImage(backgroundImage, 0, 0, MapWidth * TileSize, MapHeight * TileSize);
            }

            // 2. Vẽ hiệu ứng nổ (lan tỏa, sáng mờ dần)
            foreach (var effect in explosionEffects)
            {
                double elapsed = (DateTime.Now - effect.explodeTime).TotalSeconds;
                if (elapsed < 0.3)
                {
                    float alpha = 1 - (float)(elapsed / 0.3);
                    Color color = Color.FromArgb((int)(255 * alpha), 255, 0, 0);
                    using (Brush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, effect.position.X * TileSize, effect.position.Y * TileSize, TileSize, TileSize);
                    }

                    // Hiệu ứng vòng tròn lan tỏa
                    int radius = (int)(TileSize / 2 + alpha * TileSize / 2);
                    g.DrawEllipse(Pens.Red,
                        effect.position.X * TileSize + TileSize / 2 - radius / 2,
                        effect.position.Y * TileSize + TileSize / 2 - radius / 2,
                        radius, radius);
                }
            }

            // 3. Vẽ map (tường, bom)
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    switch (mapData[y, x])
                    {
                        case 1: // Tường
                            g.FillRectangle(Brushes.DarkSlateGray, x * TileSize, y * TileSize, TileSize, TileSize);
                            break;
                        case 3: // Bom
                            g.FillRectangle(Brushes.Orange, x * TileSize, y * TileSize, TileSize, TileSize);
                            break;
                            // case 0 thì không vẽ gì vì có background
                    }

                    // Viền lưới
                    g.DrawRectangle(Pens.Black, x * TileSize, y * TileSize, TileSize, TileSize);
                }
            }

            // 4. Vẽ tất cả các quả bom (ảnh)
            foreach (var bomb in bombs)
            {
                g.DrawImage(bomb.Image, bomb.X * TileSize, bomb.Y * TileSize, TileSize, TileSize);
            }

            // 5. Vẽ tất cả item
            foreach (var item in items)
            {
                item.Draw(g);
            }

            // 6. Vẽ người chơi
            player1.Draw(e.Graphics);
            player2.Draw(e.Graphics);
        }

        private void FormGame_Shown(object sender, EventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }


    }
}
