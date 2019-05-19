using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Show : Window
    {
        //двухсвязанный список
        private DoublyLinkedList<Flight> flight_list = new DoublyLinkedList<Flight>();
        Flight current;
       //конструктор класса
       //при создании окна передаем список из статического хранилища
        public Show(DoublyLinkedList<Flight> Flight_list)
        {
            flight_list = Flight_list;
            InitializeComponent();
        }
        //выводим двухсвязанный список рейсов на форму
        private void Show_All(object sender, RoutedEventArgs e)
        {

            flight_show.Items.Clear();
            flight_show.SelectedIndex = 0;
            
            foreach (var el in flight_list)
            {
                flight_show.Items.Add(el);
                current = el;
            }
        }
        //выводим список аэропортов по выделенному элементу списка рейсов
        private void Show_Airport(object sender, RoutedEventArgs e)
        {
            
            Airport_show.Items.Clear();
            Airport_show.SelectedIndex = 0;
            Flight current;
            try
            {
                //получаем выбранный на форме рейс
                current = flight_show.SelectedItems[0] as Flight;
                if (current == null)
                {
                    MessageBox.Show("Необходимо выбрать хотя бы один элемент!");
                    return;
                }
                else
                {
                    //для привязки списка к форме и выводу его на форму 
                    //необходимо создать список элементов класса StringValue
                    //так как необходим класс со строковым полем
                    List<StringValue> Aiportik = new List<StringValue>();
                    foreach (var el in current.Airport)
                    {
                        StringValue st = new StringValue(el);

                        Aiportik.Add(st);
                    }
                    foreach (var el in Aiportik)
                    {
                        Airport_show.Items.Add(el);
                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


      
        //удаление элемента двухсвязанного элемента
        private void Flight_delete(object sender, RoutedEventArgs e)
        {
            //получаем выделенный пользователем элемент двухсвязанного списка
            var current_flight = flight_show.SelectedItems[0] as Flight;
            if (current_flight == null)
            {
                MessageBox.Show("Необходимо выбрать хотя бы один элемент!");
                return;
            }
            else
            {
                //удаляем элемент двухсвязного списка
                flight_list.Remove(current_flight);
                if (flight_list.Count == 0)
                {
                    Airport_show.Items.Clear();
                }
                //current = current_flight;

                //передаем измененный двухсвязанный список в статистическое хранилище
                Share.Flight_list = flight_list;
            }
           
           

        }
        //изменение элемента двухсвязанного списка
        private void Flight_edit(object sender, RoutedEventArgs e)
        {
            //получаем выделенный пользователем элемент двухсвязанного списка
            var current = flight_show.SelectedItems[0] as Flight;
            if (current == null)
            {
                MessageBox.Show("Необходимо выбрать хотя бы один элемент!");
                return;
            }
            else
            {
                //создаем окно для измения данных элемента двухсвязного списка
                Flight_Edit Flight_Edit = new Flight_Edit(current);
                //открываем окно для измения
                Flight_Edit.Show();
            }
            this.Close();



        }


        
    }
}


