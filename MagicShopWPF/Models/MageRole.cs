using System;
using System.Collections.Generic;

namespace MagicShopWPF.Models;

public partial class MageRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Mage> Mages { get; set; } = new List<Mage>();
}
