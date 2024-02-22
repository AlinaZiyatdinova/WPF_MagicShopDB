using System;
using System.Collections.Generic;

namespace MagicShopWPF.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public int? Amount { get; set; }

    public int? MageId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Mage? Mage { get; set; }

    public virtual MagicProduct? Product { get; set; }
}
