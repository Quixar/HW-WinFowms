using System.Diagnostics;
using System.Drawing.Text;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        PrivateFontCollection fonts = new PrivateFontCollection();

        public Form1()
        {
            InitializeComponent();

            this.Size = new Size(800, 500);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int flagWidth = 760;
            int flagHeight = 400;

            int startX = 20;
            int startY = 20;

            int stripeHeight = flagHeight / 6;
            g.FillRectangle(Brushes.Blue, startX, startY, flagWidth, stripeHeight); 
            g.FillRectangle(Brushes.Blue, startX, startY + flagHeight - stripeHeight, flagWidth, stripeHeight);

            g.FillRectangle(Brushes.White, startX, startY + stripeHeight, flagWidth, stripeHeight / 2); 
            g.FillRectangle(Brushes.White, startX, startY + flagHeight - stripeHeight - stripeHeight / 2, flagWidth, stripeHeight / 2); 

            g.FillRectangle(Brushes.Red, startX, startY + stripeHeight + stripeHeight / 2, flagWidth, flagHeight - 2 * (stripeHeight + stripeHeight / 2));

            int circleDiameter = 120;
            int circleX = startX + 80;
            int circleY = startY + flagHeight / 2 - circleDiameter / 2;
            g.FillEllipse(Brushes.White, circleX, circleY, circleDiameter, circleDiameter);

        }
    }
}
