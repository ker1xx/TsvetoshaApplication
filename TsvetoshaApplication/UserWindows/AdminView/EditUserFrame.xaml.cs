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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TsvetoshaApplication.Global;
using TsvetoshaApplication.Models;

namespace TsvetoshaApplication.UserWindows.AdminView
{
    /// <summary>
    /// Логика взаимодействия для EditUserFrame.xaml
    /// </summary>
    public partial class EditUserFrame : Page
    {
        private int _id;
        public EditUserFrame(int id)
        {
            InitializeComponent();
            init();
            _id = id;
        }
        private void init()
        {
            foreach (RoleModel role in GlobalVariables.RolesList)
                RolePicker.Items.Add(role.Name);
            RolePicker.DisplayMemberPath = "Name";
            RolePicker.SelectedValuePath = "Id";
            foreach (ShopModel shop in GlobalVariables.ShopsList)
                WorkingAddressPicker.Items.Add(shop.Address);
            WorkingAddressPicker.DisplayMemberPath = "Address";
            WorkingAddressPicker.SelectedValuePath = "Id";
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            StaticMethods.PutAuthorizeData(_id, LoginInput.Text, PasswordInput.Text);
            StaticMethods.PutUsers(_id, NameInput.Text, SurnameInput.Text, PatronymicInput.Text, (int)RolePicker.SelectedValue, Convert.ToDecimal(SalaryInput.Text), (int)WorkingAddressPicker.SelectedValue, _id);
        }
    }
}
