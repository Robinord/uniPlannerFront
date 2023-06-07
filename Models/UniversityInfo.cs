using System;
using System.Collections.Generic;

namespace uniPlanner.Models;

public partial class UniversityInfo
{
    public int UniversityId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public int Therank { get; set; }

    public int Qsrank { get; set; }

    public int Arwurank { get; set; }

    public virtual ICollection<UniProgrammes> UniProgrammes { get; set; } = new List<UniProgrammes>();
}
