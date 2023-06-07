using System;
using System.Collections.Generic;

namespace uniPlanner.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string StudentEmail { get; set; } = null!;

    public int As { get; set; }

    public string Grade1 { get; set; } = null!;

    public virtual ApprovedAS AsNavigation { get; set; } = null!;

    public virtual Student StudentEmailNavigation { get; set; } = null!;
}
