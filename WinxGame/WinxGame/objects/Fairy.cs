using Microsoft.VisualBasic.FileIO;
using System.Drawing.Drawing2D;
using System.Numerics;

namespace WinxGame.objects
{
    internal class Fairy : PictureBox
    {
        Form _form { get; }
        public int Hp { get; set; }
        Point Speed { get; } = new Point(10, 10);

        public Fairy(Point location, Form form)
        {
            Location = location;
            Image = Image.FromFile(Path.Join(Directory.GetCurrentDirectory(), @"images/bloom.png"));
            Height = 100;
            Width = 100;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Hp = 100;

            _form = form;
        }
            
        public void Move(Point direction)
        {
            var newX = Math.Max(Math.Min(Location.X + direction.X * Speed.X, _form.Width - Width), 0);
            var newY = Math.Max(Math.Min(Location.Y + direction.Y * Speed.Y, _form.Height - Height), 0);

            Location = new Point(newX, newY);
        }
    }
}
