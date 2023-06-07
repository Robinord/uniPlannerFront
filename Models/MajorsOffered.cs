using System;
using System.Collections.Generic;

namespace uniPlanner.Models;

public partial class MajorsOffered
{
    public int MajorOfferedId { get; set; }

    public int UniProgrammeId { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public virtual UniProgrammes UniProgramme { get; set; } = null!;
}
