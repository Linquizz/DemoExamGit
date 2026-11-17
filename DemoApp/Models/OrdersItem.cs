using System;
using System.Collections.Generic;

namespace DemoApp.Models;

public partial class OrdersItem
{
    public int OrdersItemsId { get; set; }

    public int? OrderId { get; set; }

    public int? Count { get; set; }

    public int? ProductId { get; set; }

    public int? SizeId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
