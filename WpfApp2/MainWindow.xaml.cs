using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if(regButton.Content == "Зарегистрироваться")
            {
                regPanel.Visibility = Visibility.Visible;
                authButton.Content = "Зарегистрироваться";
                regButton.Content = "Авторизироваться";
            }
            else
            {
                regPanel.Visibility = Visibility.Collapsed;
                authButton.Content = "Войти";
                regButton.Content = "Зарегистрироваться";
            }
            
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            if (authButton.Content == "Зарегистрироваться")
            {
                createNewUser(loginTextBox.Text, passwordTextBox.Text);
            }
            else
            {
                auth(loginTextBox.Text, passwordTextBox.Text);
            }
        }

        public void auth(String login, String password)
        {
            var db = Helper.GetContext();
            var user = db.Users.FirstOrDefault(u => u.Login == login); //!!!
            if (user != null)
            {
                if (user.Password == password)
                {
                    program program = new program(user);
                    program.Show();
                    this.Close();
                }
                else error.Text = "Пароль не верный";
            }
            else error.Text = "Логин не найден";

        }

        public void createNewUser(String login, String password)
        {
            var db = Helper.GetContext();
            var newUser = new User();
            newUser.Id = (from u in db.Users
                          select u.Id).OrderByDescending(id => id).FirstOrDefault() +1; //получения максимального id
            newUser.Login = login;
            newUser.Password = password;
            newUser.Role = 1;
            db.Add(newUser);
            db.SaveChanges();
        }
    }
}