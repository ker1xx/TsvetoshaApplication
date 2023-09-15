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
using TsvetoshaApplication.UserWindows.AdminView;

namespace TsvetoshaApplication
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(string name, string surname, string patronymic)
        {
            InitializeComponent();
            GreetingsText.Text += $"\n{name}, {surname}, {patronymic}";
        }

        private void ShowUsersButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new ShowUsersFrame(this);
        }
    }
}
