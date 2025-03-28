//#define OLD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Data;

using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Academy
{
    class Connector
    {
        readonly string CONNECTION_STRING;// = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
        SqlConnection connection;
        private ToolStripStatusLabel toolStripStatusLabel1;
        public Connector(string connection_string, ToolStripStatusLabel toolStripStatusLabel1)
        {
            //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
            CONNECTION_STRING = connection_string;
            connection = new SqlConnection(CONNECTION_STRING);
            AllocConsole();
            Console.WriteLine(CONNECTION_STRING);
            this.toolStripStatusLabel1 = toolStripStatusLabel1;
        }
        ~Connector()
        {
            FreeConsole();
        }
        public DataTable Select(string colums, string tables, string condition="")
        {

            DataTable table = null;
            string cmd = $"SELECT {colums} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            cmd += ";";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {

                //1) создаем таблицу: 
                table = new DataTable();
                table.Load(reader);
#if OLD

                //2) добавляем в нее поля:
                for (int i=0; i<reader.FieldCount; i++)
                {
                    table.Columns.Add();
                }

                //3) заполняем таблицу:
                while(reader.Read())
                {
                    DataRow row = table.NewRow();
                    for(int i=0; i<reader.FieldCount;i++)
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);
                }
#endif
            }

            reader.Close();
            connection.Close();

            return table;
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
        public void StatusStrip()
        {
            try
            {
                connection.Open();

                int studentCount = GetRecordCount(connection, "Students");// Получаем количество студентов
                int groupCount = GetRecordCount(connection, "Groups");// Получаем количество групп
                int directionCount = GetRecordCount(connection, "Directions");// Получаем количество направлений
                int disciplineCount = GetRecordCount(connection, "Disciplines");// Получаем количество дисциплин
                int teacherCount = GetRecordCount(connection, "Teachers");// Получаем количество преподавателей

                // Обновляем статус-строку
                toolStripStatusLabel1.Text = $"Студенты: {studentCount}, Группы: {groupCount}, Направления: {directionCount}, Дисциплины: {disciplineCount}, Преподаватели: {teacherCount}";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: \n" + ex.Message);
            }
        }
        private int GetRecordCount(SqlConnection connection, string tableName)
        {
            using (SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", connection))
            {
                return (int)command.ExecuteScalar();
            }
        }
        public void ComboBox(ComboBox comboBox, string tablename, string column, string condition = "")//добавление строк в combobox 
        {
            comboBox.Items.Clear();
            string cmd = $"SELECT DISTINCT {column} FROM {tablename}";
            if (condition != "") cmd += $" WHERE {condition}";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox.Items.Add(reader.GetString(0));
            }
            reader.Close();
            connection.Close();
        }
    }
   
}
