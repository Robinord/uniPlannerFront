using System;
using System.Collections.Generic;

namespace uniPlanner.Models;

public partial class ApprovedAS
{
    public int As { get; set; }

    public string Subject { get; set; } = null!;

    public int Credits { get; set; }

    public string Assessment { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
