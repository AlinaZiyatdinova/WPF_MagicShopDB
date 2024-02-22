using System;
using System.Collections.Generic;

namespace MagicShopWPF.Models;

public partial class Mage
{
    public int MageId { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual MageRole? Role { get; set; }
}
