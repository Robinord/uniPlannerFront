using System;
using System.Collections.Generic;

namespace uniPlanner.Models;

public partial class Programmes
{
    public int ProgrammeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UniProgrammes> UniProgrammes { get; set; } = new List<UniProgrammes>();
}
