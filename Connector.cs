using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
namespace ExternalBase
{
    static class Connector
    {
        static readonly int PADDING = 16;
        static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
        static SqlConnection connection;
        static Connector()
        {
            Console.WriteLine(CONNECTION_STRING);
            connection = new SqlConnection(CONNECTION_STRING);
        }
        public static void Select(string fields, string tables, string condition = "")
        {
            string cmd = $"SELECT {fields} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            SqlCommand command = new SqlCommand(cmd, connection);   
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                for(int i=0; i<reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i).PadRight(PADDING));
                }
            }
            Console.WriteLine();
            while (reader.Read())
            {
                for(int i=0; i<reader.FieldCount; i++)
                {
                    Console.Write(reader[i].ToString().PadRight(PADDING));
                }
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
        //1. Написать метод, который по названию дисциплины возвращает 'id' дисциплины;
        public static int NameOfDiscipline(string name)
        {
            using (SqlCommand command = new SqlCommand($"SELECT discipline_id FROM Disciplines WHERE discipline_name = @name", connection))
            {
                command.Parameters.Add(new SqlParameter("@name", name));
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    int? id = result != null ? (int?)Convert.ToInt32(result) : null;//проверяем на null и приводим к int
                    if (id.HasValue)//содержит ли переменная значение
                    {
                        connection.Close();
                        return id.Value;
                    }
                    else
                    {
                        Console.WriteLine("Дисциплина не найдена");
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: \n" + e.Message);
                }
            }
            return 0;
        }
        //2. Написать метод, который по фамилии преподавателя возвращает 'id' преподавателя;
        public static int NameOfTeacher(string name)
        {
            using (SqlCommand command = new SqlCommand($"SELECT teacher_id FROM Teachers WHERE last_name = @name", connection))
            {
                command.Parameters.Add(new SqlParameter("@name", name));
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    int? id = result != null ? (int?)Convert.ToInt32(result) : null;//проверяем на null и приводим к int
                    if (id.HasValue)//содержит ли переменная значение
                    {
                        connection.Close();
                        return id.Value;
                    }
                    else
                    {
                        Console.WriteLine("Преподаватель не найден");
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: \n" + e.Message);
                }
            }
            return 0;
        }
        //3. Написать метод, который подсчитывает количество студентов;
        public static int QuantityOfStudents()
        {
            using (SqlCommand command = new SqlCommand($"SELECT COUNT (stud_id) FROM Students", connection))
            {
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    int? id = result != null ? (int?)Convert.ToInt32(result) : null;//проверяем на null и приводим к int
                    if (id.HasValue)//содержит ли переменная значение
                    {
                        connection.Close();
                        return id.Value;
                    }
                    else
                    {
                        Console.WriteLine("Студенты не найдены");
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: \n" + e.Message);
                }
            }
            return 0;
        }
    }
}
