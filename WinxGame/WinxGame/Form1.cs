using System;
using System.Windows.Forms;
using WinxGame.objects;
using Timer = System.Threading.Timer;

namespace WinxGame
{
    public partial class Form1 : Form
    {
        private readonly Fairy _fairy;
        private Spider[] _spiders;

        const int SpidersCount = 10;

        public Form1()
        {
            InitializeComponent();
            _fairy = new Fairy(new Point(Width / 2, (Height * 2) / 3), this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Hide();
            Focus();
            Controls.Add(_fairy);

            _spiders = GenSpiders();

            Controls.AddRange(_spiders);
        }

        Spider[] GenSpiders()
        {
            var rnd = new Random();
            var spiders = new Spider[SpidersCount];

            var colWidth = Width / SpidersCount;
            var heightLimit = Height / 2;

            for (int i = 0; i < spiders.Length; i++)
            {
                var x = colWidth * i;
                var y = rnd.Next(0, heightLimit);
                spiders[i] = new Spider(new Point(x, y), this);
            }

            return spiders;
        }

        private void Render(object obj)
        {

            foreach (var spider in _spiders)
            {
                spider.Redraw(spider.CreateFireBallTime);
                
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // MessageBox.Show(e.Key);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _fairy.Move(new Point(0, -1));
                    break;
                case Keys.S:
                    _fairy.Move(new Point(0, 1));
                    break;
                case Keys.A:
                    _fairy.Move(new Point(-1, 0));
                    break;
                case Keys.D:
                    _fairy.Move(new Point(1, 0));
                    break;
            }
        }
    }
}