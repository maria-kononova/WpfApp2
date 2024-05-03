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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для stage.xaml
    /// </summary>
    public partial class stage : Window
    {
        private int selectedId;

        public stage(int id)
        {
            InitializeComponent();
            selectedId = id;
            loadDataGrid();

        }

        public void loadDataGrid()
        {
            var db = Helper.GetContext();
            var list = from s in db.Stages
                       join stat in db.Statuses on s.Status equals stat.Id
                       join e in db.Employeers on s.Employeer equals e.Id
                       where s.Appeal == selectedId
                       select new { ИД = s.Id, Дата = s.Date, Сотрудник = e.Name + " " + e.Surname, Статус = stat.Name };
            stageDataGrid.ItemsSource = list.ToList();
        }

        private void stageDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var db = Helper.GetContext();
            if (e.ChangedButton == MouseButton.Left)
            {
                DataGridRow selectedRow = (DataGridRow)stageDataGrid.ItemContainerGenerator.ContainerFromItem(stageDataGrid.SelectedItem);

                // Получаем ячейку в первой колонке выбранной строки
                DataGridCell cell = stageDataGrid.Columns[0].GetCellContent(selectedRow).Parent as DataGridCell;

                // Получаем значение ячейки
                int value = Convert.ToInt32(((TextBlock)cell.Content).Text);

                var costl = from r in db.Resources
                           where r.Stage == value
                           join m in db.Materials on r.Material equals m.Id
                           select new { m.Cost, r.Count };
            }
        }
    }
}
