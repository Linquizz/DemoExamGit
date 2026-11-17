using System;
using System.Collections.Generic;

namespace DemoApp.Models;

public partial class Subcategory
{
    public int SubcategoriesId { get; set; }

    public string? Subcategories { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
