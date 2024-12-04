using System.Diagnostics;
using System.Drawing.Text;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private PrivateFontCollection privateFontCollection;

        public Form1()
        {
            InitializeComponent();
            privateFontCollection = new PrivateFontCollection();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string fontUrl = "https://github.com/google/fonts/raw/main/ofl/bokor/Bokor-Regular.ttf";
            string fontFilePath = Path.Combine(Path.GetTempPath(), "Bokor-Regular.ttf");

            byte[] fontData;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    fontData = await client.GetByteArrayAsync(fontUrl);
                    File.WriteAllBytes(fontFilePath, fontData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error when loading font: {ex.Message}");
                    return;
                }
            }

            privateFontCollection.AddFontFile(fontFilePath);

            if (privateFontCollection.Families.Length == 0)
            {
                MessageBox.Show("Failed to load the font.");
                return;
            }

            FontFamily fontFamily = privateFontCollection.Families[0];
            Font newFont = new Font(fontFamily, 12);

            ApplyFont(this, newFont);

            try
            {
                File.Delete(fontFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when deleting a temporary file: {ex.Message}");
            }
        }

        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox || control is Button || control is Label || control is ComboBox || control is ListBox)
                {
                    control.Font = font;
                }

                if (control.HasChildren)
                {
                    ApplyFont(control, font);
                }
            }
        }
    }
}
