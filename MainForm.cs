using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.Design;


namespace Academy_DataSet
{
    public partial class MainForm : Form
    {
        Cache GroupsRelatedData;
        public MainForm()
        {
            InitializeComponent();
            AllocConsole();

            GroupsRelatedData = new Cache();

            GroupsRelatedData.AddTable("Directions", "direction_id,direction_name");
            GroupsRelatedData.AddTable("Groups", "group_id,group_name,direction");
            GroupsRelatedData.AddRelation("GroupsDirections", "Groups,direction","Directions,direction_id");
            GroupsRelatedData.Load();
            GroupsRelatedData.Print("Directions");
            GroupsRelatedData.Print("Groups");

            //загружаем направления из базы в combobox:
            //1) Направления обучения уже загружены в таблицу в DataSet, и эту таблицу мы указываем как источник данных:
            cbDirections.DataSource = GroupsRelatedData.Set.Tables["Directions"];
            //2) Из множества полец таблицы нужно указать, какое поле будет отображаться в выпадающем списке,
            cbDirections.DisplayMember = "direction_name";
            //3) И какое поле будет возвращаться при выборе элемента ComboBox
            cbDirections.ValueMember ="direction_id";

            cbGroups.DataSource = GroupsRelatedData.Set.Tables["Groups"];
            cbGroups.DisplayMember = "group_name";
            cbGroups.ValueMember = "group_id";
        }
        private void cbDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(GroupsRelatedData.Set.Tables["Directions"].ChildRelations);
            DataRow row = GroupsRelatedData.Set.Tables["Directions"].Rows.Find(cbDirections.SelectedValue);
            //cbGroups.DataSource = row.GetChildRows("GroupsDirections");
            //cbGroups.DisplayMember = "group_name";
            //cbGroups.ValueMember = "group_id";
            GroupsRelatedData.Set.Tables["Groups"].DefaultView.RowFilter = $"direction={cbDirections.SelectedValue}";
        }

#if true
        //DataTable CreateDirectionsTable()
        //{
        //    const string tableName = "Directions";
        //    const string idColumn = "direction_id";
        //    const string nameColumn = "direction_name";

        //    var table = new DataTable(tableName);
        //    table.Columns.Add(idColumn, typeof(byte));
        //    table.Columns.Add(nameColumn, typeof(string));
        //    table.PrimaryKey = new[] { table.Columns[idColumn] };

        //    return table;
        //}

        //DataTable CreateGroupsTable()
        //{
        //    const string tableName = "Groups";
        //    const string idColumn = "group_id";
        //    const string nameColumn = "group_name";
        //    const string directionColumn = "direction";

        //    var table = new DataTable(tableName);
        //    table.Columns.Add(idColumn, typeof(int));
        //    table.Columns.Add(nameColumn, typeof(string));
        //    table.Columns.Add(directionColumn, typeof(byte));
        //    table.PrimaryKey = new[] { table.Columns[idColumn] };

        //    return table;
        //}  ниче
#endif
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}

