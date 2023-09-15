using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsvetoshaApplication.Models
{
    public class employeedisplaymodel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string role { get; set; }
        public decimal salary { get; set; }
        public string workingaddress { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public employeedisplaymodel(int id, string name, string surname, string patronymic, string role, decimal salary, string workingaddress, string login, string password)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.role = role;
            this.salary = salary;
            this.workingaddress = workingaddress;
            this.login = login;
            this.password = password;
        }
    }
}
