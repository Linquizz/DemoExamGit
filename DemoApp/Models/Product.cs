using System;
using System.Collections.Generic;

namespace DemoApp.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Image { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Compound { get; set; }

    public decimal? Price { get; set; }

    public int? CategoryId { get; set; }

    public int? SubcategoriesId { get; set; }

    public int? ManufacturerId { get; set; }

    public virtual Catogory? Category { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<OrdersItem> OrdersItems { get; set; } = new List<OrdersItem>();

    public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();

    public virtual Subcategory? Subcategories { get; set; }
}
