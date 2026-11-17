using System;
using System.Collections.Generic;

namespace DemoApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public string? Login { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
