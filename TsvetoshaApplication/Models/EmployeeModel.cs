using System;
using System.Collections.Generic;

namespace TsvetoshaApplication.Models;

public partial class EmployeeModel
{
    public int? Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int JobTitleId { get; set; }

    public decimal Salary { get; set; }

    public int ShopId { get; set; }

    public int AuthorizeDataId { get; set; }
    public EmployeeModel(int? id, string name, string surname, string patronymic, int jobTitleId, decimal salary, int shopId, int authorizeDataId)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        JobTitleId = jobTitleId;
        Salary = salary;
        ShopId = shopId;
        AuthorizeDataId = authorizeDataId;
    }
}
