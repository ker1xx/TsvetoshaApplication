using System;
using System.Collections.Generic;

namespace TsvetoshaApplication.Models;

public partial class AuthorizeDataModel
{
    public int? Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
    public AuthorizeDataModel(int? id, string login, string password)
    {
        this.Id = id;
        this.Login = login;
        this.Password = password;
    }

}
