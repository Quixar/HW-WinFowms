namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Button[,] buttons;
        public Form1()
        {
            int rows = 5;
            int cols = 5;

            int buttonWidth = 52;
            int buttonHeight = 52;
            int padding = 10;

            InitializeComponent();

            buttons = new Button[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Text = i.ToString() + ", " + j.ToString();
                    buttons[i, j].Size = new Size(buttonWidth, buttonHeight);
                    buttons[i, j].Location = new Point(padding + (j * buttonWidth), padding + (i * buttonHeight));

                    this.Controls.Add(buttons[i, j]);

                    int x = i;
                    int y = j;

                    buttons[i, j].Click += (sender, e) =>
                    {
                        buttons[x, y].Enabled = false;
                        buttons[x, y].Visible = false;
                    };
                }
            }
        }
    }
}
