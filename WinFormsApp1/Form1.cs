using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> imagePaths = new List<string>();
        private int currentIndex = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        if (!imagePaths.Contains(filePath))
                        {
                            imagePaths.Add(filePath);
                            AddThumbnail(filePath);
                        }
                    }
                }
            }
        }

        private void AddThumbnail(string filePath)
        {
            var thumbnail = new PictureBox
            {
                Image = Image.FromFile(filePath),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 100,
                Height = 100,
                Tag = filePath,
                Margin = new Padding(5)
            };

            thumbnail.Click += (s, e) => ShowImage(filePath);
            flowLayoutPanel.Controls.Add(thumbnail);
        }

        private void ShowImage(string filePath)
        {
            pictureBox.Image = Image.FromFile(filePath);
            currentIndex = imagePaths.IndexOf(filePath);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < imagePaths.Count)
            {
                var filePath = imagePaths[currentIndex];
                imagePaths.RemoveAt(currentIndex);

                // Удалить миниатюру
                var thumbnail = flowLayoutPanel.Controls
                    .OfType<PictureBox>()
                    .FirstOrDefault(p => (string)p.Tag == filePath);

                if (thumbnail != null)
                {
                    flowLayoutPanel.Controls.Remove(thumbnail);
                    thumbnail.Dispose();
                }

                // Очистить или показать следующее изображение
                if (imagePaths.Count == 0)
                {
                    pictureBox.Image = null;
                    currentIndex = -1;
                }
                else
                {
                    currentIndex = Math.Min(currentIndex, imagePaths.Count - 1);
                    ShowImage(imagePaths[currentIndex]);
                }
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowImage(imagePaths[currentIndex]);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < imagePaths.Count - 1)
            {
                currentIndex++;
                ShowImage(imagePaths[currentIndex]);
            }
        }
    }
}
