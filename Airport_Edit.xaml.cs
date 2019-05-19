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

namespace TP22
{
    ///Изменяем название Аэропорта
    public partial class Airport_Edit : Window
    {
        //строка для названия Аэропорта
        string airport;
        //экземпляр класса рейс
        Flight cur = new Flight();
        //позиция выбранного аэропорта в списке
        int index;
        //конструктор класса
        public Airport_Edit(Flight Flight_current,int Index)
        {
            
            InitializeComponent();
            cur = Flight_current;
            index = Index;
            Airport_Name.Text = cur.Airport[index];
            airport = cur.Airport[index];
        }
        //обработка кноки изменить
        //измения названия аэропорта
        private void Save_Changes_Click(object sender, RoutedEventArgs e)
        {
            //если значение название аэропорта не изменилось
            //выводим сообщение,что ничего не изменилось
            if (Airport_Name.Text == airport)
            {
                MessageBox.Show("Вы ничего не изменили!");
            }
            else
            {
                //устанавливаем новое значение названия аэропота в ранее выбранный пользователем элемент двухсвязанного списка
               cur.Airport[index]= Airport_Name.Text;
                MessageBox.Show("Измения сохранены!");
            }
        }
    }
}
