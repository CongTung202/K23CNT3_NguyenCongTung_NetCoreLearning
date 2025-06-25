using System;
using System.Collections.Generic;

namespace nctLesson10.Models;

public partial class NctPost
{
    public int NctId { get; set; }

    public string? NctTitle { get; set; }

    public string? NctImage { get; set; }

    public string? NctContent { get; set; }

    public bool? NctStatus { get; set; }
}
