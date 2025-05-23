using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    List<Person> people = File.ReadAllLines(filePath).Skip(1).Select(line => line.Split(','))
                     .Select(data => new Person{ Name = data[0], Age = int.Parse(data[1]), Job = data[2] }).ToList();
                    exDataGrid.ItemsSource = people;
                    dataName.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Job {  get; set; }
        }
        private void getData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
