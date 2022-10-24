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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Libmas1;
using System.IO;
using Microsoft.Win32;
using Libmas2;

namespace Практ3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] mas;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zapoln_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Column.Text, out int m);
            int.TryParse(Row.Text, out int n);
            mas = new int[m, n];
            LibMas.ZapolnMas(ref mas);
            DataG.ItemsSource = Libmas1.VisualArray.ToDataTable(mas).DefaultView;

        }

        private void ClearProg_Click(object sender, RoutedEventArgs e)
        {
            LibMas.OchistMas(ref mas);
            DataG.ItemsSource = Libmas1.VisualArray.ToDataTable(mas).DefaultView;
        }

        private void Rasch_Click(object sender, RoutedEventArgs e)
        {
            Libmas3.Reshenie(ref mas,out string max);
            Vivod.Text = max;
        }

        private void ExitProg_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SaveMas_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Filter = "Текстовые файлы | *.txt";
            sfg.FilterIndex = 1;
            if (mas == null)
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
            else if (sfg.ShowDialog() == true)
            {
                LibMas.SaveMas(mas, sfg.FileName);
            }
        }
        private void UploadMas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog pfg = new OpenFileDialog();
            pfg.Filter = "Текстовые файлы | *.txt";
            pfg.FilterIndex = 1;
            if (pfg.ShowDialog() == true)
            {
                LibMas.UploadMas(ref mas, pfg.FileName);
                DataG.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП=31 Борькин Иван \n Дана матрица размера M × N. В каждом столбце матрицы найти максимальный \r\nэлемент.");
        }
    }
}
