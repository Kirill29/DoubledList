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
    /// <summary>
    /// Логика взаимодействия для Flight_Edit.xaml
    /// </summary>
    public partial class Flight_Edit : Window

    {
        //создаем экземпляр класса рейс 
        Flight flight_current = new Flight();
        //строка для хранения выбранного пользователм элемента списка Аэропорты
        string airport_current;
        //создаем экземпляр класса,который использовали при выводе на форму
        StringValue airport_current_stringvalue;
        //конструктор класса
        public Flight_Edit(Flight Flight)
        {
            
            flight_current = Flight;
            InitializeComponent();
            //устанавливаем значения из элемента списка на форму
            Flight_Number_Edit.Text = flight_current.Number;
            Flight_Type_Edit.Text = flight_current.Type;
            Flight_Dep_Date_Edit.SelectedDate= flight_current.Dep_Date;
            Flight_Ret_Date_Edit.SelectedDate = flight_current.Ret_Date;
            try
            {

                List<StringValue> Aiportik = new List<StringValue>();
                foreach (var el in flight_current.Airport)
                {
                    StringValue st = new StringValue(el);

                    Aiportik.Add(st);
                }
                foreach (var el in Aiportik)
                {
                    Airport_show_Edit.Items.Add(el);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //удаление элемента списка Аэропорты
        private void Airport_delete(object sender, RoutedEventArgs e)
        {
            try
            {
                //получаем выбранный пользователем элемент списка 
                //получаем класс StringValue -поле Value данного класса
                //есть выбранный элемент списка Аэропорт
                airport_current_stringvalue = Airport_show_Edit.SelectedItem as StringValue;
                airport_current = airport_current_stringvalue.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //удаляем элемент из списка Аэропорт
            flight_current.Airport.Remove(airport_current);

        }
        //изменение элемента списка Аэропорты
        private void Airport_edit(object sender, RoutedEventArgs e)
        {

            //индекс элемента выбранного пользователем
            int airport_index;
            try
            {
                //получаем элемент с формы
                airport_current_stringvalue = Airport_show_Edit.SelectedItem as StringValue;
                airport_current = airport_current_stringvalue.Value;
                //получаем индекс выбранного элемента
                airport_index = Airport_show_Edit.SelectedIndex;
                //создаем форму для измения элемента списка Аэропорты
                //на вход передается ранее выбранный пользователем элемент двухсвязанного списка и номер выбранного элемента списка Аэропорты
                Airport_Edit Airport_Edit = new Airport_Edit(flight_current, airport_index);
                //показываем форму
                Airport_Edit.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }

        //при выборе элемента двухсвязанного списка на форме выводится в отдельном поле
        //список Аэропортов для этого рейса
        private void ItemsView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Airport_show_Edit.Items.Clear();
            try
            {

                List<StringValue> Aiportik = new List<StringValue>();
                foreach (var el in flight_current.Airport)
                {
                    StringValue st = new StringValue(el);

                    Aiportik.Add(st);
                }
                foreach (var el in Aiportik)
                {
                    Airport_show_Edit.Items.Add(el);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
        //обработка кнопки сохрания измений 
        private void Flight_Edit_Save(object sender, RoutedEventArgs e)
        {
            //если все поля остались без изменений
            if ((Flight_Dep_Date_Edit.Text==flight_current.Number) && (Flight_Type_Edit.Text == flight_current.Type) && (Flight_Dep_Date_Edit.SelectedDate == flight_current.Dep_Date) && (Flight_Ret_Date_Edit.SelectedDate == flight_current.Ret_Date))
            {
                MessageBox.Show("Необходимо изменить хотя бы одно поле!");
            }
            else///значения полей были изменены
            {
                flight_current.Number = Flight_Number_Edit.Text;
               flight_current.Type = Flight_Type_Edit.Text;
                flight_current.Dep_Date = Flight_Dep_Date_Edit.SelectedDate;
                flight_current.Ret_Date= Flight_Ret_Date_Edit.SelectedDate ;
                MessageBox.Show("Измения сохранены!");

            }
        }
       
    }
}
