using System;
using System.Collections.Generic;

namespace syndicateApp.Models;

public partial class TblPost
{
    public int IdNo { get; set; }

    public int PostCategory { get; set; }

    public string? PostText { get; set; }

    public string? PostImage { get; set; }

    public int IsActive { get; set; }

    public string? MetaData { get; set; }
}
