using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using TsvetoshaApplication.Abstraction;
using TsvetoshaApplication.Models;

namespace TsvetoshaApplication.Global
{
    public class StaticMethods
    {
        /// <summary>
        /// возвращает роль пользователя
        /// </summary>
        public static int? GetUserRole(int? DataID)
        {
            if (DataID != null)
                return GlobalVariables.EmployeesList[GlobalVariables.EmployeesList.FindIndex(x => x.AuthorizeDataId == DataID)].JobTitleId;
            return 0;
        }
        /// <summary>
        /// возращает id, если переданные в параметрах данные валидны
        /// </summary>
        public static int? GetUserIDByAuthorizationData(string login, string password)
        {
            foreach (var a in GlobalVariables.AuthorizationDataList)
            {
                if (a.Login == login && a.Password == password)
                {
                    WriteLog($"user {a.Id} loggined");
                    return a.Id;
                }
            }
            return null;
        }
        /// <summary>
        /// Получает данные пользователей для авторизации из БД
        /// </summary>
        public static void GetAuthorizationData()
        {
            try
            {
                string connectionString = "https://localhost:7010/api/AuthorizeDatums";
                HttpClient client = new HttpClient();
                HttpResponseMessage content = client.GetAsync(connectionString).Result;
                GlobalVariables.AuthorizationDataList = JsonConvert.
                    DeserializeObject<List<AuthorizeDataModel>>(
                    content.Content.ReadAsStringAsync().Result);
            }
            catch (NullReferenceException NullEx)
            {
                MessageBox.Show("не удалось получить данные с БД");
                WriteLog(NullEx.ToString());
            }
            catch (OutOfMemoryException OutMemEx)
            {
                MessageBox.Show("Нехватает памяти");
                WriteLog(OutMemEx.ToString());
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }
        /// <summary>
        /// Получает пользователей из БД
        /// </summary>
        public static void GetUsers()
        {
            try
            {
                string connectionString = "https://localhost:7010/api/Employees";
                HttpClient client = new HttpClient();
                HttpResponseMessage content = client.GetAsync(connectionString).Result;
                GlobalVariables.EmployeesList = JsonConvert.
                    DeserializeObject<List<EmployeeModel>>(
                    content.Content.ReadAsStringAsync().Result);
            }
            catch (NullReferenceException NullEx)
            {
                MessageBox.Show("не удалось получить данные с БД");
                WriteLog(NullEx.ToString());
            }
            catch (OutOfMemoryException OutMemEx)
            {
                MessageBox.Show("Нехватает памяти");
                WriteLog(OutMemEx.ToString());
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }
        /// <summary>
        /// Запись логов
        /// </summary>
        public static void WriteLog(string message)
        {
            string _logPath = ConfigurationManager.AppSettings["logPath"];
            using (StreamWriter writter = new StreamWriter(_logPath, true))
            {
                writter.WriteLine($"{DateTime.Now} : {message}");
            }
        }   
        /// <summary>
        /// Получение ролей из БД
        /// </summary>
        public static void GetRoles()
        {
            try
            {
                string connectionString = "https://localhost:7010/api/JobTitles";
                HttpClient client = new HttpClient();
                HttpResponseMessage content = client.GetAsync(connectionString).Result;
                GlobalVariables.RolesList = JsonConvert.
                    DeserializeObject<List<RoleModel>>(
                    content.Content.ReadAsStringAsync().Result);
            }
            catch (NullReferenceException NullEx)
            {
                MessageBox.Show("не удалось получить данные с БД");
                WriteLog(NullEx.ToString());
            }
            catch (OutOfMemoryException OutMemEx)
            {
                MessageBox.Show("Нехватает памяти");
                WriteLog(OutMemEx.ToString());
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }
        /// <summary>
        /// Получение магазинов из БД
        /// </summary>
        public static void GetShops()
        {
            try
            {
                string connectionString = "https://localhost:7010/api/Shops";
                HttpClient client = new HttpClient();
                HttpResponseMessage content = client.GetAsync(connectionString).Result;
                GlobalVariables.ShopsList = JsonConvert.
                    DeserializeObject<List<ShopModel>>(
                    content.Content.ReadAsStringAsync().Result);
            }
            catch (NullReferenceException NullEx)
            {
                MessageBox.Show("не удалось получить данные с БД");
                WriteLog(NullEx.ToString());
            }
            catch (OutOfMemoryException OutMemEx)
            {
                MessageBox.Show("Нехватает памяти");
                WriteLog(OutMemEx.ToString());
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }
        /// <summary>
        /// Обновление пользователя в БД
        /// </summary>
        public static async Task PutUsers(int? id,string name,string surname,string patronymic, int roleid, decimal salary, int shopid,int authorizeid)
        {
            try
            {
                string connectionString = $"https://localhost:7010/api/Employees/{id}";
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(new EmployeeModel(id,name,surname,patronymic,roleid,salary,shopid,authorizeid)));
                HttpResponseMessage message = await client.PutAsync(connectionString,content);
                if (message.IsSuccessStatusCode)
                    MessageBox.Show("Все успешно!");
                else
                    MessageBox.Show("Ошибка((");
            }
            catch (NullReferenceException NullEx)
            {
                MessageBox.Show("не удалось получить данные с БД");
                WriteLog(NullEx.ToString());
            }
            catch (OutOfMemoryException OutMemEx)
            {
                MessageBox.Show("Нехватает памяти");
                WriteLog(OutMemEx.ToString());
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }
        /// <summary>
        /// Обновление данных авторизации в БД
        /// </summary>
        public static async Task PutAuthorizeData(int? id, string login, string password)
        {
            try
            {
                string connectionString = $"https://localhost:7010/api/AuthorizeDatums/{id}";
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(new AuthorizeDataModel(id,login,password)));
                HttpResponseMessage message = await client.PutAsync(connectionString,content);
                if (message.IsSuccessStatusCode)
                    MessageBox.Show("Все успешно!");
                else
                    MessageBox.Show("Ошибка((");
            }
            catch (NullReferenceException NullEx)
            {
                MessageBox.Show("не удалось получить данные с БД");
                WriteLog(NullEx.ToString());
            }
            catch (OutOfMemoryException OutMemEx)
            {
                MessageBox.Show("Нехватает памяти");
                WriteLog(OutMemEx.ToString());
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }
    }
}
