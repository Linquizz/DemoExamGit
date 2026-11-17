using System;
using System.Collections.Generic;

namespace DemoApp.Models;

public partial class Size
{
    public int SizeId { get; set; }

    public double? Size1 { get; set; }

    public virtual ICollection<OrdersItem> OrdersItems { get; set; } = new List<OrdersItem>();

    public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
}
