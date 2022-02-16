using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2_project
{
        class roundbutton : Button
        {
            public roundbutton()
            {
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.BackColor = System.Drawing.Color.Green;
                this.Size = new Size(100, 100);
            }
            protected override void OnPaint(PaintEventArgs pevent)
            {
                this.UpdateRegion();
                base.OnPaint(pevent);
            }
            protected void UpdateRegion()
            {
                GraphicsPath grPath = new GraphicsPath();
                grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new Region(grPath);
            }
    }
    class straight__line_edge_picturebox : PictureBox
    {
        public straight__line_edge_picturebox()
        {
            this.BackColor = System.Drawing.Color.Green;
            this.Size = new Size(100, 100);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            this.UpdateRegion();
            base.OnPaint(pevent);
        }
        protected void UpdateRegion()
        {
            var path = new GraphicsPath();
            Point[] points =
            {
                new Point( 0, 0),
                new Point(0, ClientSize.Height - 50),
                new Point(50, ClientSize.Height),
                new Point(ClientSize.Width, ClientSize.Height),
                new Point(ClientSize.Width, 50),
                new Point(ClientSize.Width - 50, 0)
            };
            path.AddPolygon(points);
            path.FillMode = FillMode.Winding;
            this.Region = new Region(path);
        }
    }
    class two_curve_edge_picturebox : PictureBox
    {
        public two_curve_edge_picturebox()
        {
            this.BackColor = System.Drawing.Color.Green;
            this.Size = new Size(100, 100);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            this.UpdateRegion();
            base.OnPaint(pevent);
        }
        protected void UpdateRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.FillMode = FillMode.Winding;

            int cut = 30;
            Rectangle cr = this.ClientRectangle;

            Point[] points =
                {
                new Point(0, cr.Height),
                new Point(0, cut),
                new Point(cut, 0),
                new Point(cr.Width, 0),
                new Point(cr.Width, cr.Height - cut),
                new Point(cr.Width - cut, cr.Height),
                new Point(0, cr.Height),
                 };
            path.AddPolygon(points);

            // Rectangle arcRect = new Rectangle(0, cr.Height - 2 * cut, 2 * cut, 2 * cut);
            Rectangle arcRectTL = new Rectangle(0, 0, 2 * cut, 2 * cut);
            // Rectangle arcRectTR = new Rectangle(cr.Width - 2 * cut, 0, 2 * cut, 2 * cut);
            Rectangle arcRectBR = new Rectangle(cr.Width - 2 * cut, cr.Height - 2 * cut, 2 * cut, 2 * cut);
            // path.AddArc(arcRect, 90f, 90f);
            path.AddArc(arcRectTL, 180f, 90f);
            // path.AddArc(arcRectTR, 90f, 90f);
            path.AddArc(arcRectBR, 360f, 90f);
            this.Region = new Region(path);


        }
    }

}
