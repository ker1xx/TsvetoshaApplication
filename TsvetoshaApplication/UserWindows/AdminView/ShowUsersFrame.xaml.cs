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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TsvetoshaApplication.Global;
using TsvetoshaApplication.Models;

namespace TsvetoshaApplication.UserWindows.AdminView
{
    /// <summary>
    /// Логика взаимодействия для ShowUsersFrame.xaml
    /// </summary>
    public partial class ShowUsersFrame : Page
    {
        private AdminWindow _adminWinow;
        public ShowUsersFrame(AdminWindow adminWinow)
        {
            InitializeComponent();
            StaticMethods.GetShops();
            StaticMethods.GetRoles();
            Variables.FillEmpListForDisplay();
            this._adminWinow = adminWinow;
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeUserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            _adminWinow.ContentFrame.Content = new EditUserFrame((int)(UsersDataGrid.SelectedItem as DataRowView)[0]);  
        }
    }
}
