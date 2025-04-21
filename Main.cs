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

namespace Academy
{
	public partial class Main : Form
	{
        Connector connector;
        Dictionary<string, int> d_directions;
		public Main()
		{

			InitializeComponent();

            connector = new Connector
				(
                    ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString, toolStripStatusLabelCount
				);
            d_directions = connector.GetDictionary("*", "Directions");
            cbGroupsDirections.Items.AddRange(d_directions.Select(k => k.Key).ToArray());
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

            connector.ComboBox(comboBoxGroups, "Directions", "direction_name");
            connector.ComboBox(comboBoxStDirections, "Directions", "direction_name");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl.SelectedIndex)
            {
                case 0:
                    dgvStudents.DataSource = 
                        connector.Select
                        (
                            "last_name,first_name,middle_name,birth_date,group_name,direction_name", 
                            "Students,Groups,Directions",
                            "[group]=group_id AND direction=direction_id"
                        );
                    toolStripStatusLabelCount.Text = $"Количество студентов: {dgvStudents.RowCount - 1}.";
                    comboBoxStDirections.Text = "Отобразить по направлению";
                    comboBoxStGroups.Text = "Группа";
                    break;
                case 1:
                    dgvGroups.DataSource = connector.Select
                        (
                            "group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
                            "Groups,Directions",
                            "direction=direction_id"
                        );
                    toolStripStatusLabelCount.Text = $"Количество групп: {dgvGroups.RowCount - 1}.";
                    comboBoxGroups.Text = "Отобразить по направлению";
                    break;
                case 2:
                    //dgvDirections.DataSource = connector.Select
                    //    (
                    //    //     "d.direction_id,d.direction_name," +
                    //    //     "(SELECT COUNT(*) FROM Groups g WHERE g.direction = d.direction_id)" +
                    //    //     " AS number_of_group," +
                    //    //     "(SELECT COUNT(*) FROM Students s WHERE s.[group] IN (SELECT group_id FROM Groups WHERE direction = d.direction_id))" +
                    //    //     " AS number_of_student",
                    //    //     "Directions d"
                    //    "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                    //    "Students,Groups,Directions",
                    //    "[group]=group_id AND direction=direction_id",
                    //    "direction_name"
                    //    );
                    dgvDirections.DataSource = connector.Select
                       (
                       "direction_name,COUNT(DISTINCT group_id) AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов'",
                       //"Groups JOIN Directions ON (direction=direction_id) JOIN Students ON ([group]=group_id)",
                       "Students RIGHT JOIN Groups ON([group]=group_id) RIGHT JOIN Directions ON(direction=direction_id)",
                       "",
                       "direction_name"
                       );
                    toolStripStatusLabelCount.Text = $"Количество направлений: {dgvDirections.RowCount - 1}.";
                    break;
                case 3:
                    dgvDisciplines.DataSource = connector.Select("*", "Disciplines");
                    toolStripStatusLabelCount.Text = $"Количество дисциплин: {dgvDisciplines.RowCount - 1}.";
                    break;
                case 4:
                    dgvTeachers.DataSource = connector.Select("*", "Teachers");
                    toolStripStatusLabelCount.Text = $"Количество преподавателей: {dgvTeachers.RowCount - 1}.";
                    break;
            }
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
            comboBoxStGroups.Text="Группа";
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

        private void cbGroupsDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGroups.DataSource = connector.Select
                (
                "group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
                "Groups,Directions",
                $"direction=direction_id AND direction = N'{d_directions[cbGroupsDirections.SelectedItem.ToString()]}'"
                );
            toolStripStatusLabelCount.Text = $"Количество групп : {CountRecordInDGV(dgvGroups)}";
        }
        int CountRecordInDGV (DataGridView dgv)
        {
            return dgv.RowCount == 0? 0: dgv.Rows.Count - 1;
            
		}
	}
}
