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

            string fontUrl = "https://github.com/google/fonts/blob/main/apache/arimo/Arimo%5Bwght%5D.ttf";
        }

       
    }
}
