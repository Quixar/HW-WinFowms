using System.Diagnostics;
using System.Drawing.Text;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ListView wishListView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                CheckBoxes = true,
                FullRowSelect = true
            };

            wishListView.Columns.Add("Товар", 200, HorizontalAlignment.Left);
            wishListView.Columns.Add("Цена (грн)", 100, HorizontalAlignment.Right);


            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(20, 20);
            imageList.Images.Add("phone", Image.FromFile("C:\\Users\\Евгений\\Downloads\\phone.png"));
            imageList.Images.Add("laptop", Image.FromFile("C:\\Users\\Евгений\\Downloads\\laptop.png"));
            imageList.Images.Add("headphones", Image.FromFile("C:\\Users\\Евгений\\Downloads\\headphones.png"));
            imageList.Images.Add("watch", Image.FromFile("C:\\Users\\Евгений\\Downloads\\watch.png"));
            imageList.Images.Add("camera", Image.FromFile("C:\\Users\\Евгений\\Downloads\\camera.png"));

            wishListView.SmallImageList = imageList;

            string[,] items = {
                {"Смартфон", "15000", "phone"},
                {"Ноутбук", "35000", "laptop"},
                {"Наушники", "3000", "headphones"},
                {"Часы", "7000", "watch"},
                {"Камера", "20000", "camera"}
            };

            for (int i = 0; i < items.GetLength(0); i++)
            {
                ListViewItem item = new ListViewItem(items[i, 0])
                {
                    ImageKey = items[i, 2]
                };
                item.SubItems.Add(items[i, 1]);
                wishListView.Items.Add(item);
            }

            this.Controls.Add(wishListView);
        }
    }
}
