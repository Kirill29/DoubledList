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
    /// Добавляем Рейс в двусвязный список
    public partial class Add : Window
    {
        //создаем экземпляр двухсвязного списка
        private DoublyLinkedList<Flight> linkedList = new DoublyLinkedList<Flight>();
        //создаем экземпляр односвязного списка аэропортов
        static List<string> Airport = new List<string>();
        public Add()
        {
            InitializeComponent();
           

        }
        //добавляем рейсы в двусвязный список
        private void Flight_Add_Click(object sender, RoutedEventArgs e)
        {
            //создаем экземпляр рейса
            Flight flight = new Flight();
            //строка для вывода списка Аэропортов
            string airport_result="";
            //Если одно или несколько полей-пустые
            if ((Flight_Dep_Date.Text=="") || (Flight_Ret_Date.Text=="") || (Flight_Number.Text=="") || (Flight_Type.Text == ""))
            {
                MessageBox.Show("Необходимо заполнить все поля!");
            }
            else
            {
                //заполняем экземпляр рейса данными
                try
                {
                    flight.Number = Flight_Number.Text;
                    flight.Type = Flight_Type.Text;
                    flight.Dep_Date = Flight_Dep_Date.SelectedDate;
                    flight.Ret_Date = Flight_Ret_Date.SelectedDate;
                    flight.Airport = Airport.ToList();
                    //добавляем рейс в двусвязанный список
                    linkedList.Add(flight);
                    //передаем список в статическое хранилище(чтобы наш список был доступен для других форм)
                    Share.Flight_list.Add(flight);
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //выводим полученный рейс в поле для вывода
                    Flight_Result.Text = flight.ToString();
                    //выводим список аэропортов для данного рейса
                    foreach (string airport in Airport)
                    {
                        airport_result = airport_result + airport + " ";
                    }
                    Airport_Result.Text = airport_result;
                    MessageBox.Show("Запись успешно добавлена!");
                }

                //Очищаем поле для выода
                Airport.Clear();
            }
           

        }
        //заполняем список аэропортов
        private void AirPort_Add_Click(object sender, RoutedEventArgs e)
        {
           //если поле пустое,то сообщение пользователю
            if (AirPort_Value.Text == "")
            {
                MessageBox.Show("Необходимо добавить хотя бы один Аэропорт!");
            }
            else
            {
                //добавляем элемент в список
                Airport.Add(AirPort_Value.Text);
                MessageBox.Show("Аэропорт добавлен!");
            }
           



        }
    }
}
