namespace Fishing
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<PictureBox> fishes = new List<PictureBox>();
        static int i = 0; 
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Properties.Resources.boat;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { 
            int x = panel1.Location.X;
            int y = panel1.Location.Y;
            if (e.KeyCode == Keys.D)
                x += 5;
            else if (e.KeyCode == Keys.A)
                x -= 5;
            else if (e.KeyCode == Keys.W)
                y -= 5;
            else if (e.KeyCode == Keys.S)
                y += 5;

            if (x < 0)
                x = 0;
            else if (x > 700)
                x = 700;
            panel1.Location = new Point(x, y);
        }
        private void MakeFish()
        {
            PictureBox newFish = new PictureBox();
            newFish.Image = Properties.Resources.babyShark;
            newFish.Height = 50;
            newFish.Width = 50;
            newFish.MaximumSize = new Size(50, 50);
            newFish.SizeMode = PictureBoxSizeMode.Zoom;

            int x = random.Next(10, this.ClientSize.Width - newFish.Width);
            int y = random.Next(10, this.ClientSize.Height - newFish.Height);

            newFish.Location = new Point(x, y);
            newFish.Click += ClickedFish;

            fishes.Add(newFish);
            this.Controls.Add(newFish);
        }
        private void ClickedFish(object sender, EventArgs e)
        {
            PictureBox temp = sender as PictureBox; 
            fishes.Remove(temp); 
            this.Controls.Remove(temp);
            i++;
            score.Text = i.ToString();
            score.ForeColor = Color.Orange;
            if (i == 3)
            {
                MessageBox.Show("You have enough food now.");
            }
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            MakeFish();
            if(fishes.Count == 5)
            {
                timer1.Enabled = false;
            }
        }
        void boat(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Red);
            SolidBrush brush1 = new SolidBrush(Color.AliceBlue);

            Point point1 = new Point(150, 150);
            Point point2 = new Point(190, 200);
            Point point3 = new Point(240, 200);
            Point point4 = new Point(270, 150);

            Point[] points =
            {
                point1,
                point2,
                point3,
                point4,
            };

            //malo jedro
            Point point5 = new Point(200,100);
            Point point6 = new Point(190, 145);
            Point point7 = new Point(210, 145);
            Point[] points2 =
            {
                point5,
                point6,
                point7
            };
            //veliko jedro
            Point point8 = new Point(220, 80);
            Point point9 = new Point(220, 145);
            Point point10 = new Point(240, 145);
            Point[] points3 =
            {
                point8,
                point9,
                point10
            };

            g.FillPolygon(brush1, points2);
            g.FillPolygon(brush1, points3);
            g.FillPolygon(brush, points);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawString("Uhvacene ribe: ", new Font(FontFamily.GenericSansSerif, 14), new SolidBrush(Color.Orange), 10, 10);
        }
    }
}