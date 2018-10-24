using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace lab4_mayorov
{

    public partial class Form1 : Form
    {
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int w, h;

            w = this.Width;
            h = this.Height;
            DateTime dt = DateTime.Now;
            Pen cir_pen = new Pen(Color.Black, 5);
            Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;
            GraphicsState gs;
            g.TranslateTransform(w / 2, (h / 2)-20);
            g.ScaleTransform(w / 300, h / 300);
            g.DrawEllipse(cir_pen, -120, -120, 240, 240);
            
            gs = g.Save();
         
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute / 60 ));
            g.DrawLine(new Pen(new SolidBrush(Color.Pink), 5), 0, 0, 0, -80);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(6 * ((dt.Minute ) + (float)dt.Second / 60));
            g.DrawLine(new Pen(new SolidBrush(Color.Red), 5), 0, 0, 0, -80);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(6*(dt.Second) );
            g.DrawLine(new Pen(new SolidBrush(Color.Green), 5), 0, 0, 0, -80);
            g.Restore(gs);
            g.FillEllipse(brush, -10, -10, 20, 20);
            for (int i = 1; i < 13; i++)
            {
                gs = g.Save();
                g.RotateTransform(30 * i);
                string g1 = i.ToString();
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 4), 0, -100, 0, -120);
                g.DrawString(g1, Font, brush, -7, -100);
                g.Restore(gs);
            }
            for (int i = 0; i < 60; i++)
            {
                gs = g.Save();
                g.RotateTransform(6 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, -110, 0, -120);
                g.Restore(gs);
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 300;
            this.Height = 300;
            this.Paint += Form1_Paint;
            timer2.Start();
        }
      
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
