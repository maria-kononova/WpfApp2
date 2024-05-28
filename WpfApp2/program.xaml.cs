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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для program.xaml
    /// </summary>
    public partial class program : Window
    {
        private User user;
        private int selectedId;

        public program(User user)
        {
            InitializeComponent();
            this.user = user;
            loadDataGrid();
            loadComboBox();
        }

        public void loadDataGrid()
        {
            var db = Helper.GetContext();
            var list = from a in db.Appeals
                       join e in db.Equipment on a.Equipment equals e.Id
                       join te in db.Typequipments on e.Type equals te.Id
                       join c in db.Clients on a.Client equals c.Id
                       join s in db.Statuses on a.Status equals s.Id
                       select new {Номер = a.Id, Оборудование = te.Name, Неисправность = a.Problem, Дата_создания = a.DateStart, Клиент = c.Name + " " +c.Surname, Статус = s.Name };
            appealDataGrid.ItemsSource = list.ToList();
        }

        public void loadComboBox()
        {
            var db = Helper.GetContext();
            var typeEquipment = db.Typequipments.Select( e => e.Name);
            typeEquipmentComboBox.ItemsSource = typeEquipment.ToList();
            var statusApeal = db.Statuses.Select( e => e.Name);
            statusApealComboBox.ItemsSource = statusApeal.ToList();
            var master = db.Employeers.Select( e => e.Name + " " + e.Surname);
            masterComboBox.ItemsSource = master.ToList();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var db = Helper.GetContext();

            Client client = new Client();
            client.Id = (from u in db.Clients
                         select u.Id).OrderByDescending(id => id).FirstOrDefault() + 1;
            client.Name = nameClientTextBox.Text.Split(' ')[0];
            client.Surname = nameClientTextBox.Text.Split(' ')[0];

            Equipment equipment = new Equipment();
            equipment.Id = (from u in db.Equipment
                            select u.Id).OrderByDescending(id => id).FirstOrDefault() + 1;
            equipment.SerialNumber = serialNumberTextBox.Text;
            equipment.Type = db.Typequipments.Where(t => t.Name == typeEquipmentComboBox.SelectedItem.ToString()).Select(s => s.Id).FirstOrDefault();

            Appeal appeal = new Appeal();
            appeal.Id = (from u in db.Appeals
                         select u.Id).OrderByDescending(id => id).FirstOrDefault() + 1;
            appeal.Equipment = equipment.Id;
            appeal.Client = client.Id;
            appeal.Problem = problemTextBox.Text;
            appeal.DateStart = DateOnly.FromDateTime(DateTime.Now); //!!!!
            appeal.Status = db.Statuses.Where(s => s.Name == "Принято").Select(s => s.Id).FirstOrDefault(); //!!!

            db.Add(client);
            db.Add(equipment);
            db.Add(appeal);
            db.SaveChanges();
            loadDataGrid();

        }


        private void appealDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DataGridRow selectedRow = (DataGridRow)appealDataGrid.ItemContainerGenerator.ContainerFromItem(appealDataGrid.SelectedItem);

                // Получаем ячейку в первой колонке выбранной строки
                DataGridCell cell = appealDataGrid.Columns[0].GetCellContent(selectedRow).Parent as DataGridCell;

                // Получаем значение ячейки
                string value = ((TextBlock)cell.Content).Text;

                var db = Helper.GetContext();
                Appeal appeal = db.Appeals.Where(s => s.Id == Convert.ToInt32(value)).FirstOrDefault();

                descriptionProblemEdit.Text = appeal.Problem;
                selectedId = Convert.ToInt32(value);
                editTitleTextBlock.Text = "Редактирование заявки №" + selectedId;

                /*stage stage = new stage(Convert.ToInt32(value));
                stage.Show();

                stage.Closed += (sender, e) =>
                {
                    loadDataGrid();
                };*/

            }
        }


        private void updateDataGrid_Click(object sender, RoutedEventArgs e)
        {
            loadDataGrid();
        }

        private void editSave_Click(object sender, RoutedEventArgs e)
        {
            var db = Helper.GetContext();
            Appeal appeal = db.Appeals.Where(s => s.Id == selectedId).FirstOrDefault();
            appeal.Problem = descriptionProblemEdit.Text;
            db.Update(appeal);
            db.SaveChanges();
            loadDataGrid();
        }
    }
}
