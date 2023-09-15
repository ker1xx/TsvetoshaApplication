using System.Windows;
using TsvetoshaApplication.Global;
using TsvetoshaApplication.Models;
using TsvetoshaApplication.UserWindows;

namespace TsvetoshaApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StaticMethods.GetAuthorizationData();
            StaticMethods.GetUsers();
        }
        /// <summary>
        /// вызывает метод, получающий данные пользователя на основе введенных данных и возвращает id,  которое передается в качестве параметра в метод, возвращающий роль пользователя по id, после чего роль передается в метод, который открывает нужное окно в зависимости от роли пользователя
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int userID = (int)StaticMethods.GetUserIDByAuthorizationData(LoginInput.Text, PasswordInput.Password);
            LogIntoAcountByRole((int)StaticMethods.GetUserRole(
               userID), GlobalVariables.EmployeesList[userID-1]);
        }
        /*Открывает гостевое окно*/
        private void LoginAsGuestButton_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWin = new GuestWindow();
            guestWin.Show();
        }
        /// <summary>
        /// открывает окно в зависимости от роли авторизовавшегося пользователя
        /// </summary>
        private void LogIntoAcountByRole(int role,EmployeeModel emp)
        {
            switch (role)
            {
                case 1:
                    AdminWindow admWin = new AdminWindow(emp.Name,emp.Surname,emp.Patronymic);
                    this.Visibility = Visibility.Hidden;
                    admWin.Show();
                    break;
                case 2:
                    SellerWindow selWin = new SellerWindow(emp.Name, emp.Surname, emp.Patronymic);
                    this.Visibility = Visibility.Hidden;
                    selWin.Show();
                    break;
                case 3:
                    StorageManagerWindow storWin = new StorageManagerWindow(emp.Name, emp.Surname, emp.Patronymic);
                    this.Visibility = Visibility.Hidden;
                    storWin.Show();
                    break;
                case 4:
                    FloristWindow florWin = new FloristWindow(emp.Name, emp.Surname, emp.Patronymic);
                    this.Visibility = Visibility.Hidden;
                    florWin.Show();
                    break;
                default:
                    MessageBox.Show("Функционал для данной роли еще в разработке. Пропобуйте войти позднее");
                    break;
            }
        }
    }
}
