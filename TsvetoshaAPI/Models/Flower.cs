using System;
using System.Collections.Generic;

namespace TsvetoshaAPI.Models;

public partial class Flower
{
    public int? Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public int Amount { get; set; }
}
