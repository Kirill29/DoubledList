using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TP22
{
    public class Flight
    {
        public Flight(string Number,string Type,DateTime? Dep_Date, DateTime? Ret_Date,List<string>Airport)
        {
            this.Number = Number;
            this.Ret_Date = Ret_Date;
            this.Type = Type;
            this.Dep_Date = Dep_Date;
            this.Airport = Airport;

        }
        public Flight() { }
        //Номер рейса
        public string Number { get; set; }
        //Тип воздушного суднв
        public string Type { get; set; }
        //Дата отправления
        public DateTime? Dep_Date { get; set; }
        //Дата прилета
        public DateTime? Ret_Date { get; set; }
        //Список аэропортов
        public List<string> Airport { get; set; }
        public string Airport_string { get; set; }
        
        //красивый вывод
        public override string ToString()
        {
            return (" Номер: " + Number + " " + "Тип: " + Type + " " + "Вылет: " + Dep_Date + " " + "Прилет: " + Ret_Date);
        }




    }

}
