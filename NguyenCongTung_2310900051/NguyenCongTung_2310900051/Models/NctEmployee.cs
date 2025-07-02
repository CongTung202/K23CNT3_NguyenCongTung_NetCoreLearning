using System;
using System.Collections.Generic;

namespace NguyenCongTung_2310900051.Models;

public partial class NctEmployee
{
    public string NctEmpId { get; set; } = null!;

    public string? NctEmpName { get; set; }

    public string? NctEmpLevel { get; set; }

    public DateOnly? NctEmpStartDate { get; set; }

    public bool? NctEmpStatus { get; set; }
}
