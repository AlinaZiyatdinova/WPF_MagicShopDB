using System;
using System.Collections.Generic;

namespace MagicShopWPF.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<MagicProduct> MagicProducts { get; set; } = new List<MagicProduct>();
}
