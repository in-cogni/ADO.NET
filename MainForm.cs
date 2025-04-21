using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Runtime.InteropServices;

namespace Academy
{
    public partial class MainForm : Form
    {
        Connector connector;

        public Dictionary<string, int> d_directions;
        public Dictionary<string, int> d_groups;

        public Dictionary<ComboBox, List<ComboBox>> d_children;
        public Dictionary<ComboBox, List<ComboBox>> d_parents;

        DataGridView[] tables;

        Query[] queries = new Query[]
        {
            new Query
            (
                "last_name,first_name,middle_name,birth_date,group_name,direction_name",
                            "Students JOIN Groups ON ([group]=group_id) JOIN Directions ON (direction=direction_id)"
                            //"[group]=group_id AND direction=direction_id"
                   ),
            new Query
            (
                "group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
                            "Groups,Directions",
                            "direction=direction_id"

                ),
            new Query
            (
                "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                       "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
                       "",
                       "direction_name"

                ),
            new Query("*", "Disciplines"),
             new Query("*", "Teachers")
        };
        string[] status_messages = new string[]
        {
            $"Количество студентов",
            $"Количество групп",
            $"Количество направлений",
            $"Количество дисциплин",
            $"Количество преподавателей"
        };
        public MainForm()
        {
            InitializeComponent();

            d_children = new Dictionary<ComboBox, List<ComboBox>>()
            {
                {cbStudentsDirection, new List<ComboBox>(){cbStudentsGroup } }
            };
            d_parents = new Dictionary<ComboBox, List<ComboBox>>()
            {
                { cbStudentsGroup, new List<ComboBox> {cbStudentsDirection } }
            };
            tables = new DataGridView[]
            {
                dgvStudents,
                dgvGroups,
                dgvDirections,
                dgvDisciplines,
                dgvTeachers
            };

            connector = new Connector
                (
                    ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString, toolStripStatusLabelCount
                );
            d_directions = connector.GetDictionary("*", "Directions");
            d_groups = connector.GetDictionary("group_id,group_name", "Groups");
            cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key).ToArray());
            cbGroupsDirection.Items.AddRange(d_directions.Select(k => k.Key).ToArray());
            cbStudentsDirection.Items.AddRange(d_directions.Select(d => d.Key).ToArray());
            cbStudentsGroup.Items.Insert(0, "Все группы");
            cbStudentsDirection.Items.Insert(0, "Все направления");
            cbGroupsDirection.Items.Insert(0, "Все направлнения");
            cbStudentsGroup.SelectedIndex = 0;
            cbStudentsDirection.SelectedIndex = 0;
            cbGroupsDirection.SelectedIndex = 0;
            //dgv - DataGridView
            dgvStudents.DataSource = connector.Select
                (
                    "last_name,first_name,middle_name,birth_date,group_name,direction_name",
                    "Students,Groups,Directions",
                     "[group]=group_id AND direction=direction_id"
                );
            //dgvGroups.DataSource = connector.Select("*", "Groups");
            //dgvDirections.DataSource = connector.Select("*", "Directions");
            //dgvDisciplines.DataSource = connector.Select("*", "Disciplines");
            //dgvTeachers.DataSource = connector.Select("*", "Teachers");
            //connector.StatusStrip();

