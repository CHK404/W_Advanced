using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp_02_Advanced
{
    /// <summary>
    /// Interaction logic for Image_call.xaml
    /// </summary>
    public partial class Image_call : Window
    {
        public Image_call()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Uri imgSelect = new Uri(filePath, UriKind.Absolute);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = imgSelect;
                bitmap.EndInit();

                ImgButton.Background = new ImageBrush(bitmap);

                ImgButton.Width = bitmap.PixelWidth;
                ImgButton.Height = bitmap.PixelHeight;
            }
        }
    }
}
