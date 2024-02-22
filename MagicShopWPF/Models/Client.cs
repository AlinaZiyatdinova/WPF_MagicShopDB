using System;
using System.Collections.Generic;

namespace MagicShopWPF.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? Lastname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? MagicLevel { get; set; }

    public DateOnly? DateofBirth { get; set; }

    public string? NumberPhone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
