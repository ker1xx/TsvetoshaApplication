using System;
using System.Collections.Generic;

namespace TsvetoshaAPI.Models;

public partial class Order
{
    public int? Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime Date { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public int FlowerId { get; set; }

    public int FlowerCount { get; set; }

    public decimal Cost { get; set; }
}