            toolStripStatusLabelCount.Text = $"Количество студентов: {dgvStudents.RowCount - 1}.";
            loadPage(0);
            connector.ComboBox(comboBoxGroups, "Directions", "direction_name");
            connector.ComboBox(comboBoxStDirections, "Directions", "direction_name");
        }
        void loadPage(int i, Query query = null)
        {
            if(query==null)query = queries[tabControl.SelectedIndex];
            tables[i].DataSource
                = connector.Select(query.Columns, query.Tables, query.Condition, query.Group_by);
            toolStripStatusLabelCount.Text = status_messages[i] + CountRecordInDGV(tables[i]);

        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tab_name = tabControl.SelectedTab.Name;
            Console.WriteLine(tab_name);
            //int i = tabControl.SelectedIndex;
            loadPage(tabControl.SelectedIndex);
            #region SWITCH
            //switch(tabControl.SelectedIndex)
            //{
            //    case 0:
            //        dgvStudents.DataSource = 
            //            connector.Select
            //            (
            //                "last_name,first_name,middle_name,birth_date,group_name,direction_name", 
            //                "Students,Groups,Directions",
            //                "[group]=group_id AND direction=direction_id"
            //            );
            //        toolStripStatusLabelCount.Text = $"Количество студентов: {dgvStudents.RowCount - 1}.";
            //        comboBoxStDirections.Text = "Отобразить по направлению";
            //        comboBoxStGroups.Text = "Группа";
            //        break;
            //    case 1:
            //        dgvGroups.DataSource = connector.Select
            //            (
            //                "group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
            //                "Groups,Directions",
            //                "direction=direction_id"
            //            );
            //        toolStripStatusLabelCount.Text = $"Количество групп: {dgvGroups.RowCount - 1}.";
            //        comboBoxGroups.Text = "Отобразить по направлению";
            //        break;
            //    case 2:
            //        //dgvDirections.DataSource = connector.Select
            //        //    (
            //        //    //     "d.direction_id,d.direction_name," +
            //        //    //     "(SELECT COUNT(*) FROM Groups g WHERE g.direction = d.direction_id)" +
            //        //    //     " AS number_of_group," +
            //        //    //     "(SELECT COUNT(*) FROM Students s WHERE s.[group] IN (SELECT group_id FROM Groups WHERE direction = d.direction_id))" +
            //        //    //     " AS number_of_student",
            //        //    //     "Directions d"
            //        //    "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
            //        //    "Students,Groups,Directions",
            //        //    "[group]=group_id AND direction=direction_id",
            //        //    "direction_name"
            //        //    );
            //        dgvDirections.DataSource = connector.Select
            //           (
            //           "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
            //           //"Groups JOIN Directions ON (direction=direction_id) JOIN Students ON ([group]=group_id)",
            //           "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
            //           "",
            //           "direction_name"
            //           );
            //        toolStripStatusLabelCount.Text = $"Количество направлений: {dgvDirections.RowCount - 1}.";
            //        break;
            //    case 3:
            //        dgvDisciplines.DataSource = connector.Select("*", "Disciplines");
            //        toolStripStatusLabelCount.Text = $"Количество дисциплин: {dgvDisciplines.RowCount - 1}.";
            //        break;
            //    case 4:
            //        dgvTeachers.DataSource = connector.Select("*", "Teachers");
            //        toolStripStatusLabelCount.Text = $"Количество преподавателей: {dgvTeachers.RowCount - 1}.";
            //        break;
            //}   
            #endregion
        }

        private void comboBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directionNameCombo = comboBoxGroups.SelectedItem.ToString();//название выбранного направления
            dgvGroups.DataSource = connector.Select
                (
                    "group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
                    "Groups,Directions",
                    $"direction=direction_id AND direction_name=N'{directionNameCombo}'"
                );
        }

        private void comboBoxStGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directionNameCombo = comboBoxStDirections.SelectedItem.ToString();//название выбранного направления 
            string groupNameCombo = comboBoxStGroups.SelectedItem.ToString();//название выбранной группы
            dgvStudents.DataSource = connector.Select
                (
                    "last_name,first_name,middle_name,birth_date,group_name,direction_name",
                    "Students,Groups,Directions",
                    $"[group]=group_id AND direction=direction_id AND direction_name=N'{directionNameCombo}' AND group_name=N'{groupNameCombo}'"
                );
        }

        private void comboBoxStDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStGroups.Text = "Группа";
            comboBoxStGroups.Items.Clear();
            string directionNameCombo = comboBoxStDirections.SelectedItem.ToString();//название выбранного направления
            dgvStudents.DataSource = connector.Select
                 (
                     "last_name,first_name,middle_name,birth_date,group_name,direction_name",
                     "Students,Groups,Directions",
                     $"[group]=group_id AND direction=direction_id AND direction_name=N'{directionNameCombo}'"
                 );
            connector.ComboBox
                (
                comboBoxStGroups, "Groups,Directions", "group_name",
                $"direction=direction_id AND direction_name=N'{directionNameCombo}'"
                );
        }

       
        int CountRecordInDGV(DataGridView dgv)
        {
            return dgv.RowCount == 0 ? 0 : dgv.Rows.Count - 1;
        }

        private void checkBEmptyDirections_CheckedChanged(object sender, EventArgs e)//пустые направления в Directions
        {
            checkBUnEmptyDirections.Checked = true ? false : true;//убираем галку во втором checkBox, чтобы 2 галки не стояли одновременно
            dgvDirections.Columns.Clear();
            if (checkBEmptyDirections.Checked)//если нажали галку
            {
                dgvDirections.DataSource = connector.Select
                    (
                        "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                        "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
                        "",
                        "direction_name HAVING COUNT(DISTINCT group_id)=0 AND COUNT(stud_id)=0"//тут добавлено условие отбора 
                    );                                                                           //если есть пустые строки
            }
            else//если сняли галку - возвращаем все обратно
            {
                dgvDirections.DataSource = connector.Select
                    (
                        "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                        "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
                        "",
                        "direction_name"
                    );
            }
        }

        private void checkBUnEmptyDirections_CheckedChanged(object sender, EventArgs e)//частично или полностью заполненные направления в Directions
        {
            checkBEmptyDirections.Checked = true ? false : true;//убираем галку во втором checkBox
            dgvDirections.Columns.Clear();
            if (checkBUnEmptyDirections.Checked)//если нажали галку
            {
                dgvDirections.DataSource = connector.Select
                    (
                        "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                        "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
                        "",
                        "direction_name HAVING COUNT(DISTINCT group_id)!=0 OR COUNT(stud_id)!=0"//тут добавлено условие отбора 
                    );                                                                           //если хотя бы 1 строка не пустая
            }
            else//если сняли галку - возвращаем все обратно
            {
                dgvDirections.DataSource = connector.Select
                    (
                        "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                        "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
                        "",
                        "direction_name"
                    );
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cb_name = (sender as ComboBox).Name;
            string tab_name = tabControl.SelectedTab.Name;
            int last_capital_index = Array.FindLastIndex<char>(cb_name.ToCharArray(), Char.IsUpper);
            string cb_suffix = cb_name.Substring(last_capital_index);
            Console.WriteLine(cb_name);
            Console.WriteLine(tab_name);
            Console.WriteLine(cb_suffix);

            string dictionary_name = $"d_{cb_suffix.ToLower()}s";
            Dictionary<string, int> dictionary =
                this.GetType().GetField(dictionary_name).GetValue(this) as Dictionary<string, int>;
            ////////////////////////////////
            int i = (sender as ComboBox).SelectedIndex;
            #region Filtercb_StudentsGroup
            //Фильтруем выпадающий список групп на вкладке 'Students':
            //Dictionary<string, int> d_groups = connector.GetDictionary
            //    (
            //    "group_id,group_name",
            //    "Groups",
            //    i == 0 ? "" : $"[{cb_suffix.ToLower()}]={d_directions[(sender as ComboBox).SelectedItem.ToString()]}"
            //    );
            //cbStudentsGroup.Items.Clear();
            //cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key).ToArray());
            if(d_children.ContainsKey(sender as ComboBox))
            {
                foreach(ComboBox cb in d_children[sender as ComboBox])
                {
                    GetDependentData(cb, sender as ComboBox);
                }
            }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            #endregion     
            
            Query query = new Query(queries[tabControl.SelectedIndex]);
            string condition = 
                (
                i == 0 || 
                (sender as ComboBox).SelectedItem==null ? "" : 
                $"[{cb_suffix.ToLower()}]={dictionary[$"{(sender as ComboBox).SelectedItem}"]}"
                );
            string parent_condition = "";
            if(d_parents.ContainsKey(sender as ComboBox))
            {
                foreach (ComboBox cb in d_parents[sender as ComboBox])
                {
                    if (cb.SelectedItem != null && cb.SelectedIndex>0)
                    {
                        string column_name = cb.Name.Substring(Array.FindLastIndex<char>(cb.Name.ToCharArray(), Char.IsUpper));
                        string parent_dictionary_name = $"d_{column_name.ToLower()}s";
                        Dictionary<string, int> parent_dictionary = this.GetType().GetField(parent_dictionary_name).GetValue(this) as Dictionary<string, int>;
                        if (parent_condition != "") parent_condition += " AND ";
                        parent_condition += $"[{column_name}]={parent_dictionary[cb.SelectedItem.ToString()]}";
                    }
                }
            }

            if (query.Condition == "") query.Condition = condition;
            else if(condition!="") query.Condition += $" AND {condition}";
            if (query.Condition == "") query.Condition = parent_condition;
            else if (parent_condition != "") query.Condition += $" AND { parent_condition}";
            loadPage(tabControl.SelectedIndex, query);
        }
        void GetDependentData(ComboBox dependent, ComboBox determinant)
        {
            Console.WriteLine($"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(dependent.Name +"\t" + determinant.Name);
            string dependent_root = 
                dependent.Name.Substring(Array.FindLastIndex<char>(dependent.Name.ToCharArray(), Char.IsUpper));
            string determinant_root = 
                determinant.Name.Substring(Array.FindLastIndex<char>(determinant.Name.ToCharArray(), Char.IsUpper));

            Dictionary<string, int> dictionary =
                connector.GetDictionary
                (
                    $"{dependent_root.ToLower()}_id,{dependent_root.ToLower()}_name",
                    $"{dependent_root}s,{determinant_root}s",
                    determinant.SelectedItem == null || determinant.SelectedIndex<=0? "":$"{determinant_root.ToLower()}={determinant.SelectedIndex}"
                );
            foreach(KeyValuePair<string, int> d in dictionary)
            {
                Console.WriteLine($"{d.Value}\t{ d.Key}");
            }
            dependent.Items.Clear();
            dependent.Items.AddRange(dictionary.Select(d=> d.Key).ToArray());
            dependent.Items.Insert(0, "Все");
            dependent.SelectedIndex = 0;

            Console.WriteLine(dependent_root);
            Console.WriteLine($"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
