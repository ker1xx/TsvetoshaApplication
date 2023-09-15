using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsvetoshaApplication.Models;

namespace TsvetoshaApplication.Global
{
    internal class GlobalVariables
    {
        /// <summary>
        /// Лист данных для авторизации пользователей
        /// </summary>
        public static List<AuthorizeDataModel> AuthorizationDataList = new List<AuthorizeDataModel>() { };
        /// <summary>
        /// Лист всех пользователей
        /// </summary>
        public static List<EmployeeModel> EmployeesList = new List<EmployeeModel>() { };
        /// <summary>
        /// Лист ролей
        /// </summary>
        public static List<RoleModel> RolesList = new List<RoleModel>() { };
        /// <summary>
        /// Лист магазинов
        /// </summary>
        public static List<ShopModel> ShopsList = new List<ShopModel>() { };
    }
}
