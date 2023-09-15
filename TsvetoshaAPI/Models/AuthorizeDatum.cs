using System;
using System.Collections.Generic;

namespace TsvetoshaAPI.Models;

public partial class AuthorizeDatum
{
    public int? Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

}
