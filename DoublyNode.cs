using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP22
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        //данные узла
        public T Data { get; set; }
        //Ссылаемся на предыдущий элемент
        public DoublyNode<T> Previous { get; set; }
        //ссылаемся на следующий элемент
        public DoublyNode<T> Next { get; set; }
    }
}
