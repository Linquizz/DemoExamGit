using System;
using System.Collections.Generic;

namespace DemoApp.Models;

public partial class Catogory
{
    public int CategoryId { get; set; }

    public string? Category { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
