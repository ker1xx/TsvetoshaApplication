using System;
using System.Collections.Generic;

namespace TsvetoshaAPI.Models;

public partial class Employee
{
    public int? Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int JobTitleId { get; set; }

    public decimal Salary { get; set; }

    public int ShopId { get; set; }

    public int AuthorizeDataId { get; set; }
}
