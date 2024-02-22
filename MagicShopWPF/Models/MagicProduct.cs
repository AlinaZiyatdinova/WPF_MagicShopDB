using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagicShopWPF.Models;

public partial class MagicProduct
{
    public int Id { get; set; }

    public string? NameProduct { get; set; }
    [Required(ErrorMessage = "Количество не должно быть меньше нуля")]
    [Range(0, 1000, ErrorMessage = "Укажите количество")]
    public int? Amount { get; set; }

    public int? MagicPower { get; set; }

    public int? CategoryId { get; set; }

    public string? ImagePath { get; set; }

    public int? Cost { get; set; }

    public string? Description { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
