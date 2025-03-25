using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalBase
{
     class Program
    {
        static void Main(string[] args)
        {
            Connector.Select("*", "Disciplines");

            int value;
            //1
            Console.WriteLine("Введите название дисциплины: ");
            value = Connector.NameOfDiscipline(Console.ReadLine());
            if (value != 0)
            {
                Console.WriteLine($"Id дисциплины: {value}");
            }
            //2
            Console.WriteLine("Введите фамилию преподавателя: ");
            value = Connector.NameOfTeacher(Console.ReadLine());
            if (value != 0)
            {
                Console.WriteLine($"Id преподавателя: {value}");
            }
            //3
            value = Connector.QuantityOfStudents();
            if (value != 0)
            {
                Console.WriteLine($"Количество студентов: {value}");
            }
        }
    }
}
