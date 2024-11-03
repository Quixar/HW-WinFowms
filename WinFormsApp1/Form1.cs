using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            Task1();
            Task2();
            Task3();
        }

        public void Task1()
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Task1_Tick;
            timer.Start();
            stopwatch.Start();
        }

        private void Task1_Tick(object? sender, EventArgs e)
        {
            label1.Text = $"{stopwatch.ElapsedMilliseconds}";
        }

        private void Task2()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Task2_Tick;
            timer.Start();
            Task2_Tick(null, EventArgs.Empty);
        }

        private void Task2_Tick(object? sender, EventArgs e)
        {
            DateTime targetDate = new DateTime(2025, 1, 1, 0, 0, 0);
            TimeSpan timeLeft = targetDate - DateTime.Now;

            if (timeLeft.TotalSeconds > 0)
            {
                label2.Text = $"{timeLeft.Days} days, {timeLeft.Hours} hours, {timeLeft.Minutes} minutes, {timeLeft.Seconds}, seconds";
            }
            else
            {
                label2.Text = "Event has come";
            }
        }

        public void Task3()
        {
            int clickCount = 0;        
            int highScore = 0;      

            Timer gameTimer = new Timer();
            gameTimer.Interval = 1000;
            int timeLeft = 20;

            Controls.Add(button1);

            button1.Click += (s, e) =>
            {
                if (gameTimer.Enabled)
                {
                    clickCount++;
                }
            };

            gameTimer.Tick += (s, e) =>
            {
                timeLeft--;

                if (timeLeft <= 0)
                {
                    gameTimer.Stop();

                    if (clickCount > highScore)
                    {
                        highScore = clickCount;
                    }
                    
                    MessageBox.Show($"Time's up!\nClicks: {clickCount}\nHigh Score: {highScore}", "Game Over");
                    clickCount = 0;
                    timeLeft = 20;
                }
            };
            gameTimer.Start();
        }
    }
}
