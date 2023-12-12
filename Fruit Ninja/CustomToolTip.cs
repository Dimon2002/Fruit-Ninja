using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public class CustomToolTip : ToolTip
    {
        private readonly Size _size;

        public CustomToolTip(Size size)
        {
            _size = size;
            OwnerDraw = true;

            Popup += OnPopup;
            Draw += OnDraw;
        }

        private void OnPopup(object sender, PopupEventArgs e) 
        {
            e.ToolTipSize = _size;
        }

        private static void OnDraw(object sender, DrawToolTipEventArgs e) 
        {
            var g = e.Graphics;

            var b = new LinearGradientBrush(e.Bounds,
                Color.LightBlue, Color.Blue, 45f);

            g.FillRectangle(b, e.Bounds);

            g.DrawString(e.ToolTipText, new Font("Elephant",24), Brushes.Black,
                new PointF(e.Bounds.X + 5, e.Bounds.Y + 5)); 

            b.Dispose();
        }
    }
}
