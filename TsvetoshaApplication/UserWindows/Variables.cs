using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using TsvetoshaApplication.Global;
using TsvetoshaApplication.Models;

namespace TsvetoshaApplication.UserWindows
{
    internal class Variables
    {
        public static List<EmployeeDisplayModel> EmployeeToDisplayList = new List<EmployeeDisplayModel>() { };
        public static void FillEmpListForDisplay()
        {
            foreach (var e in GlobalVariables.EmployeesList)
            {
                EmployeeToDisplayList.Add(new EmployeeDisplayModel((int)e.Id,
                    e.Name,
                    e.Surname,
                    e.Patronymic,
                    GlobalVariables.RolesList[e.JobTitleId-1].Name,
                    e.Salary,
                    GlobalVariables.ShopsList[e.ShopId-1].Address,
                    GlobalVariables.AuthorizationDataList[e.AuthorizeDataId-1].Login,
                    GlobalVariables.AuthorizationDataList[e.AuthorizeDataId-1].Password));
            }
        }
    }
    public class EmployeeDisplayModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string role { get; set; }
        public decimal salary { get; set; }
        public string workingAddress { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public EmployeeDisplayModel(int id, string name, string surname, string patronymic, string role, decimal salary, string workingAddress, string login, string password)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.role = role;
            this.salary = salary;
            this.workingAddress = workingAddress;
            this.login = login;
            this.password = password;
        }
    }
}
