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

namespace TP22
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        //Открывается окно для добавления элементов в список
        private void Flight_Add(object sender, RoutedEventArgs e)
        {
            Add Flight_Add = new Add();
            Flight_Add.Show();

        }
        //Открывается окно для отображения/изменения списка
        private void Flight_Show(object sender, RoutedEventArgs e)
        {
            Show Flight_Show = new Show(Share.Flight_list);
            Flight_Show.Show();
        }
    }
}
