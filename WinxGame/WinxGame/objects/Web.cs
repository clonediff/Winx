using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinxGame.objects
{
    public class Web : PictureBox, IRenderable
    {
        public string SkinPath { get; set; } = Path.Join(Directory.GetCurrentDirectory(), @"/images/web.png");

        public Web(Point location)
        {
            var image = Image.FromFile(SkinPath);
            Image = image;
            Size = new Size(30, 30);
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = location;
        }

        public void Redraw()
        {
            Location = new Point(Location.X, Location.Y + 10);
        }
    }
}
